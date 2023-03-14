using AdmEscolar.Business.Interfaces.Repositories;
using AdmEscolar.Business.Interfaces.Services;
using AdmEscolar.Business.ViewModels.AdmEmployee;
using AdmEscolar.Business.ViewModels.Departments;
using AdmEscolar.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmEscolar.Business.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task Add(SaveDepartmentViewModel vm)
        {
            Departments depart = new();
            depart.Id = vm.Id;
            depart.Description = vm.Description;

            await _departmentRepository.AddAsync(depart);
        }

        public async Task Edit(SaveDepartmentViewModel vm)
        {
            Departments depart = new();
            depart.Id = vm.Id;
            depart.Description = vm.Description;
            
            await _departmentRepository.EditAsync(depart);
        }

        public async Task Delete(int id)
        {
            var department = await _departmentRepository.GetByIdAsync(id);
            await _departmentRepository.DeleteAsync(department);
        }

        public async Task<List<DepartmentViewModel>> GetAllViewModel()
        {
            var DepartmentList = await _departmentRepository.GetAllAsync();

            return DepartmentList.Select(depart => new DepartmentViewModel()
            {
                Id = depart.Id,
                Description = depart.Description

            }).ToList();
        }

        public async Task<SaveDepartmentViewModel> GetByIdSaveViewModel(int id)
        {
            var Department = await _departmentRepository.GetByIdAsync(id);

            SaveDepartmentViewModel vm = new();
            vm.Id = Department.Id;
            vm.Description = Department.Description;

            return vm;
        }
    }
}
