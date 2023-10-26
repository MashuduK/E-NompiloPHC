using E_NompiloPHC.Models;
using E_NompiloPHC.ViewModels;

namespace E_NompiloPHC.Interface
{
    public interface IReferral
    {
        PagedResult<ReferralViewModel> GetAll(int pageNumber, int pageSize);
        ReferralViewModel GetReferralById(int ReferralId);
        void UpdateReferral(ReferralViewModel Referral);
        void InsertReferral(ReferralViewModel Referral);
        void DeleteReferral(int id);
    }
}
