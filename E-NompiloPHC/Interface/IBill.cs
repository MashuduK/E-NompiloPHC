using E_NompiloPHC.Models;
using E_NompiloPHC.ViewModels;

namespace E_NompiloPHC.Interface
{
    public interface IBill
    {
        PagedResult<BillViewModel> GetAll(int pageNumber, int pageSize);
        BillViewModel GetBillById(int BillId);
        void UpdateBill(BillViewModel bill);
        void InsertBill(BillViewModel bill);
        void DeleteBill(int id);
    }
}
