using AdmEscolar.Business.Interfaces.Repositories;
using AdmEscolar.Business.Interfaces.Services;
using AdmEscolar.Business.ViewModels.AdmEmployee;
using AdmEscolar.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmEscolar.Business.Services
{
    public class AdmEmployeeService : IAdmEmployeeService
    {
        private readonly IAdmEmployeeRepository _admEmployeeRepository;

        public AdmEmployeeService(IAdmEmployeeRepository admEmployeeRepository)
        {
            _admEmployeeRepository = admEmployeeRepository;
        }

        public async Task Add(SaveAdmEmpViewModel vm)
        {
            AdmEmployees Adm = new();
            Adm.Id = vm.Id;
            Adm.Name = vm.Name;
            Adm.LastName = vm.LastName;
            Adm.BornDate = vm.BornDate;
            Adm.DepartmentId = vm.DepartmentId;

            await _admEmployeeRepository.AddAsync(Adm);
        }

        public async Task Edit(SaveAdmEmpViewModel vm)
        {
            AdmEmployees Adm = new();
            Adm.Id = vm.Id;
            Adm.Name = vm.Name;
            Adm.LastName = vm.LastName;
            Adm.BornDate = vm.BornDate;
            Adm.DepartmentId = vm.DepartmentId;

            await _admEmployeeRepository.EditAsync(Adm);
        }

        public async Task Delete(int id)
        {
            var AdmEmployee = await _admEmployeeRepository.GetByIdAsync(id);
            await _admEmployeeRepository.DeleteAsync(AdmEmployee);
        }

        public async Task<List<AdmEmployeeViewModel>> GetAllViewModel()
        {
            var AdmEmployeeList = await _admEmployeeRepository.GetAllWithIncludeAsync(new List<string> { "Departments" });

            return AdmEmployeeList.Select(AdmEmployee => new AdmEmployeeViewModel
            {
                Id = AdmEmployee.Id,
                Name = AdmEmployee.Name,
                LastName = AdmEmployee.LastName,
                BornDate = AdmEmployee.BornDate,
                DepartmentId = AdmEmployee.DepartmentId,
                Department = AdmEmployee.Departments.Description
                
            }).ToList();
        }

        public async Task<List<AdmEmployeeViewModel>> GetAllViewModelWithFilters(FilterEmployeeViewModel filter)
        {
            var AdmEmployeeList = await _admEmployeeRepository.GetAllWithIncludeAsync(new List<string> { "Departments" });

            var ListViewModel = AdmEmployeeList.Select(AdmEmployee => new AdmEmployeeViewModel()
            {
                Id = AdmEmployee.Id,
                Name = AdmEmployee.Name,
                LastName = AdmEmployee.LastName,
                BornDate = AdmEmployee.BornDate,
                DepartmentId = AdmEmployee.DepartmentId,
                Department = AdmEmployee.Departments.Description

            }).ToList();

            if(filter.DepartmentName != null)
            {
                ListViewModel = ListViewModel.Where(adm => adm.Department.Contains(filter.DepartmentName)).ToList();
            }

            return ListViewModel;
        }

        public async Task<SaveAdmEmpViewModel> GetByIdSaveViewModel(int id)
        {
            var AdmEmployee = await _admEmployeeRepository.GetByIdAsync(id);

            SaveAdmEmpViewModel vm = new();
            vm.Id = AdmEmployee.Id;
            vm.Name = AdmEmployee.Name;
            vm.LastName = AdmEmployee.LastName;
            vm.BornDate = AdmEmployee.BornDate;
            vm.DepartmentId = AdmEmployee.DepartmentId;

            return vm;
        }
    }
}
