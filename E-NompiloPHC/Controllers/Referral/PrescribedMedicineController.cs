using cloudscribe.Pagination.Models;
using E_NompiloPHC.Interface;
using E_NompiloPHC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace E_NompiloPHC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PrescribedMedicineController : Controller
    {

        private IPrescribedMedicine _prescribedMedicine;
        public PrescribedMedicineController(IPrescribedMedicine prescribedMedicine)
        {
            _prescribedMedicine = prescribedMedicine;
        }
        public IActionResult Index(int pageNumber = 1, int pageSize = 10)
        {
            return View(_prescribedMedicine.GetAll(pageNumber, pageSize));
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var viewModel = _prescribedMedicine.GetPrescribedMedicineById(id);
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Edit(PrescribedMedicineViewModel vm)
        {
            _prescribedMedicine.UpdatePrescribedMedicine(vm);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(PrescribedMedicineViewModel vm)
        {
            _prescribedMedicine.InsertPrescribedMedicine(vm);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            _prescribedMedicine.DeletePrescribedMedicine(id);
            return RedirectToAction("Index");
        }
    }
}
