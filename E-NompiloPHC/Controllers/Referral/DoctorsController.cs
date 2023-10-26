using E_NompiloPHC.Interface;
using E_NompiloPHC.Models;
using E_NompiloPHC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

namespace E_NompiloPHC.Areas.Doctor.Controllers
{
    [Area("Doctor")]
    public class DoctorsController : Controller
    {
        private readonly IDoctor _doctor;
        public DoctorsController(IDoctor doctor)
        {
            _doctor = doctor;
        }
        public IActionResult Index(int pageNumber = 1, int pageSize = 10)
        {
            return View(_doctor.GetAll(pageNumber, pageSize));
        }
        [HttpGet]
        public IActionResult AddTiming()
        {
            Timing timing = new Timing();
            List<SelectListItem> morningShiftStart = new List<SelectListItem>();
            List<SelectListItem> morningShiftEnd = new List<SelectListItem>();
            List<SelectListItem> nightShiftStart = new List<SelectListItem>();
            List<SelectListItem> nightShiftEnd = new List<SelectListItem>();
            for (int i = 1; i <= 11; i++)
            {
                morningShiftStart.Add(new SelectListItem { Text = i.ToString(), Value = i.ToString() });
            }
            for (int i = 1; i <= 13; i++)
            {
                morningShiftEnd.Add(new SelectListItem { Text = i.ToString(), Value = i.ToString() });
            }
            for (int i = 1; i <= 16; i++)
            {
                nightShiftStart.Add(new SelectListItem { Text = i.ToString(), Value = i.ToString() });
            }
            for (int i = 1; i <= 18; i++)
            {
                nightShiftEnd.Add(new SelectListItem { Text = i.ToString(), Value = i.ToString() });
            }
            ViewBag.morningStart = new SelectList(morningShiftStart, "Value", "Text");
            ViewBag.morningEnd = new SelectList(morningShiftEnd, "Value", "Text");
            ViewBag.evenStart = new SelectList(nightShiftStart, "Value", "Text");
            ViewBag.evenEnd = new SelectList(nightShiftEnd, "Value", "Text");
            TimingViewModel vm = new TimingViewModel();
            vm.ScheduleDate = DateTime.Now;
            vm.ScheduleDate = vm.ScheduleDate.AddDays(1);
            return View();
        }
        [HttpPost]
        public IActionResult AddTiming(TimingViewModel vm)
        {
            var ClaimsIdentity = (ClaimsIdentity)User.Identity;
            var Claims = ClaimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            if (Claims != null)
            {
                vm.Doctor.Id = Claims.Value;
                _doctor.AddTiming(vm);

            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var viewModel = _doctor.GetTimingById(id);
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Edit(TimingViewModel vm)
        {
            _doctor.UpdateTiming(vm);
            return RedirectToAction("Index");
        }
    }
}
