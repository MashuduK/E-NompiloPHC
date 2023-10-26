using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace E_NompiloPHC.Models
{
    public class Supplier
    {
        public int Id { get; set; }

        public string Company { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        public string Province { get; set; }
        public ICollection<MedicalReport> MedicalReport { get; set; }
    }
}
