using E_NompiloPHC.Interface;
using E_NompiloPHC.Models;
using E_NompiloPHC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace E_NompiloPHC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BillController : Controller
    {

        private IBill _bill;
        public BillController(IBill bill)
        {
            _bill = bill;
        }
        public IActionResult Index(int pageNumber = 1, int pageSize = 10)
        {
            return View(_bill.GetAll(pageNumber, pageSize));
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var viewModel = _bill.GetBillById(id);
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Edit(BillViewModel vm)
        {
            _bill.UpdateBill(vm);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(BillViewModel vm)
        {
            _bill.InsertBill(vm);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            _bill.DeleteBill(id);
            return RedirectToAction("Index");
        }
    }
}
