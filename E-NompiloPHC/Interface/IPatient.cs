using E_NompiloPHC.Models;
using E_NompiloPHC.ViewModels;

namespace E_NompiloPHC.Interface
{
    public interface IPatient
    {
        
        PagedResult<TimingViewModel> GetAll(int pageNumber, int pageSize);
        IEnumerable<TimingViewModel> GetAll();
        TimingViewModel GetTimingById(int TimingId);
        void UpdateTiming(TimingViewModel timing);
        void AddTiming(TimingViewModel timing);
        void DeleteTiming(int TimingId);

    
    }
}
