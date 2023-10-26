using E_NompiloPHC.Models;

namespace E_NompiloPHC.ViewModels
{
    public class PrescribedMedicineViewModel
    {
        public int Id { get; set; }
	 public Medicine Medicine { get; set; }
        public PatientReport PatientReport { get; set; }
        public PrescribedMedicineViewModel() { }
        public PrescribedMedicineViewModel(PrescribedMedicine model)
        {
            Id = model.Id;
            Medicine = model.Medicine;
            PatientReport = model.PatientReport ;


        }
        public PrescribedMedicine ConvertViewModel(PrescribedMedicineViewModel model)
        {
            return new PrescribedMedicine
            {
                Id = model.Id,
            Medicine = model.Medicine,
            PatientReport = model.PatientReport
            };

        }
    }
}
