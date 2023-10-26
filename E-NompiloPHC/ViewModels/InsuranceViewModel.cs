using E_NompiloPHC.Models;

namespace E_NompiloPHC.ViewModels
{
    public class InsuranceViewModel
    {
        public int Id { get; set; }
	public string PolicyNumber { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public ICollection<Bill> Bill { get; set; }
        public InsuranceViewModel() { }
        public InsuranceViewModel(Insurance model)
        {
            Id = model.Id;
            PolicyNumber = model.PolicyNumber;
            StartDate = model.StartDate ;
            EndDate = model.EndDate ;


        }
        public Insurance ConvertViewModel(InsuranceViewModel model)
        {
            return new Insurance 
            {
                Id = model.Id,
            PolicyNumber = model.PolicyNumber,
            StartDate = model.StartDate,
            EndDate = model.EndDate,
            };

        }
    }
}
