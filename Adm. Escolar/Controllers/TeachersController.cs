using AdmEscolar.Business.Interfaces.Services;
using AdmEscolar.Business.ViewModels.Teachers;
using Microsoft.AspNetCore.Mvc;

namespace Adm._Escolar.Controllers
{
    public class TeachersController : Controller
    {
        private readonly ITeacherService _teacherService;
        private readonly IAreaService _areaService;

        public TeachersController(ITeacherService teacherService, IAreaService areaService)
        {
            _teacherService = teacherService;
            _areaService = areaService;
        }

        public async Task<IActionResult> Index(FilterTeacherViewModel vm)

        {
            return View( await _teacherService.GetAllViewModelWithFilters(vm));
        }

        public async Task<IActionResult> Create()
        {
            SaveTeacherViewModel vm = new();
            vm.Areas = await _areaService.GetAllViewModel();
            return View("SaveTeacher", vm);
        }

        [HttpPost]
        public async Task <IActionResult> Create(SaveTeacherViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                vm.Areas = await _areaService.GetAllViewModel();
                return View("SaveTeacher", vm);
            }

            await _teacherService.Add(vm);
            return RedirectToRoute(new {controller="Teachers", action="Index"});
        }

        public async Task<IActionResult> Edit(int id)
        {
            SaveTeacherViewModel vm = await _teacherService.GetByIdSaveViewModel(id);
            vm.Areas = await _areaService.GetAllViewModel();
            return View("SaveTeacher", vm);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SaveTeacherViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                vm.Areas = await _areaService.GetAllViewModel();
                return View("SaveTeacher", vm);
            }

            await _teacherService.Edit(vm);
            return RedirectToRoute(new { controller = "Teachers", action = "Index" });
        }

        public async Task<IActionResult> Delete(int id)
        {
            return View("Delete", await _teacherService.GetByIdSaveViewModel(id));
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            await _teacherService.Delete(id);
            return RedirectToRoute(new { controller = "Teachers", action = "Index" });
        }
    }
}
