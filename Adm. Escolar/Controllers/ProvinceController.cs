using AdmEscolar.Business.Interfaces.Services;
using AdmEscolar.Business.ViewModels.Province;
using MessagePack.Formatters;
using Microsoft.AspNetCore.Mvc;

namespace Adm._Escolar.Controllers
{
    public class ProvinceController : Controller
    {
        private readonly IProvinceService _provinceService;

        public ProvinceController(IProvinceService provinceService)
        {
            _provinceService = provinceService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _provinceService.GetAllViewModel());
        }

        public IActionResult Create()
        {
            SaveProvinceViewModel vm = new();
            return View("SaveProvince",vm);
        }

        [HttpPost]
        public async Task<IActionResult> Create(SaveProvinceViewModel vm)
        {
            await _provinceService.Add(vm);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var province = await _provinceService.GetByIdSaveViewModel(id);
            return View("SaveProvince", province);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SaveProvinceViewModel vm)
        {
            await _provinceService.Edit(vm);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var province = await _provinceService.GetByIdSaveViewModel(id);
            return View("Delete", province);
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            await _provinceService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
