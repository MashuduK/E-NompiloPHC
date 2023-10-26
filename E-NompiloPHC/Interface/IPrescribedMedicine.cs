using E_NompiloPHC.Models;
using E_NompiloPHC.ViewModels;

namespace E_NompiloPHC.Interface
{
    public interface IPrescribedMedicine
    {
        PagedResult<PrescribedMedicineViewModel> GetAll(int pageNumber, int pageSize);
        PrescribedMedicineViewModel GetPrescribedMedicineById(int PrescribedMedicineId);
        void UpdatePrescribedMedicine(PrescribedMedicineViewModel PrescribedMedicine);
        void InsertPrescribedMedicine(PrescribedMedicineViewModel PrescribedMedicine);
        void DeletePrescribedMedicine(int id);
    }
}
