using cloudscribe.Pagination.Models;
using E_NompiloPHC.Interface;
using E_NompiloPHC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace E_NompiloPHC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MedicalReportController : Controller
    {

        private IMedicalReport _medicalReport;
        public MedicalReportController(IMedicalReport medicalReport)
        {
            _medicalReport = medicalReport;
        }
        public IActionResult Index(int pageNumber = 1, int pageSize = 10)
        {
            return View(_medicalReport.GetAll(pageNumber, pageSize));
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var viewModel = _medicalReport.GetMedicalReportById(id);
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Edit(MedicalReportViewModel vm)
        {
            _medicalReport.UpdateMedicalReport(vm);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(MedicalReportViewModel vm)
        {
            _medicalReport.InsertMedicalReport(vm);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            _medicalReport.DeleteMedicalReport(id);
            return RedirectToAction("Index");
        }
    }
}
