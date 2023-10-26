using E_NompiloPHC.Interface;
using E_NompiloPHC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace E_NompiloPHC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RoomsController : Controller
    {
        private IHospitalInformation _hospitalInformation;
        private IRoom _room;
        public RoomsController(IRoom room, IHospitalInformation hospitalInformation)
        {
            _room = room;
            _hospitalInformation = hospitalInformation;
        }
        public IActionResult Index(int pageNumber = 1, int pageSize = 10)
        {
            return View(_room.GetAll(pageNumber, pageSize));
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            //ViewBag.hospital = new SelectList(_hospitalInformation.GetAll(), "Id", "Name");
            var viewModel = _room.GetRoomById(id);
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Edit(RoomViewModel vm)
        {
            _room.UpdateRoom(vm);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Create()
        {
            //ViewBag.hospital = new SelectList(_hospitalInformation.GetAll(), "Id", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult Create(RoomViewModel vm)
        {
            _room.InsertRoom(vm);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            _room.DeleteRoom(id);
            return RedirectToAction("Index");
        }
    }
}
