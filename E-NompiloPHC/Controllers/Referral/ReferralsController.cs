using cloudscribe.Pagination.Models;
using E_NompiloPHC.Interface;
using E_NompiloPHC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace E_NompiloPHC.Areas.Admin.Controllers
{
    //[Area("Doctor")]
    public class ReferralsController : Controller
    {

        private IReferral _referral;
        public ReferralsController(IReferral referral)
        {
            _referral = referral;
        }
        public IActionResult Index(int pageNumber = 1, int pageSize = 10)
        {
            return View(_referral.GetAll(pageNumber, pageSize));
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var viewModel = _referral.GetReferralById(id);
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Edit(ReferralViewModel vm)
        {
            _referral.UpdateReferral(vm);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(ReferralViewModel vm)
        {
            _referral.InsertReferral(vm);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            _referral.DeleteReferral(id);
            return RedirectToAction("Index");
        }
    }
}
