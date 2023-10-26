using E_NompiloPHC.Models;
using E_NompiloPHC.ViewModels;

namespace E_NompiloPHC.Interface
{
    public interface ISupplier
    {
        PagedResult<MedicalReportModel> GetAll(int pageNumber, int pageSize);
        MedicalReportModel GetSupplierById(int SupplierId);
        void UpdateSupplier(MedicalReportModel supplier);
        void InsertSupplier(MedicalReportModel supplier);
        void DeleteSupplier(int id);
    }
}
