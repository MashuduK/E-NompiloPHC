using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace E_NompiloPHC.Models
{
    public class Contact
    {
        public int Id { get; set; }

        public int HospitalInformationId { get; set; }
        public HospitalInformation HospitalInformation { get; set; }
        public string Email { get; set; }
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
    }
}