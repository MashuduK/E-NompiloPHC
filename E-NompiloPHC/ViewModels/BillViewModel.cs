using E_NompiloPHC.Models;

namespace E_NompiloPHC.ViewModels
{
    public class BillViewModel
    {
        public int Id { get; set; }
	public string BillNumber { get; set; }
	public Guid ApplicationId { get; set;  }
        public ApplicationUser Patient { get; set; }
        public Insurance Insurance { get; set; }
        public int DoctorCharge { get; set; }
        public decimal MedicineCharge { get; set; }
        public decimal RoomCharge { get; set; }
        public decimal SessionCharge { get; set; }
        public int NoOfDays { get; set; }

        public int NursingCharge { get; set; }
        public string LabCharge { get; set; }
        public decimal Advance { get; set; }
        public decimal TotalBill { get; set; }
        public BillViewModel() { }
        public BillViewModel(Bill model)
        {
            Id = model.Id;
            BillNumber = model.BillNumber;
            Patient = model.Patient ;
            Insurance = model.Insurance ;
            DoctorCharge = model.DoctorCharge ;
            MedicineCharge = model.MedicineCharge;
	    MedicineCharge = model.MedicineCharge;
            RoomCharge = model.RoomCharge ;
            SessionCharge = model.SessionCharge ;
            NoOfDays = model.NoOfDays ;
            NursingCharge = model.NursingCharge;
	    LabCharge = model.LabCharge;
            Advance = model.Advance ;
            TotalBill = model.TotalBill ;
            

        }
        public Bill ConvertViewModel(BillViewModel model)
        {
            return new Bill
            {
                Id = model.Id,
            BillNumber = model.BillNumber,
            Patient = model.Patient,
            Insurance = model.Insurance,
            DoctorCharge = model.DoctorCharge,
            MedicineCharge = model.MedicineCharge,
            RoomCharge = model.RoomCharge,
            SessionCharge = model.SessionCharge,
            NoOfDays = model.NoOfDays,
            NursingCharge = model.NursingCharge,
	    LabCharge = model.LabCharge,
            Advance = model.Advance,
            TotalBill = model.TotalBill,
            };

        }
    }
}
