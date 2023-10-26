using E_NompiloPHC.Interface;
using E_NompiloPHC.Models;
using E_NompiloPHC.ViewModels;

namespace E_NompiloPHC.Repository
{
    public class PatientReportRepository: IPatientReport
    {
        private IUnitOfWork _unitOfWork;

        public PatientReportRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public PagedResult<PatientReportViewModel> GetAll(int pageNumber, int pageSize)
        {
            var vm = new PatientReportViewModel();
            int totalCount;
            List<PatientReportViewModel> vmList = new List<PatientReportViewModel>();
            try
            {
                int ExcludeRecords = (pageSize * pageNumber) - pageSize;
                var modelList = _unitOfWork.GenericRepository<PatientReport>().GetAll().Skip(ExcludeRecords).Take(pageSize).ToList();
                totalCount = _unitOfWork.GenericRepository<PatientReport>().GetAll().ToList().Count;
                vmList = ConverModelToViewModelList(modelList);
            }
            catch (Exception) { throw; }

            var result = new PagedResult<PatientReportViewModel>
            {
                Data = vmList,
                TotalItems = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
            return result;
        }
        private List<PatientReportViewModel> ConverModelToViewModelList(List<PatientReport> modelList)
        {
            return modelList.Select(x => new PatientReportViewModel(x)).ToList();
        }

        
        public void DeletePatientReport(int id)
        {
            var model = _unitOfWork.GenericRepository<PatientReport>().GetById(id);
            _unitOfWork.GenericRepository<PatientReport>().Delete(model);
            _unitOfWork.Save();

        }


        public PatientReportViewModel GetPatientReportById(int PatientReportId)
        {
            var model = _unitOfWork.GenericRepository<PatientReport>().GetById(PatientReportId);
            var vm = new PatientReportViewModel(model);
            return vm;
        }

        
        public void InsertPatientReport(PatientReportViewModel PatientReport)
        {
            var model = new PatientReportViewModel().ConvertViewModel(PatientReport);
            _unitOfWork.GenericRepository<PatientReport>().Add(model);
            _unitOfWork.Save();
        }

        public void UpdatePatientReport(PatientReportViewModel PatientReport)
        {
            var model = new PatientReportViewModel().ConvertViewModel(PatientReport);
            var ModelById = _unitOfWork.GenericRepository<PatientReport>().GetById(model.Id);
	    ModelById.Doctor = PatientReport.Doctor;
            ModelById.Diagnose = PatientReport.Diagnose;
            ModelById.Patient  = PatientReport.Patient ;
            ModelById.PrescribedMedicine  = PatientReport.PrescribedMedicine ;
            _unitOfWork.GenericRepository<PatientReport>().Update(ModelById);
            _unitOfWork.Save();
        }


    }
}
