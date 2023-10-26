using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace E_NompiloPHC.Models
{
    public class HospitalInformation
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Type { get; set; }
        public string City { get; set; }
        [Display(Name = "Area Code")]
        public string AreaCode { get; set; }
        public string Province { get; set; }
        public ICollection<Room> Rooms { get; set; }
        public ICollection<Contact> Contacts { get; set; }
    }
}
