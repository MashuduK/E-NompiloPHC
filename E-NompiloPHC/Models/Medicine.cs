namespace E_NompiloPHC.Models
{
    public class Medicine
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Category { get; set; }
        public string Cost { get; set; }
        public string Description { get; set; }
        public ICollection<MedicalReport> MedicalReports { get; set; }
        public ICollection<PrescribedMedicine> PrescribedMedicine { get; set; }
    }
}
namespace Proj1.Models
{
    public enum Category
    {
        Herbal, Homeopathy, Antibiotics, Analgesics, BetaBlocker, Benzodiazepine, Antidepressants, Paracetamol, Asprin, AnticogulantsStimulant, Barbiturates, Omeprazole, Antifungal, Antihistamines
    }
}