using AdmEscolar.Business.Interfaces.Services;
using AdmEscolar.Business.ViewModels.Area;
using Microsoft.AspNetCore.Mvc;

namespace Adm._Escolar.Controllers
{
    public class AreaController : Controller
    {
        private readonly IAreaService _areaService;

        public AreaController(IAreaService areaService)
        {
            _areaService = areaService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _areaService.GetAllViewModel());
        }

        public IActionResult Create()
        {
            SaveAreaViewModel vm = new();
            return View("SaveArea", vm);
        }

        [HttpPost]
        public async Task<IActionResult> Create(SaveAreaViewModel vm)
        {
            await _areaService.Add(vm);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var area = await _areaService.GetByIdSaveViewModel(id);
            return View("SaveArea", area);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SaveAreaViewModel vm)
        {
            await _areaService.Edit(vm);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var area = await _areaService.GetByIdSaveViewModel(id);
            return View("Delete", area);
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            await _areaService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
