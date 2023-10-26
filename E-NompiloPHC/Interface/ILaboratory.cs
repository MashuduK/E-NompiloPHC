using E_NompiloPHC.Models;
using E_NompiloPHC.ViewModels;

namespace E_NompiloPHC.Interface
{
    public interface ILaboratory
    {
        PagedResult<LaboratoryViewModel> GetAll(int pageNumber, int pageSize);
        LaboratoryViewModel GetLaboratoryById(int LaboratoryId);
        void UpdateLaboratory(LaboratoryViewModel laboratory);
        void InsertLaboratory(LaboratoryViewModel laboratory);
        void DeleteLaboratory(int id);
    }
}
