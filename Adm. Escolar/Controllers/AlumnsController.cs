using Adm._Escolar.Models;
using AdmEscolar.Business.Interfaces.Services;
using AdmEscolar.Business.Services;
using AdmEscolar.Business.ViewModels.Alumns;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Adm._Escolar.Controllers
{
    public class AlumnsController : Controller
    {
        private readonly IAlumnsService _alumnsService;
        private readonly IProvinceService _provinceService;

        public AlumnsController(IAlumnsService alumnsService, IProvinceService provinceService)
        {
            _alumnsService = alumnsService;
            _provinceService = provinceService;
        }

        public async Task <IActionResult> Index(FilterAlumnViewModel vm)
        {
            return View(await _alumnsService.GetAllViewModelWithFilter(vm));
        }

        public async Task<IActionResult> Create()
        {
            SaveAlumnsViewModel vm = new();
            vm.Provinces = await _provinceService.GetAllViewModel();
            return View("SaveAlumns", vm);
        }

        [HttpPost]
        public async Task<IActionResult> Create(SaveAlumnsViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                vm.Provinces = await _provinceService.GetAllViewModel();
                return View("SaveAlumns", vm);
            }

            await _alumnsService.Add(vm);
            return RedirectToRoute(new { controller = "Alumns", action = "Index" });
        }

        public async Task<IActionResult> Edit(int id)
        {
            SaveAlumnsViewModel alumn = await _alumnsService.GetByIdSaveViewModel(id);
            alumn.Provinces = await _provinceService.GetAllViewModel();
            return View("SaveAlumns", alumn);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SaveAlumnsViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                vm.Provinces = await _provinceService.GetAllViewModel();
                return View("SaveAlumns", vm);
            }

            await _alumnsService.Edit(vm);
            return RedirectToRoute(new { controller = "Alumns", action = "Index" });
        }

        public async Task<IActionResult> Delete(int id)
        {
            return View("Delete", await _alumnsService.GetByIdSaveViewModel(id));
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            await _alumnsService.Delete(id);
            return RedirectToRoute(new {controller="Alumns" , action="Index"}); 
        }


    }
}