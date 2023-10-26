using cloudscribe.Pagination.Models;
using E_NompiloPHC.Interface;
using E_NompiloPHC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace E_NompiloPHC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PatientReportController : Controller
    {

        private IPatientReport _patientReport;
        public PatientReportController(IPatientReport patientReport)
        {
            _patientReport = patientReport;
        }
        public IActionResult Index(int pageNumber = 1, int pageSize = 10)
        {
            return View(_patientReport.GetAll(pageNumber, pageSize));
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var viewModel = _patientReport.GetPatientReportById(id);
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Edit(PatientReportViewModel vm)
        {
            _patientReport.UpdatePatientReport(vm);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(PatientReportViewModel vm)
        {
            _patientReport.InsertPatientReport(vm);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            _patientReport.DeletePatientReport(id);
            return RedirectToAction("Index");
        }
    }
}
