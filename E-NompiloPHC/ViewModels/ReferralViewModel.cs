using E_NompiloPHC.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace E_NompiloPHC.ViewModels
{
    public class ReferralViewModel
    {
        public int Id { get; set; }
        public ApplicationUser Doctor { get; set; }
        public ApplicationUser Patient { get; set; }
        public int AppointmentId { get; set; }
        public DateTime CreatedReferral { get; set; } 
        public DateTime ReferralDate { get; set; }  
        public string ReferralReason { get; set; }
        public bool IsCompleted { get; set; }
        public bool IsCanceled { get; set; }
        public DateTime CancelledDate { get; set; }
        public string CancelledReason { get; set; }
        public string Notes { get; set; }



        public ReferralViewModel() { }
        public ReferralViewModel(Referral model)
        {
            Id = model.Id;
            AppointmentId = model.AppointmentId;
            CreatedReferral = model.CreatedReferral;
            ReferralDate = model.ReferralDate;
            ReferralReason = model.ReferralReason;
            IsCompleted = model.IsCompleted;
            IsCanceled = model.IsCanceled;
            CancelledDate = model.CancelledDate;
            CancelledDate = model.CancelledDate;
            Notes = model.Notes;
            Doctor = model.Doctor;
            Patient = model.Patient;

        }
        public Referral ConvertViewModel(ReferralViewModel model)
        {
            return new Referral
            {
                Id = model.Id,
                AppointmentId = model.AppointmentId,
                CreatedReferral = model.CreatedReferral,
                ReferralDate = model.ReferralDate,
                ReferralReason = model.ReferralReason,
                IsCompleted = model.IsCompleted,
                IsCanceled = model.IsCanceled,
                CancelledReason = model.CancelledReason,
                CancelledDate = model.CancelledDate,
                Notes = model.Notes,
                Patient = model.Patient
        };


        }
    }
}
