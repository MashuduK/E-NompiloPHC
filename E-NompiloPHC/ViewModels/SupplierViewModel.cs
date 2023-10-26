using E_NompiloPHC.Models;

namespace E_NompiloPHC.ViewModels
{
    public class MedicalReportModel
    {
        public int Id { get; set; }
	public string Company { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Province { get; set; }
        public ICollection<MedicalReport> MedicalReport { get; set; }
        public MedicalReportModel() { }
        public MedicalReportModel(Supplier model)
        {
            Id = model.Id;
            Company = model.Company;
            Email = model.Email ;
            Address = model.Address ;
            PhoneNumber = model.PhoneNumber ;
            Province = model.Province;


        }
        public Supplier ConvertViewModel(MedicalReportModel model)
        {
            return new Supplier
            {
                Id = model.Id,
            Company = model.Company,
            Email = model.Email,
            Address = model.Address,
            PhoneNumber = model.PhoneNumber,
            Province = model.Province,
            };

        }
    }
}
