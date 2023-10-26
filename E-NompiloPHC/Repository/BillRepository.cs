using E_NompiloPHC.Interface;
using E_NompiloPHC.Models;
using E_NompiloPHC.ViewModels;

namespace E_NompiloPHC.Repository
{
    public class BillRepository: IBill
    {
        private IUnitOfWork _unitOfWork;

        public BillRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public PagedResult<BillViewModel> GetAll(int pageNumber, int pageSize)
        {
            var vm = new BillViewModel();
            int totalCount;
            List<BillViewModel> vmList = new List<BillViewModel>();
            try
            {
                int ExcludeRecords = (pageSize * pageNumber) - pageSize;
                var modelList = _unitOfWork.GenericRepository<Bill>().GetAll().Skip(ExcludeRecords).Take(pageSize).ToList();
                totalCount = _unitOfWork.GenericRepository<Bill>().GetAll().ToList().Count;
                vmList = ConverModelToViewModelList(modelList);
            }
            catch (Exception) { throw; }

            var result = new PagedResult<BillViewModel>
            {
                Data = vmList,
                TotalItems = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
            return result;
        }
        private List<BillViewModel> ConverModelToViewModelList(List<Bill> modelList)
        {
            return modelList.Select(x => new BillViewModel(x)).ToList();
        }

        
        public void DeleteBill(int id)
        {
            var model = _unitOfWork.GenericRepository<Bill>().GetById(id);
            _unitOfWork.GenericRepository<Bill>().Delete(model);
            _unitOfWork.Save();

        }


        public BillViewModel GetBillById(int BillId)
        {
            var model = _unitOfWork.GenericRepository<Bill>().GetById(BillId);
            var vm = new BillViewModel(model);
            return vm;
        }

        
        public void InsertBill(BillViewModel bill)
        {
            var model = new BillViewModel().ConvertViewModel(bill);
            _unitOfWork.GenericRepository<Bill>().Add(model);
            _unitOfWork.Save();
        }

        public void UpdateBill(BillViewModel bill)
        {
            var model = new BillViewModel().ConvertViewModel(bill);
            var ModelById = _unitOfWork.GenericRepository<Bill>().GetById(model.Id);
	    ModelById.BillNumber = bill.BillNumber;
            ModelById.Patient = bill.Patient;
            ModelById.Insurance  = bill.Insurance ;
            ModelById.DoctorCharge  = bill.DoctorCharge ;
            ModelById.MedicineCharge = bill.MedicineCharge ;
 	    ModelById.RoomCharge = bill.RoomCharge;
            ModelById.SessionCharge  = bill.SessionCharge ;
            ModelById.NoOfDays  = bill.NoOfDays ;
            ModelById.NursingCharge  = bill.NursingCharge ;
 	    ModelById.LabCharge = bill.LabCharge;
            ModelById.Advance  = bill.Advance ;
            ModelById.TotalBill = bill.TotalBill ;
            
            _unitOfWork.GenericRepository<Bill>().Update(ModelById);
            _unitOfWork.Save();
        }

        
    }
}
