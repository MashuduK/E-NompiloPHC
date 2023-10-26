using cloudscribe.Pagination.Models;
using E_NompiloPHC.Interface;
using E_NompiloPHC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace E_NompiloPHC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HospitalsController : Controller
    {

        private IHospitalInformation _hospitalInformation;
        public HospitalsController(IHospitalInformation hospitalInformation)
        {
            _hospitalInformation = hospitalInformation;
        }
        public IActionResult Index(int pageNumber = 1, int pageSize = 10)
        {
            return View(_hospitalInformation.GetAll(pageNumber, pageSize));
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var viewModel = _hospitalInformation.GetHospitalById(id);
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Edit(HospitalInformationViewModel vm)
        {
            _hospitalInformation.UpdateHospitalInformation(vm);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(HospitalInformationViewModel vm)
        {
            _hospitalInformation.InsertHospitalInformation(vm);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            _hospitalInformation.DeleteHospitalInformation(id);
            return RedirectToAction("Index");
        }
    }
}
