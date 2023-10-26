using E_NompiloPHC.Models;
using E_NompiloPHC.ViewModels;

namespace E_NompiloPHC.Interface
{
    public interface IHospitalInformation
    {
        PagedResult<HospitalInformationViewModel> GetAll(int pageNumber, int pageSize);
        HospitalInformationViewModel GetHospitalById(int HospitalId);
        void UpdateHospitalInformation(HospitalInformationViewModel hospital);
        void InsertHospitalInformation(HospitalInformationViewModel hospital);
        void DeleteHospitalInformation(int id);
    }
}
