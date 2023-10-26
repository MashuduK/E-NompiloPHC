using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace E_NompiloPHC.Models
{
    public class ApplicationUser : IdentityUser
    {
        //public int Id {  get; set; }
        [Display(Name="Name")]
        public string FirstName { get; set; }
        [Display(Name="Surname")]
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public DateTime DOB { get; set; }
        public string Address { get; set; }
        public string Nationality { get; set; }
        public string Specialist { get; set; }
        public bool IsDoctor { get; set; }
        public string PictureUrl { get; set; }
        public Department Department { get; set; }
        [NotMapped]
        public ICollection<Appointment> Appointments { get; set; }
        [NotMapped]
        public ICollection<PatientReport> PatientReports { get; set; }
    }

}
namespace E_NompiloPHC.Models
{

    public enum Gender
    {
        Male, Female, Other
    }

}
namespace E_NompiloPHC.Models
{

    public enum Department
    {
        Pediatrics, Obstetetrics, Surgery, Orthopedics, Neurology, Psychiatry, Cardiology, Dermatology, Ophthalmology, Radiology, Anesthesiology, Oncology, Nephrology, Urology, Gastroenterology, Endocrinology, Pulmonology, Rheumatology
    }

}