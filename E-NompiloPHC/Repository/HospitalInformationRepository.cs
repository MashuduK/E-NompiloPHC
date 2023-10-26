using E_NompiloPHC.Interface;
using E_NompiloPHC.Models;
using E_NompiloPHC.ViewModels;

namespace E_NompiloPHC.Repository
{
    public class HospitalInformationRepository: IHospitalInformation
    {
        private IUnitOfWork _unitOfWork;

        public HospitalInformationRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public PagedResult<HospitalInformationViewModel> GetAll(int pageNumber, int pageSize)
        {
            var vm = new HospitalInformationViewModel();
            int totalCount;
            List<HospitalInformationViewModel> vmList = new List<HospitalInformationViewModel>();
            try
            {
                int ExcludeRecords = (pageSize * pageNumber) - pageSize;
                var modelList = _unitOfWork.GenericRepository<HospitalInformation>().GetAll().Skip(ExcludeRecords).Take(pageSize).ToList();
                totalCount = _unitOfWork.GenericRepository<HospitalInformation>().GetAll().ToList().Count;
                vmList = ConverModelToViewModelList(modelList);
            }
            catch (Exception) { throw; }

            var result = new PagedResult<HospitalInformationViewModel>
            {
                Data = vmList,
                TotalItems = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
            return result;
        }
        private List<HospitalInformationViewModel> ConverModelToViewModelList(List<HospitalInformation> modelList)
        {
            return modelList.Select(x => new HospitalInformationViewModel(x)).ToList();
        }

        
        public void DeleteHospitalInformation(int id)
        {
            var model = _unitOfWork.GenericRepository<HospitalInformation>().GetById(id);
            _unitOfWork.GenericRepository<HospitalInformation>().Delete(model);
            _unitOfWork.Save();

        }


        public HospitalInformationViewModel GetHospitalById(int HospitalId)
        {
            var model = _unitOfWork.GenericRepository<HospitalInformation>().GetById(HospitalId);
            var vm = new HospitalInformationViewModel(model);
            return vm;
        }

        
        public void InsertHospitalInformation(HospitalInformationViewModel hospital)
        {
            var model = new HospitalInformationViewModel().ConvertViewModel(hospital);
            _unitOfWork.GenericRepository<HospitalInformation>().Add(model);
            _unitOfWork.Save();
        }

        public void UpdateHospitalInformation(HospitalInformationViewModel hospital)
        {
            var model = new HospitalInformationViewModel().ConvertViewModel(hospital);
            var ModelById = _unitOfWork.GenericRepository<HospitalInformation>().GetById(model.Id);
            ModelById.Name = hospital.Name;
            ModelById.City = hospital.City;
            ModelById.AreaCode = hospital.AreaCode;
            ModelById.Province = hospital.Province;
            _unitOfWork.GenericRepository<HospitalInformation>().Update(ModelById);
            _unitOfWork.Save();
        }        
    }
}
