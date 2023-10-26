using E_NompiloPHC.Models;
using E_NompiloPHC.ViewModels;

namespace E_NompiloPHC.Interface
{
    public interface ITestPrice
    {
        PagedResult<TestPriceViewModel> GetAll(int pageNumber, int pageSize);
        TestPriceViewModel GetTestPriceById(int TestPriceId);
        void UpdateTestPrice(TestPriceViewModel testPrice);
        void InsertTestPrice(TestPriceViewModel testPrice);
        void DeleteTestPrice(int id);
    }
}
