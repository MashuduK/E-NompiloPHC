using E_NompiloPHC.Models;
using E_NompiloPHC.ViewModels;

namespace E_NompiloPHC.Interface
{
    public interface IContact
    {
        PagedResult<ContactViewModel> GetAll(int pageNumber, int pageSize);
        ContactViewModel GetContactById(int ContactId);
        void UpdateContact(ContactViewModel Contact);
        void InsertContact(ContactViewModel Contact);
        void DeleteContact(int id);
    }
}
