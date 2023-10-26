using E_NompiloPHC.Interface;
using E_NompiloPHC.Models;
using E_NompiloPHC.ViewModels;

namespace E_NompiloPHC.Repository
{
    public class InsuranceRepository: IInsurance
    {
        private IUnitOfWork _unitOfWork;

        public InsuranceRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public PagedResult<InsuranceViewModel> GetAll(int pageNumber, int pageSize)
        {
            var vm = new InsuranceViewModel();
            int totalCount;
            List<InsuranceViewModel> vmList = new List<InsuranceViewModel>();
            try
            {
                int ExcludeRecords = (pageSize * pageNumber) - pageSize;
                var modelList = _unitOfWork.GenericRepository<Insurance>().GetAll().Skip(ExcludeRecords).Take(pageSize).ToList();
                totalCount = _unitOfWork.GenericRepository<Insurance>().GetAll().ToList().Count;
                vmList = ConverModelToViewModelList(modelList);
            }
            catch (Exception) { throw; }

            var result = new PagedResult<InsuranceViewModel>
            {
                Data = vmList,
                TotalItems = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
            return result;
        }
        private List<InsuranceViewModel> ConverModelToViewModelList(List<Insurance> modelList)
        {
            return modelList.Select(x => new InsuranceViewModel(x)).ToList();
        }

        
        public void DeleteInsurance(int id)
        {
            var model = _unitOfWork.GenericRepository<Insurance>().GetById(id);
            _unitOfWork.GenericRepository<Insurance>().Delete(model);
            _unitOfWork.Save();

        }


        public InsuranceViewModel GetInsuranceById(int InsuranceId)
        {
            var model = _unitOfWork.GenericRepository<Insurance>().GetById(InsuranceId);
            var vm = new InsuranceViewModel(model);
            return vm;
        }

        
        public void InsertInsurance(InsuranceViewModel insurance)
        {
            var model = new InsuranceViewModel().ConvertViewModel(insurance);
            _unitOfWork.GenericRepository<Insurance>().Add(model);
            _unitOfWork.Save();
        }

        public void UpdateInsurance(InsuranceViewModel insurance)
        {
            var model = new InsuranceViewModel().ConvertViewModel(insurance);
            var ModelById = _unitOfWork.GenericRepository<Insurance>().GetById(model.Id);
            ModelById.PolicyNumber = insurance.PolicyNumber;
            ModelById.StartDate  = insurance.StartDate ;
            ModelById.EndDate  = insurance.EndDate;
            ModelById.Bill  = insurance.Bill ;
            _unitOfWork.GenericRepository<Insurance>().Update(ModelById);
            _unitOfWork.Save();
        }        
    }
}
