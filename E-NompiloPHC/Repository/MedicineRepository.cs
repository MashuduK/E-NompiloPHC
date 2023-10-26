using E_NompiloPHC.Interface;
using E_NompiloPHC.Models;
using E_NompiloPHC.ViewModels;

namespace E_NompiloPHC.Repository
{
    public class MedicineRepository: IMedicine
    {
        private IUnitOfWork _unitOfWork;

        public MedicineRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public PagedResult<MedicineViewModel> GetAll(int pageNumber, int pageSize)
        {
            var vm = new MedicineViewModel();
            int totalCount;
            List<MedicineViewModel> vmList = new List<MedicineViewModel>();
            try
            {
                int ExcludeRecords = (pageSize * pageNumber) - pageSize;
                var modelList = _unitOfWork.GenericRepository<Medicine>().GetAll().Skip(ExcludeRecords).Take(pageSize).ToList();
                totalCount = _unitOfWork.GenericRepository<Medicine>().GetAll().ToList().Count;
                vmList = ConverModelToViewModelList(modelList);
            }
            catch (Exception) { throw; }

            var result = new PagedResult<MedicineViewModel>
            {
                Data = vmList,
                TotalItems = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
            return result;
        }
        private List<MedicineViewModel> ConverModelToViewModelList(List<Medicine> modelList)
        {
            return modelList.Select(x => new MedicineViewModel(x)).ToList();
        }


        public void DeleteMedicine(int id)
        {
            var model = _unitOfWork.GenericRepository<Medicine>().GetById(id);
            _unitOfWork.GenericRepository<Medicine>().Delete(model);
            _unitOfWork.Save();

        }


        public MedicineViewModel GetMedicineById(int RoomId)
        {
            var model = _unitOfWork.GenericRepository<Medicine>().GetById(RoomId);
            var vm = new MedicineViewModel(model);
            return vm;
        }


        public void InsertMedicine(MedicineViewModel Medicine)
        {
            var model = new MedicineViewModel().ConvertViewModel(Medicine);
            _unitOfWork.GenericRepository<Medicine>().Add(model);
            _unitOfWork.Save();
        }

        public void UpdateMedicine(MedicineViewModel Medicine)
        {
            var model = new MedicineViewModel().ConvertViewModel(Medicine);
            var ModelById = _unitOfWork.GenericRepository<Medicine>().GetById(model.Id);
            ModelById.Name  = Medicine.Name;
            ModelById.Category = Medicine.Category;
            ModelById.Cost = Medicine.Cost;
	    ModelById.Description = Medicine.Description;
            ModelById.MedicalReports = Medicine.MedicalReports;
            ModelById.PrescribedMedicine = Medicine.PrescribedMedicine;


            _unitOfWork.GenericRepository<Medicine>().Update(ModelById);
            _unitOfWork.Save();
        }

        
    }
}
