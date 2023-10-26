using E_NompiloPHC.Interface;
using E_NompiloPHC.Models;
using E_NompiloPHC.ViewModels;
using System.Numerics;

namespace E_NompiloPHC.Repository
{
    public class ReferralRepository : IReferral
    {
        private IUnitOfWork _unitOfWork;

        public ReferralRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public PagedResult<ReferralViewModel> GetAll(int pageNumber, int pageSize)
        {
            var vm = new ReferralViewModel();
            int totalCount;
            List<ReferralViewModel> vmList = new List<ReferralViewModel>();
            try
            {
                int ExcludeRecords = (pageSize * pageNumber) - pageSize;
                var modelList = _unitOfWork.GenericRepository<Referral>().GetAll().Skip(ExcludeRecords).Take(pageSize).ToList();
                totalCount = _unitOfWork.GenericRepository<Referral>().GetAll().ToList().Count;
                vmList = ConverModelToViewModelList(modelList);
            }
            catch (Exception) { throw; }

            var result = new PagedResult<ReferralViewModel>
            {
                Data = vmList,
                TotalItems = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
            return result;
        }
        private List<ReferralViewModel> ConverModelToViewModelList(List<Referral> modelList)
        {
            return modelList.Select(x => new ReferralViewModel(x)).ToList();
        }


        public void DeleteReferral(int id)
        {
            var model = _unitOfWork.GenericRepository<Referral>().GetById(id);
            _unitOfWork.GenericRepository<Referral>().Delete(model);
            _unitOfWork.Save();

        }


        public ReferralViewModel GetReferralById(int ReferralId)
        {
            var model = _unitOfWork.GenericRepository<Referral>().GetById(ReferralId);
            var vm = new ReferralViewModel(model);
            return vm;
        }


        public void InsertReferral(ReferralViewModel Referral)
        {
            var model = new ReferralViewModel().ConvertViewModel(Referral);
            _unitOfWork.GenericRepository<Referral>().Add(model);
            _unitOfWork.Save();
        }

        public void UpdateReferral(ReferralViewModel Referral)
        {
            var model = new ReferralViewModel().ConvertViewModel(Referral);
            var ModelById = _unitOfWork.GenericRepository<Referral>().GetById(model.Id);
            ModelById.AppointmentId = Referral.AppointmentId;
            ModelById.CreatedReferral = Referral.CreatedReferral;
            ModelById.ReferralDate = Referral.ReferralDate;
            ModelById.ReferralReason = Referral.ReferralReason;
            ModelById.IsCompleted = Referral.IsCompleted;
            ModelById.IsCanceled = Referral.IsCanceled;
            ModelById.CancelledDate = Referral.CancelledDate;
            ModelById.CancelledDate = Referral.CancelledDate;
            ModelById.Notes = Referral.Notes;
            ModelById.Doctor = Referral.Doctor;
            ModelById.Patient = Referral.Patient;
            _unitOfWork.GenericRepository<Referral>().Update(ModelById);
            _unitOfWork.Save();
        }
    }
}
