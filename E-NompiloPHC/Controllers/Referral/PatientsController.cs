using E_NompiloPHC.Interface;
using E_NompiloPHC.Models;
using E_NompiloPHC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

namespace E_NompiloPHC.Areas.Doctor.Controllers
{
    [Area("Patient")]
    public class PatientsController : Controller
    {
        private readonly IPatient _patient;
        public PatientsController(IPatient patient)
        {
            _patient = patient;
        }
        public IActionResult Index(int pageNumber = 1, int pageSize = 10)
        {
            return View(_patient.GetAll(pageNumber, pageSize));
        }
    }
}
