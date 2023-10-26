using System.ComponentModel.DataAnnotations;

namespace E_NompiloPHC.Models
{
    public class Referral
    {
        public int Id { get; set; }
        public Guid DoctorId { get; set; }
        public ApplicationUser Doctor { get; set; }
        public Guid PatientId { get; set; }
        public ApplicationUser Patient { get; set; }

        public int AppointmentId { get; set; }
        public Appointment Appointment { get; set; }

        public DateTime CreatedReferral { get; set; }
        [Display(Name = "Referral Date")]
        public DateTime ReferralDate { get; set; }
        [Display(Name = "Referral Reason")]
        public string ReferralReason { get; set; }
        public bool IsCompleted { get; set; }
        public bool IsCanceled { get; set; }
        public DateTime CancelledDate { get; set; }
        public string CancelledReason { get; set; }
        public string Notes { get; set; }
    }
}
