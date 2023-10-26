using E_NompiloPHC.Interface;
using E_NompiloPHC.Models;
using E_NompiloPHC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace E_NompiloPHC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MedicineController : Controller
    {

        private IMedicine _medicine;
        public MedicineController(IMedicine medicine)
        {
            _medicine = medicine;
        }
        public IActionResult Index(int pageNumber = 1, int pageSize = 10)
        {
            return View(_medicine.GetAll(pageNumber, pageSize));
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var viewModel = _medicine.GetMedicineById(id);
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Edit(MedicineViewModel vm)
        {
            _medicine.UpdateMedicine(vm);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(MedicineViewModel vm)
        {
            _medicine.InsertMedicine(vm);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            _medicine.DeleteMedicine(id);
            return RedirectToAction("Index");
        }
    }
}
