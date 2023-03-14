using AdmEscolar.Business.Interfaces.Services;
using AdmEscolar.Business.ViewModels.Departments;
using Microsoft.AspNetCore.Mvc;

namespace Adm._Escolar.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _departmentService.GetAllViewModel());
        }

        public IActionResult Create()
        {
            SaveDepartmentViewModel vm = new();
            return View("SaveDepartment", vm);
        }

        [HttpPost]
        public async Task<IActionResult> Create(SaveDepartmentViewModel vm)
        {
            await _departmentService.Add(vm);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var depart = await _departmentService.GetByIdSaveViewModel(id);
            return View("SaveDepartment", depart);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SaveDepartmentViewModel vm)
        {
            await _departmentService.Edit(vm);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            return View("Delete", await _departmentService.GetByIdSaveViewModel(id));
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            await _departmentService.Delete(id);
            return RedirectToAction("Index");

        }
    }
}
