using E_NompiloPHC.Interface;
using E_NompiloPHC.Models;
using E_NompiloPHC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace E_NompiloPHC.Controllers
{
    [Area("Admin")]
    public class TestPriceController : Controller
    {
        private ITestPrice _testPrice;
        public TestPriceController(ITestPrice testPrice)
        {
            _testPrice = testPrice;
        }
        public IActionResult Index(int pageNumber = 1, int pageSize = 10)
        {
            return View(_testPrice.GetAll(pageNumber, pageSize));
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var viewModel = _testPrice.GetTestPriceById(id);
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Edit(TestPriceViewModel vm)
        {
            _testPrice.UpdateTestPrice(vm);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(TestPriceViewModel vm)
        {
            _testPrice.InsertTestPrice(vm);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            _testPrice.DeleteTestPrice(id);
            return RedirectToAction("Index");
        }

    }
}
