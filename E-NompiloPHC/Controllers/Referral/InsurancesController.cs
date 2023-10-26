using cloudscribe.Pagination.Models;
using E_NompiloPHC.Interface;
using E_NompiloPHC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace E_NompiloPHC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class InsurancesController : Controller
    {

        private IInsurance _insurance;
        public InsurancesController(IInsurance insurance)
        {
            _insurance = insurance;
        }
        public IActionResult Index(int pageNumber = 1, int pageSize = 10)
        {
            return View(_insurance.GetAll(pageNumber, pageSize));
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var viewModel = _insurance.GetInsuranceById(id);
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Edit(InsuranceViewModel vm)
        {
            _insurance.UpdateInsurance(vm);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(InsuranceViewModel vm)
        {
            _insurance.InsertInsurance(vm);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            _insurance.DeleteInsurance(id);
            return RedirectToAction("Index");
        }
    }
}
