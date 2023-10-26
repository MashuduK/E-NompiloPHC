using E_NompiloPHC.Interface;
using E_NompiloPHC.Models;
using E_NompiloPHC.ViewModels;

namespace E_NompiloPHC.Repository
{
    public class MedicalReportRepository: IMedicalReport
    {
        private IUnitOfWork _unitOfWork;

        public MedicalReportRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public PagedResult<MedicalReportViewModel> GetAll(int pageNumber, int pageSize)
        {
            var vm = new MedicalReportViewModel();
            int totalCount;
            List<MedicalReportViewModel> vmList = new List<MedicalReportViewModel>();
            try
            {
                int ExcludeRecords = (pageSize * pageNumber) - pageSize;
                var modelList = _unitOfWork.GenericRepository<MedicalReport>().GetAll().Skip(ExcludeRecords).Take(pageSize).ToList();
                totalCount = _unitOfWork.GenericRepository<MedicalReport>().GetAll().ToList().Count;
                vmList = ConverModelToViewModelList(modelList);
            }
            catch (Exception) { throw; }

            var result = new PagedResult<MedicalReportViewModel>
            {
                Data = vmList,
                TotalItems = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
            return result;
        }
        private List<MedicalReportViewModel> ConverModelToViewModelList(List<MedicalReport> modelList)
        {
            return modelList.Select(x => new MedicalReportViewModel(x)).ToList();
        }

        
        public void DeleteMedicalReport(int id)
        {
            var model = _unitOfWork.GenericRepository<MedicalReport>().GetById(id);
            _unitOfWork.GenericRepository<MedicalReport>().Delete(model);
            _unitOfWork.Save();

        }


        public MedicalReportViewModel GetMedicalReportById(int MedicalReportId)
        {
            var model = _unitOfWork.GenericRepository<MedicalReport>().GetById(MedicalReportId);
            var vm = new MedicalReportViewModel(model);
            return vm;
        }

        
        public void InsertMedicalReport(MedicalReportViewModel medicalReport)
        {
            var model = new MedicalReportViewModel().ConvertViewModel(medicalReport);
            _unitOfWork.GenericRepository<MedicalReport>().Add(model);
            _unitOfWork.Save();
        }

        public void UpdateMedicalReport(MedicalReportViewModel medicaReport)
        {
            var model = new MedicalReportViewModel().ConvertViewModel(medicaReport);
            var ModelById = _unitOfWork.GenericRepository<MedicalReport>().GetById(model.Id);
	    ModelById.Supplier = medicaReport.Supplier;
            ModelById.Medicine = medicaReport.Medicine;
            ModelById.Company = medicaReport.Company ;
            ModelById.Quantity  = medicaReport.Quantity;
            ModelById.ProductionDate  = medicaReport.ProductionDate;
	    ModelById.ExpireTime = medicaReport.ExpireTime;
            ModelById.Country  = medicaReport.Country;
            _unitOfWork.GenericRepository<MedicalReport>().Update(ModelById);
            _unitOfWork.Save();
        }        
    }
}
