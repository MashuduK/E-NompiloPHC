using E_NompiloPHC.Models;

namespace E_NompiloPHC.ViewModels
{
    public class MedicineViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Cost { get; set; }
        public string Description { get; set; }
        public ICollection<MedicalReport> MedicalReports { get; set; }
        public ICollection<PrescribedMedicine> PrescribedMedicine { get; set; }
        public MedicineViewModel() { }
        public MedicineViewModel(Medicine model)
        {
            Id = model.Id;
            Name = model.Name;
            Category = model.Category;
            Cost = model.Cost;
	    Description = model.Description;
            MedicalReports = model.MedicalReports;
            PrescribedMedicine = model.PrescribedMedicine;
        }
        public Medicine ConvertViewModel(MedicineViewModel model)
        {
            return new Medicine
            {
                Id = model.Id,
                Name = model.Name,
            Category = model.Category,
            Cost = model.Cost,
	    Description = model.Description,
            MedicalReports = model.MedicalReports,
            PrescribedMedicine = model.PrescribedMedicine
            };

        }
    }
}
