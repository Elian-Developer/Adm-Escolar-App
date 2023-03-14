using AdmEscolar.Business.Interfaces.Services;
using AdmEscolar.Business.ViewModels.Classrooms;
using Microsoft.AspNetCore.Mvc;

namespace Adm._Escolar.Controllers
{
    public class ClassroomController : Controller
    {
        private readonly IClassroomsService _classroomsService;
        public ClassroomController(IClassroomsService classroomsService)
        {
            _classroomsService = classroomsService;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _classroomsService.GetAllViewModel());
        }

        public IActionResult Create()
        {
            SaveClassroomViewModel vm = new();
            return View("SaveClassroom",  vm);
        }

        [HttpPost]
        public async Task<IActionResult> Create(SaveClassroomViewModel vm)
        {
            await _classroomsService.Add(vm);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var vm = await _classroomsService.GetByIdSaveViewModel(id);

            return View("SaveClassroom", vm);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SaveClassroomViewModel vm)
        {
            await _classroomsService.Edit(vm);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            return View("Delete", await _classroomsService.GetByIdSaveViewModel(id));
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            await _classroomsService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
