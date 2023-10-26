using E_NompiloPHC.Models;

namespace E_NompiloPHC.ViewModels
{
    public class MedicalReportViewModel
    {
        public int Id { get; set; }
	public Supplier Supplier { get; set; }
        public Medicine Medicine { get; set; }
        public string Company { get; set; }
        public int Quantity { get; set; }
        public DateTime ProductionDate { get; set; }
        public DateTime ExpireTime { get; set; }
        public string Country { get; set; }
        public MedicalReportViewModel() { }
        public MedicalReportViewModel(MedicalReport model)
        {
            Id = model.Id;
            Supplier = model.Supplier;
            Medicine = model.Medicine ;
            Company = model.Company ;
            Quantity = model.Quantity ;
            ProductionDate = model.ProductionDate;
	    ExpireTime = model.ExpireTime ;
            Country  = model.Country  ;


        }
        public MedicalReport ConvertViewModel(MedicalReportViewModel model)
        {
            return new MedicalReport
            {
                Id = model.Id,
            Supplier = model.Supplier,
            Medicine = model.Medicine,
            Company = model.Company,
            Quantity = model.Quantity,
            ProductionDate = model.ProductionDate,
	    ExpireTime = model.ExpireTime,
            Country  = model.Country,
            };

        }
    }
}
