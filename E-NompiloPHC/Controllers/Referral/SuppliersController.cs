using cloudscribe.Pagination.Models;
using E_NompiloPHC.Interface;
using E_NompiloPHC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace E_NompiloPHC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SuppliersController : Controller
    {

        private ISupplier _supplier;
        public SuppliersController(ISupplier supplier)
        {
            _supplier = supplier;
        }
        public IActionResult Index(int pageNumber = 1, int pageSize = 10)
        {
            return View(_supplier.GetAll(pageNumber, pageSize));
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var viewModel = _supplier.GetSupplierById(id);
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Edit(MedicalReportModel vm)
        {
            _supplier.UpdateSupplier(vm);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(MedicalReportModel vm)
        {
            _supplier.InsertSupplier(vm);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            _supplier.DeleteSupplier(id);
            return RedirectToAction("Index");
        }
    }
}
