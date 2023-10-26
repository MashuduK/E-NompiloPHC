using cloudscribe.Pagination.Models;
using E_NompiloPHC.Interface;
using E_NompiloPHC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace E_NompiloPHC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LaboratoriesController : Controller
    {

        private ILaboratory _laboratory;
        public LaboratoriesController(ILaboratory laboratory)
        {
            _laboratory = laboratory;
        }
        public IActionResult Index(int pageNumber = 1, int pageSize = 10)
        {
            return View(_laboratory.GetAll(pageNumber, pageSize));
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var viewModel = _laboratory.GetLaboratoryById(id);
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Edit(LaboratoryViewModel vm)
        {
            _laboratory.UpdateLaboratory(vm);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(LaboratoryViewModel vm)
        {
            _laboratory.InsertLaboratory(vm);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            _laboratory.DeleteLaboratory(id);
            return RedirectToAction("Index");
        }
    }
}
