using E_NompiloPHC.Models;

namespace E_NompiloPHC.ViewModels
{
    public class PatientReportViewModel
    {
        public int Id { get; set; }
	public string Diagnose { get; set; }
        public Guid DoctorId { get; set; }
        public ApplicationUser Doctor { get; set; }
	public Guid PatientId { get; set; }
        public ApplicationUser Patient { get; set; }
        public ICollection<PrescribedMedicine> PrescribedMedicine { get; set; }
        public PatientReportViewModel() { }
        public PatientReportViewModel(PatientReport model)
        {
            Id = model.Id;
            Diagnose = model.Diagnose;
            Doctor = model.Doctor ;
            Patient = model.Patient ;
            PrescribedMedicine = model.PrescribedMedicine ;


        }
        public PatientReport ConvertViewModel(PatientReportViewModel model)
        {
            return new PatientReport
            {
                Id = model.Id,
            Diagnose = model.Diagnose,
            Doctor = model.Doctor,
            Patient = model.Patient,
            PrescribedMedicine = model.PrescribedMedicine,
            };

        }
    }
}
