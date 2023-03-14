using AdmEscolar.Business.Interfaces.Repositories;
using AdmEscolar.Business.Interfaces.Services;
using AdmEscolar.Business.ViewModels.Alumns;
using AdmEscolar.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmEscolar.Business.Services
{
    public class AlumnsService : IAlumnsService
    {
        private readonly IAlumnsRepository _alumnsRepository;

        public AlumnsService(IAlumnsRepository alumnsRepository)
        {
            _alumnsRepository = alumnsRepository;
        }

        public async Task Add(SaveAlumnsViewModel vm)
        {
            Alumns alumns = new();
            alumns.Matricula = vm.Matricula;
            alumns.Name = vm.Name;
            alumns.LastName = vm.LastName;
            alumns.BornDate = vm.BornDate;
            alumns.ProvinceId = vm.ProvinceId;

            await _alumnsRepository.AddAsync(alumns);
        }

        public async Task Edit(SaveAlumnsViewModel vm)
        {
            Alumns alumns = new();
            alumns.Id = vm.Id;
            alumns.Matricula = vm.Matricula;
            alumns.Name = vm.Name;
            alumns.LastName = vm.LastName;
            alumns.BornDate = vm.BornDate;
            alumns.ProvinceId = vm.ProvinceId;

            await _alumnsRepository.EditAsync(alumns);
        }

        public async Task Delete(int id)
        {
            var alumns = await _alumnsRepository.GetByIdAsync(id);
            await _alumnsRepository.DeleteAsync(alumns);
        }

        public async Task<List<AlumnsViewModel>> GetAllViewModel()
        {
            var alumnsList = await _alumnsRepository.GetAllWithIncludeAsync(new List<string> {"Province"});

            return alumnsList.Select(alumns => new AlumnsViewModel
            {
                Id = alumns.Id,
                Matricula = alumns.Matricula,
                Name = alumns.Name,
                LastName = alumns.LastName,
                BornDate = alumns.BornDate,
                ProvinceId = alumns.ProvinceId,
                Province = alumns.Province.Description

            }).ToList();
        }

        public async Task<List<AlumnsViewModel>> GetAllViewModelWithFilter(FilterAlumnViewModel filter)
        {
            var alumnsList = await _alumnsRepository.GetAllWithIncludeAsync(new List<string> { "Province" });

            var ListViewModel = alumnsList.Select(alumns => new AlumnsViewModel
            {
                Id = alumns.Id,
                Matricula = alumns.Matricula,
                Name = alumns.Name,
                LastName = alumns.LastName,
                BornDate = alumns.BornDate,
                ProvinceId = alumns.ProvinceId,
                Province = alumns.Province.Description

            }).ToList();

            if(filter.AlumnMatricula != null)
            {
                ListViewModel = ListViewModel.Where(alumn => alumn.Matricula == filter.AlumnMatricula.Value).ToList();
            }

            if(filter.ProvinceName != null)
            {
                ListViewModel = ListViewModel.Where(alumn => alumn.Province.Contains(filter.ProvinceName)).ToList();
            }

            return ListViewModel;
        }

        public async Task<SaveAlumnsViewModel> GetByIdSaveViewModel(int id)
        {
            var Alumns = await _alumnsRepository.GetByIdAsync(id);

            SaveAlumnsViewModel vm = new();
            vm.Id = Alumns.Id;
            vm.Matricula = Alumns.Matricula;
            vm.Name = Alumns.Name;
            vm.LastName = Alumns.LastName;
            vm.BornDate = Alumns.BornDate;
            vm.ProvinceId = Alumns.ProvinceId;

            return vm;
        }
    }
}
