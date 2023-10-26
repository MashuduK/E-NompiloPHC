using E_NompiloPHC.Interface;
using E_NompiloPHC.Models;
using E_NompiloPHC.ViewModels;

namespace E_NompiloPHC.Repository
{
    public class TestPriceRepository : ITestPrice
    {
        private IUnitOfWork _unitOfWork;

        public TestPriceRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public PagedResult<TestPriceViewModel> GetAll(int pageNumber, int pageSize)
        {
            var vm = new TestPriceViewModel();
            int totalCount;
            List<TestPriceViewModel> vmList = new List<TestPriceViewModel>();
            try
            {
                int ExcludeRecords = (pageSize * pageNumber) - pageSize;
                var modelList = _unitOfWork.GenericRepository<TestPrice>().GetAll().Skip(ExcludeRecords).Take(pageSize).ToList();
                totalCount = _unitOfWork.GenericRepository<TestPrice>().GetAll().ToList().Count;
                vmList = ConverModelToViewModelList(modelList);
            }
            catch (Exception) { throw; }

            var result = new PagedResult<TestPriceViewModel>
            {
                Data = vmList,
                TotalItems = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
            return result;
        }
        private List<TestPriceViewModel> ConverModelToViewModelList(List<TestPrice> modelList)
        {
            return modelList.Select(x => new TestPriceViewModel(x)).ToList();
        }

        
        public void DeleteTestPrice(int id)
        {
            var model = _unitOfWork.GenericRepository<TestPrice>().GetById(id);
            _unitOfWork.GenericRepository<TestPrice>().Delete(model);
            _unitOfWork.Save();

        }


        public TestPriceViewModel GetTestPriceById(int TestPriceId)
        {
            var model = _unitOfWork.GenericRepository<TestPrice>().GetById(TestPriceId);
            var vm = new TestPriceViewModel(model);
            return vm;
        }

        
        public void InsertTestPrice(TestPriceViewModel testPrice)
        {
            var model = new TestPriceViewModel().ConvertViewModel(testPrice);
            _unitOfWork.GenericRepository<TestPrice>().Add(model);
            _unitOfWork.Save();
        }

        public void UpdateTestPrice(TestPriceViewModel testPrice)
        {
            var model = new TestPriceViewModel().ConvertViewModel(testPrice);
            var ModelById = _unitOfWork.GenericRepository<TestPriceViewModel>().GetById(model.Id);
            ModelById.TestCode = testPrice.TestCode;
            ModelById.Price = testPrice.Price;
            ModelById.Laboratory = testPrice.Laboratory;
            ModelById.Bill = testPrice.Bill;
            _unitOfWork.GenericRepository<TestPriceViewModel>().Update(ModelById);
            _unitOfWork.Save();
        }

        
    }
}
