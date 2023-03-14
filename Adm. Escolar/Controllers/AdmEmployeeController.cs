using AdmEscolar.Business.Interfaces.Services;
using AdmEscolar.Business.ViewModels.AdmEmployee;
using Microsoft.AspNetCore.Mvc;

namespace Adm._Escolar.Controllers
{
    public class AdmEmployeeController : Controller
    {
        private readonly IAdmEmployeeService _admEmployeeService;
        private readonly IDepartmentService _departmentService;

        public AdmEmployeeController(IAdmEmployeeService admEmployeeService, IDepartmentService departmentService)
        {
            _admEmployeeService = admEmployeeService;
            _departmentService = departmentService;
        }

        public async Task <IActionResult> Index(FilterEmployeeViewModel vm)
        {
            return View(await _admEmployeeService.GetAllViewModelWithFilters(vm));
        }

        public async Task<IActionResult> Create()
        {
            SaveAdmEmpViewModel vm = new();
            vm.Departments = await _departmentService.GetAllViewModel();
            return View("SaveAdmEmployee", vm);
        }

        [HttpPost]
        public async Task<IActionResult> Create(SaveAdmEmpViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                vm.Departments = await _departmentService.GetAllViewModel();
                return View("SaveAdmEmployee", vm);
            }

             await _admEmployeeService.Add(vm);
             return RedirectToRoute(new { controller = "AdmEmployee", action = "Index" });
        }
        public async Task<IActionResult> Edit(int id)
        {
            SaveAdmEmpViewModel vm = await _admEmployeeService.GetByIdSaveViewModel(id);
            vm.Departments = await _departmentService.GetAllViewModel();
            return View("SaveAdmEmployee", vm);

        }

        [HttpPost]
        public async Task<IActionResult> Edit(SaveAdmEmpViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                vm.Departments = await _departmentService.GetAllViewModel();
                return View("SaveAdmEmployee", vm);
            }

            await _admEmployeeService.Edit(vm);
            return RedirectToRoute(new { controller = "AdmEmployee", action = "Index" });
        }

        public async Task<IActionResult> Delete(int id)
        {
            return View("Delete", await _admEmployeeService.GetByIdSaveViewModel(id));
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            await _admEmployeeService.Delete(id);
            return RedirectToRoute(new { controller = "AdmEmployee", action = "Index" });
        }
    }
}
