using E_NompiloPHC.Models;

namespace E_NompiloPHC.ViewModels
{
    public class LaboratoryViewModel
    {
        public int Id { get; set; }
	public string LabNumber { get; set; }
        public ApplicationUser Patient { get; set; }
        public string TestType { get; set; }
        public string TestCode { get; set; }
        public int Weight { get; set; }

        public int Height { get; set; }
        public int BloodPressure { get; set; }
        public int Temperature { get; set; }
        public string TestResult { get; set; }
        public LaboratoryViewModel() { }
        public LaboratoryViewModel(Laboratory model)
        {
            Id = model.Id;
            LabNumber = model.LabNumber;
            Patient = model.Patient ;
            TestType = model.TestType ;
            TestCode = model.TestCode ;
            Weight = model.Weight;
	    Height = model.Height ;
            BloodPressure = model.BloodPressure ;
            TestResult = model.TestResult;
           


        }
        public Laboratory ConvertViewModel(LaboratoryViewModel model)
        {
            return new Laboratory
            {
                Id = model.Id,
            LabNumber = model.LabNumber,
            Patient = model.Patient,
            TestType = model.TestType,
            TestCode = model.TestCode,
            Weight = model.Weight,
	    Height = model.Height,
            BloodPressure = model.BloodPressure,
            TestResult = model.TestResult,
            };

        }
    }
}
