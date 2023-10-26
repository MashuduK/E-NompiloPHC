namespace E_NompiloPHC.Models
{
    public class Bill
    {
        public int Id { get; set; }

        public string BillNumber { get; set; }
	public Guid PatientId { get; set; }
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
    }
}