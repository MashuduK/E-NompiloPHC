using E_NompiloPHC.Models;

namespace E_NompiloPHC.ViewModels
{
    public class ContactViewModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int HospitalInformationId { get; set; }
        public ContactViewModel() { }
        public ContactViewModel(Contact model)
        {
            Id = model.Id;
            Email = model.Email;
            PhoneNumber = model.PhoneNumber;
            HospitalInformationId = model.HospitalInformationId;
        }
        public Contact ConvertViewModel(ContactViewModel model)
        {
            return new Contact
            {
                Id = model.Id,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                HospitalInformationId = model.HospitalInformationId
            };

        }
    }
}
