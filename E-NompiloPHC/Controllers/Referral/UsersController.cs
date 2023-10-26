using E_NompiloPHC.Interface;
using E_NompiloPHC.Models;
using E_NompiloPHC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace E_NompiloPHC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UsersController : Controller
    {

        private IApplicationUser _user;
        public UsersController(IApplicationUser user)
        {
            _user = user;
        }
        public IActionResult Index(int pageNumber = 1, int pageSize = 10)
        {
            return View(_user.GetAll(pageNumber, pageSize));
        }
        public IActionResult AllDoctors(int pageNumber = 1, int pageSize = 10)
        {
            return View(_user.GetAllDoctor(pageNumber, pageSize));
        }
        //[HttpGet]
        //public IActionResult Edit(int id)
        //{
        //    var viewModel = _user.GetContactById(id);
        //    return View(viewModel);
        //}
        //[HttpPost]
        //public IActionResult Edit(ContactViewModel vm)
        //{
        //    _contact.UpdateContact(vm);
        //    return RedirectToAction("Index");
        //}
        //[HttpGet]
        //public IActionResult Create()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public IActionResult Create(ContactViewModel vm)
        //{
        //    _contact.InsertContact(vm);
        //    return RedirectToAction("Index");
        //}
        //public IActionResult Delete(int id)
        //{
        //    _contact.DeleteContact(id);
        //    return RedirectToAction("Index");
        //}
    }
}
