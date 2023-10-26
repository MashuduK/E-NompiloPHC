using E_NompiloPHC.Models;
using E_NompiloPHC.ViewModels;

namespace E_NompiloPHC.Interface
{
    public interface IPatientReport
    {
        PagedResult<PatientReportViewModel> GetAll(int pageNumber, int pageSize);
        PatientReportViewModel GetPatientReportById(int PatientReportId);
        void UpdatePatientReport(PatientReportViewModel PatientReport);
        void InsertPatientReport(PatientReportViewModel PatientReport);
        void DeletePatientReport(int id);
    }
}
