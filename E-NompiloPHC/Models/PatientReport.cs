namespace E_NompiloPHC.Models
{
    public class PatientReport
    {
        public int Id { get; set; }
	 public Guid DoctorId { get; set; }
   public ApplicationUser Doctor { get; set; }
        public string Diagnose { get; set; }
        public Guid PatientId { get; set; }
     
        public ApplicationUser Patient { get; set; }
        public ICollection<PrescribedMedicine> PrescribedMedicine { get; set; }
    }
}