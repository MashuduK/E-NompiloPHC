using E_NompiloPHC.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace E_NompiloPHC.ViewModels
{
    public class TimingViewModel
    {
        public int Id { get; set; }
        public ApplicationUser Doctor { get; set; }
        public DateTime ScheduleDate { get; set; }
        public int MorningShiftStartTime { get; set; }
        public int MorningShiftEndTime { get; set; }
        public int NightShiftStartTime { get; set; }
        public int NightShiftEndTime { get; set; }
        public int Duration { get; set; }
        public Status Status { get; set; }
        List<SelectListItem> morningShiftStartTime = new List<SelectListItem>();
        List<SelectListItem> morningShiftEndTime = new List<SelectListItem>();
        List<SelectListItem> nightShiftStartTime = new List<SelectListItem>();
        List<SelectListItem> nightShiftEndTime = new List<SelectListItem>();


        public TimingViewModel() { }
        public TimingViewModel(Timing model)
        {
            Id = model.Id;
            ScheduleDate = model.ScheduleDate;
            MorningShiftStartTime = model.MorningShiftStartTime;
            MorningShiftEndTime = model.MorningShiftEndTime;
            NightShiftStartTime = model.NightShiftStartTime;
            NightShiftEndTime = model.NightShiftEndTime;
            Duration = model.Duration;
            Status = model.Status;
            Doctor = model.Doctor;

        }
        public Timing ConvertViewModel(TimingViewModel model)
        {
            return new Timing
            {
                Id = model.Id,
                ScheduleDate = model.ScheduleDate,
                MorningShiftStartTime = model.MorningShiftStartTime,
                MorningShiftEndTime = model.MorningShiftEndTime,
                NightShiftStartTime = model.NightShiftStartTime,
                NightShiftEndTime = model.NightShiftEndTime,
                Duration = model.Duration,
                Status = model.Status,
                Doctor = model.Doctor
            };


        }
    }
}
