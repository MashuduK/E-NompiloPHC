using E_NompiloPHC.Models;

namespace E_NompiloPHC.ViewModels
{
    public class TestPriceViewModel
    {
        public int Id { get; set; }

        public string TestCode { get; set; }
        public decimal Price { get; set; }
        public Laboratory Laboratory { get; set; }
        public Bill Bill { get; set; }
        public TestPriceViewModel() { }
        public TestPriceViewModel(TestPrice model)
        {
            Id = model.Id;
            TestCode = model.TestCode;
            Price = model.Price;
            Laboratory = model.Laboratory;
            Bill = model.Bill;
           
        }
        public TestPrice ConvertViewModel(TestPriceViewModel model)
        {
            return new TestPrice
            {
                Id = model.Id,
                TestCode = model.TestCode,
                Price = model.Price,
                Laboratory = model.Laboratory,
                Bill = model.Bill,
              
            };

        }
    }
}
