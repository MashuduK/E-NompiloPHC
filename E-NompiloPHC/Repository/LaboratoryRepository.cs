using E_NompiloPHC.Interface;
using E_NompiloPHC.Models;
using E_NompiloPHC.ViewModels;

namespace E_NompiloPHC.Repository
{
    public class LaboratoryRepository : ILaboratory
    {
        private IUnitOfWork _unitOfWork;

        public LaboratoryRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public PagedResult<LaboratoryViewModel> GetAll(int pageNumber, int pageSize)
        {
            var vm = new LaboratoryViewModel();
            int totalCount;
            List<LaboratoryViewModel> vmList = new List<LaboratoryViewModel>();
            try
            {
                int ExcludeRecords = (pageSize * pageNumber) - pageSize;
                var modelList = _unitOfWork.GenericRepository<Laboratory>().GetAll().Skip(ExcludeRecords).Take(pageSize).ToList();
                totalCount = _unitOfWork.GenericRepository<Laboratory>().GetAll().ToList().Count;
                vmList = ConverModelToViewModelList(modelList);
            }
            catch (Exception) { throw; }

            var result = new PagedResult<LaboratoryViewModel>
            {
                Data = vmList,
                TotalItems = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
            return result;
        }
        private List<LaboratoryViewModel> ConverModelToViewModelList(List<Laboratory> modelList)
        {
            return modelList.Select(x => new LaboratoryViewModel(x)).ToList();
        }


        public void DeleteLaboratory(int id)
        {
            var model = _unitOfWork.GenericRepository<Laboratory>().GetById(id);
            _unitOfWork.GenericRepository<Laboratory>().Delete(model);
            _unitOfWork.Save();

        }


        public LaboratoryViewModel GetLaboratoryById(int LaboratoryId)
        {
            var model = _unitOfWork.GenericRepository<Laboratory>().GetById(LaboratoryId);
            var vm = new LaboratoryViewModel(model);
            return vm;
        }


        public void InsertLaboratory(LaboratoryViewModel laboratory)
        {
            var model = new LaboratoryViewModel().ConvertViewModel(laboratory);
            _unitOfWork.GenericRepository<Laboratory>().Add(model);
            _unitOfWork.Save();
        }

        public void UpdateLaboratory(LaboratoryViewModel laboratory)
        {
            var model = new LaboratoryViewModel().ConvertViewModel(laboratory);
            var ModelById = _unitOfWork.GenericRepository<Laboratory>().GetById(model.Id);
            ModelById.LabNumber = laboratory.LabNumber;
            ModelById.Patient = laboratory.Patient;
            ModelById.TestType = laboratory.TestType;
            ModelById.TestCode = laboratory.TestCode;
            ModelById.Weight = laboratory.Weight;
            ModelById.Height = laboratory.Height;
            ModelById.BloodPressure = laboratory.BloodPressure;
            ModelById.Temperature = laboratory.Temperature;
            ModelById.TestResult = laboratory.TestResult;
            _unitOfWork.GenericRepository<Laboratory>().Update(ModelById);
            _unitOfWork.Save();
        }
    }
}
