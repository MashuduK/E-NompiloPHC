using E_NompiloPHC.Models;
using E_NompiloPHC.ViewModels;

namespace E_NompiloPHC.Interface
{
    public interface IApplicationUser
    {
        PagedResult<ApplicationUserViewModel> GetAll(int pageNumber, int pageSize);
        PagedResult<ApplicationUserViewModel> GetAllDoctor(int pageNumber, int pageSize);
        PagedResult<ApplicationUserViewModel> GetAllPatient(int pageNumber, int pageSize);
        PagedResult<ApplicationUserViewModel> SearchDoctor(int pageNumber, int pageSize, string Spicility = null);
    }
}
