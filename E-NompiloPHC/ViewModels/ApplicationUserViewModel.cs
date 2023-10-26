using E_NompiloPHC.Models;

namespace E_NompiloPHC.ViewModels
{
    public class ApplicationUserViewModel
    {
        //public List<ApplicationUser> Doctors { get; set; } = new List<ApplicationUser>();
        //public int Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Address { get; set; }
        public Gender Gender { get; set; }
        public bool IsDoctor { get; set; }
        public string Specialist { get; set; }
        public Department Department { get; set; }
        public ApplicationUserViewModel() { }
        public ApplicationUserViewModel(ApplicationUser user)
        {
            //Id = user.Id;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Address = user.Address;
            Gender = user.Gender;
            IsDoctor = user.IsDoctor;
            Specialist = user.Specialist;
            Department = user.Department;
            Email = user.Email;
            UserName = user.UserName;
        }
        public ApplicationUser ConvertViewModel(ApplicationUserViewModel user)
        {
            return new ApplicationUser
            {
                //Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Address = user.Address,
                Gender = user.Gender,
                IsDoctor = user.IsDoctor,
                Specialist = user.Specialist,
                Department = user.Department,
                Email = user.Email,
                UserName = user.UserName
            };
        }
        public List<ApplicationUser> Doctors { get; set; } = new List<ApplicationUser>();
        public List<ApplicationUser> Patients { get; set; } = new List<ApplicationUser>();
    }
}
