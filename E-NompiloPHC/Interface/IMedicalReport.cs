using E_NompiloPHC.Models;
using E_NompiloPHC.ViewModels;

namespace E_NompiloPHC.Interface
{
    public interface IMedicalReport
    {
        PagedResult<MedicalReportViewModel> GetAll(int pageNumber, int pageSize);
        MedicalReportViewModel GetMedicalReportById(int MedicalReportId);
        void UpdateMedicalReport(MedicalReportViewModel medicalReport);
        void InsertMedicalReport(MedicalReportViewModel medicalReport);
        void DeleteMedicalReport(int id);
    }
}
