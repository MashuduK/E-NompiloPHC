using E_NompiloPHC.Interface;
using E_NompiloPHC.Models;
using E_NompiloPHC.ViewModels;

namespace E_NompiloPHC.Repository
{
    public class ContactRepository:IContact
    {
        private IUnitOfWork _unitOfWork;

        public ContactRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public PagedResult<ContactViewModel> GetAll(int pageNumber, int pageSize)
        {
            var vm = new ContactViewModel();
            int totalCount;
            List<ContactViewModel> vmList = new List<ContactViewModel>();
            try
            {
                int ExcludeRecords = (pageSize * pageNumber) - pageSize;
                var modelList = _unitOfWork.GenericRepository<Contact>().GetAll().Skip(ExcludeRecords).Take(pageSize).ToList();
                totalCount = _unitOfWork.GenericRepository<Contact>().GetAll().ToList().Count;
                vmList = ConverModelToViewModelList(modelList);
            }
            catch (Exception) { throw; }

            var result = new PagedResult<ContactViewModel>
            {
                Data = vmList,
                TotalItems = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
            return result;
        }
        private List<ContactViewModel> ConverModelToViewModelList(List<Contact> modelList)
        {
            return modelList.Select(x => new ContactViewModel(x)).ToList();
        }


        public void DeleteContact(int id)
        {
            var model = _unitOfWork.GenericRepository<Contact>().GetById(id);
            _unitOfWork.GenericRepository<Contact>().Delete(model);
            _unitOfWork.Save();

        }


        public ContactViewModel GetContactById(int RoomId)
        {
            var model = _unitOfWork.GenericRepository<Contact>().GetById(RoomId);
            var vm = new ContactViewModel(model);
            return vm;
        }


        public void InsertContact(ContactViewModel Contact)
        {
            var model = new ContactViewModel().ConvertViewModel(Contact);
            _unitOfWork.GenericRepository<Contact>().Add(model);
            _unitOfWork.Save();
        }

        public void UpdateContact(ContactViewModel Contact)
        {
            var model = new ContactViewModel().ConvertViewModel(Contact);
            var ModelById = _unitOfWork.GenericRepository<Contact>().GetById(model.Id);
            ModelById.Email = Contact.Email;
            ModelById.PhoneNumber = Contact.PhoneNumber;
            ModelById.HospitalInformationId = Contact.HospitalInformationId;


            _unitOfWork.GenericRepository<Contact>().Update(ModelById);
            _unitOfWork.Save();
        }
    }
}
