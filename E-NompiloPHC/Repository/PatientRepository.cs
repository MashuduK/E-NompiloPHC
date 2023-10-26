using E_NompiloPHC.Interface;
using E_NompiloPHC.Models;
using E_NompiloPHC.ViewModels;
using System;

namespace E_NompiloPHC.Repository
{
    public class PatientRepository : IPatient
    {
        private IUnitOfWork _unitOfWork;

        public PatientRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void AddTiming(TimingViewModel timing)
        {
            var model = new TimingViewModel().ConvertViewModel(timing);
            _unitOfWork.GenericRepository<Timing>().Add(model);
            _unitOfWork.Save();
        }
        public void DeleteTiming(int TimingId)
        {
            var model = _unitOfWork.GenericRepository<Timing>().GetById(TimingId);
            _unitOfWork.GenericRepository<Timing>().Delete(model);
            _unitOfWork.Save();

        }
        public PagedResult<TimingViewModel> GetAll(int pageNumber, int pageSize)
        {
            var vm = new TimingViewModel();
            int totalCount;
            List<TimingViewModel> vmList = new List<TimingViewModel>();
            try
            {
                int ExcludeRecords = (pageSize * pageNumber) - pageSize;
                var modelList = _unitOfWork.GenericRepository<Timing>().GetAll().Skip(ExcludeRecords).Take(pageSize).ToList();
                totalCount = _unitOfWork.GenericRepository<Timing>().GetAll().ToList().Count;
                vmList = ConvertModelToViewModelList(modelList);
            }
            catch (Exception) { throw; }
            var result = new PagedResult<TimingViewModel>
            {
                Data = vmList,
                TotalItems = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
            return result;
        }
        public IEnumerable<TimingViewModel> GetAll()
        {
            var TimingList = _unitOfWork.GenericRepository<Timing>().GetAll().ToList();
            var vmList = ConvertModelToViewModelList(TimingList);
            return vmList;
        }
        public TimingViewModel GetTimingById(int TimingId)
        {
            var model = _unitOfWork.GenericRepository<Timing>().GetById(TimingId);
            var vm = new TimingViewModel(model);
            return vm;
        }
        public void UpdateTiming(TimingViewModel timing)
        {
            var model = new TimingViewModel().ConvertViewModel(timing);
            var modelById = _unitOfWork.GenericRepository<Timing>().GetById(model.Id);
            modelById.Id = timing.Id;
            modelById.Doctor = timing.Doctor;
            modelById.Status = timing.Status;
            modelById.Duration = timing.Duration;
            modelById.MorningShiftStartTime = timing.MorningShiftStartTime;
            modelById.MorningShiftEndTime = timing.MorningShiftEndTime;
            modelById.NightShiftStartTime = timing.NightShiftStartTime;
            modelById.NightShiftEndTime = timing.NightShiftEndTime;
        }

        private List<TimingViewModel> ConvertModelToViewModelList(List<Timing> modelList)
        {
            return modelList.Select(x => new TimingViewModel(x)).ToList();
        }
    }
}


