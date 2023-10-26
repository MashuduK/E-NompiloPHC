using Microsoft.AspNetCore.Mvc;

namespace E_NompiloPHC.Controllers
{
    public class LayoutsController : Controller
    {
        public IActionResult ReferralDashboard()
        {
            return View();
        }
        public IActionResult RefDashboard()
        {
            return View();
        }
    }
}
