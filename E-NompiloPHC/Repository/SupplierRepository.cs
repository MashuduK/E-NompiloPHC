using E_NompiloPHC.Interface;
using E_NompiloPHC.Models;
using E_NompiloPHC.ViewModels;

namespace E_NompiloPHC.Repository
{
    public class SupplierRepository: ISupplier
    {
        private IUnitOfWork _unitOfWork;

        public SupplierRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public PagedResult<MedicalReportModel> GetAll(int pageNumber, int pageSize)
        {
            var vm = new MedicalReportModel();
            int totalCount;
            List<MedicalReportModel> vmList = new List<MedicalReportModel>();
            try
            {
                int ExcludeRecords = (pageSize * pageNumber) - pageSize;
                var modelList = _unitOfWork.GenericRepository<Supplier>().GetAll().Skip(ExcludeRecords).Take(pageSize).ToList();
                totalCount = _unitOfWork.GenericRepository<Supplier>().GetAll().ToList().Count;
                vmList = ConverModelToViewModelList(modelList);
            }
            catch (Exception) { throw; }

            var result = new PagedResult<MedicalReportModel>
            {
                Data = vmList,
                TotalItems = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
            return result;
        }
        private List<MedicalReportModel> ConverModelToViewModelList(List<Supplier> modelList)
        {
            return modelList.Select(x => new MedicalReportModel(x)).ToList();
        }

        
        public void DeleteSupplier(int id)
        {
            var model = _unitOfWork.GenericRepository<Supplier>().GetById(id);
            _unitOfWork.GenericRepository<Supplier>().Delete(model);
            _unitOfWork.Save();

        }


        public MedicalReportModel GetSupplierById(int SupplierId)
        {
            var model = _unitOfWork.GenericRepository<Supplier>().GetById(SupplierId);
            var vm = new MedicalReportModel(model);
            return vm;
        }

        
        public void InsertSupplier(MedicalReportModel supplier)
        {
            var model = new MedicalReportModel().ConvertViewModel(supplier);
            _unitOfWork.GenericRepository<Supplier>().Add(model);
            _unitOfWork.Save();
        }

        public void UpdateSupplier(MedicalReportModel supplier)
        {
            var model = new MedicalReportModel().ConvertViewModel(supplier);
            var ModelById = _unitOfWork.GenericRepository<Supplier>().GetById(model.Id);
	    ModelById.MedicalReport = supplier.MedicalReport;
            ModelById.Company = supplier.Company;
            ModelById.Email  = supplier.Email ;
            ModelById.Address  = supplier.Address ;
            ModelById.PhoneNumber  = supplier.PhoneNumber ;
            _unitOfWork.GenericRepository<Supplier>().Update(ModelById);
            _unitOfWork.Save();
        }        
    }
}
