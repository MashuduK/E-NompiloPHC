using E_NompiloPHC.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace E_NompiloPHC.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Referral> Referrals { get; set; }
        public DbSet<Departmenty> Departments { get; set; }

        public DbSet<HospitalInformation> HospitalInformation { get; set; }
        public DbSet<Insurance> Insurances { get; set; }

        public DbSet<Laboratory> Laboratory { get; set; }
        public DbSet<MedicalReport> MedicalReports { get; set; }
        public DbSet<PatientReport> PatientReports { get; set; }
        public DbSet<PrescribedMedicine> PrescribedMedicines { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<TestPrice> TestPrices { get; set; }

    }
}