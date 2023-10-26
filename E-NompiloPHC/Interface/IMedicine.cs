using E_NompiloPHC.Models;
using E_NompiloPHC.ViewModels;

namespace E_NompiloPHC.Interface
{
    public interface IMedicine
    {
        PagedResult<MedicineViewModel> GetAll(int pageNumber, int pageSize);
        MedicineViewModel GetMedicineById(int MedicineId);
        void UpdateMedicine(MedicineViewModel Medicine);
        void InsertMedicine(MedicineViewModel Medicine);
        void DeleteMedicine(int id);
    }
}
