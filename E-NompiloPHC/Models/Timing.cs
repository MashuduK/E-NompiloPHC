namespace E_NompiloPHC.Models
{
    public class Timing
    {
        public int Id { get; set; }
        public Guid DoctorId { get; set; }
        public ApplicationUser Doctor { get; set; }
        
        public DateTime ScheduleDate { get; set; }
        public int MorningShiftStartTime { get; set; }
        public int MorningShiftEndTime { get; set; }
        public int NightShiftStartTime { get; set; }
        public int NightShiftEndTime { get; set; }
        public int Duration { get; set; }
        public Status Status { get; set; }
        
    }
}

namespace E_NompiloPHC.Models
{
    public enum Status
    {
        Available, Pending, Confirm
    }
}