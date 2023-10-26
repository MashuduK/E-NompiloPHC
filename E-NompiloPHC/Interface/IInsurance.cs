using E_NompiloPHC.Models;
using E_NompiloPHC.ViewModels;

namespace E_NompiloPHC.Interface
{
    public interface IInsurance
    {
        PagedResult<InsuranceViewModel> GetAll(int pageNumber, int pageSize);
        InsuranceViewModel GetInsuranceById(int InsuranceId);
        void UpdateInsurance(InsuranceViewModel insurance);
        void InsertInsurance(InsuranceViewModel insurance);
        void DeleteInsurance(int id);
    }
}
