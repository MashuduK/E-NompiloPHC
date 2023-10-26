using E_NompiloPHC.Interface;
using E_NompiloPHC.Models;
using E_NompiloPHC.ViewModels;

namespace E_NompiloPHC.Repository
{
    public class PrescribedMedicineRepository: IPrescribedMedicine
    {
        private IUnitOfWork _unitOfWork;

        public PrescribedMedicineRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public PagedResult<PrescribedMedicineViewModel> GetAll(int pageNumber, int pageSize)
        {
            var vm = new PrescribedMedicineViewModel();
            int totalCount;
            List<PrescribedMedicineViewModel> vmList = new List<PrescribedMedicineViewModel>();
            try
            {
                int ExcludeRecords = (pageSize * pageNumber) - pageSize;
                var modelList = _unitOfWork.GenericRepository<PrescribedMedicine>().GetAll().Skip(ExcludeRecords).Take(pageSize).ToList();
                totalCount = _unitOfWork.GenericRepository<PrescribedMedicine>().GetAll().ToList().Count;
                vmList = ConverModelToViewModelList(modelList);
            }
            catch (Exception) { throw; }

            var result = new PagedResult<PrescribedMedicineViewModel>
            {
                Data = vmList,
                TotalItems = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
            return result;
        }
        private List<PrescribedMedicineViewModel> ConverModelToViewModelList(List<PrescribedMedicine> modelList)
        {
            return modelList.Select(x => new PrescribedMedicineViewModel(x)).ToList();
        }

        
        public void DeletePrescribedMedicine(int id)
        {
            var model = _unitOfWork.GenericRepository<Supplier>().GetById(id);
            _unitOfWork.GenericRepository<Supplier>().Delete(model);
            _unitOfWork.Save();

        }


        public PrescribedMedicineViewModel GetPrescribedMedicineById(int PrescribedMedicineId)
        {
            var model = _unitOfWork.GenericRepository<PrescribedMedicine>().GetById(PrescribedMedicineId);
            var vm = new PrescribedMedicineViewModel(model);
            return vm;
        }

        
        public void InsertPrescribedMedicine(PrescribedMedicineViewModel PrescribedMedicine)
        {
            var model = new PrescribedMedicineViewModel().ConvertViewModel(PrescribedMedicine);
            _unitOfWork.GenericRepository<PrescribedMedicine>().Add(model);
            _unitOfWork.Save();
        }

        public void UpdatePrescribedMedicine(PrescribedMedicineViewModel PrescribedMedicine)
        {
            var model = new PrescribedMedicineViewModel().ConvertViewModel(PrescribedMedicine);
            var ModelById = _unitOfWork.GenericRepository<PrescribedMedicine>().GetById(model.Id);
	    ModelById.Medicine  = PrescribedMedicine.Medicine;
            ModelById.PatientReport = PrescribedMedicine.PatientReport;

            _unitOfWork.GenericRepository<PrescribedMedicine>().Update(ModelById);
            _unitOfWork.Save();
        }

        
    }
}
