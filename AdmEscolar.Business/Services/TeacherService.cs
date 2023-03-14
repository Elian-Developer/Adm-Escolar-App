using AdmEscolar.Business.Interfaces.Repositories;
using AdmEscolar.Business.Interfaces.Services;
using AdmEscolar.Business.ViewModels.Teachers;
using AdmEscolar.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmEscolar.Business.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly ITeacherRepository _teacherRespository;

        public TeacherService(ITeacherRepository teacherRespository)
        {
            _teacherRespository = teacherRespository;
        }

        public async Task Add(SaveTeacherViewModel vm)
        {
            Teachers teacher = new();
            teacher.Id = vm.Id;
            teacher.Name = vm.Name;
            teacher.LastName = vm.LastName;
            teacher.BornDate = vm.BornDate;
            teacher.AreaId = vm.AreaId;

            await _teacherRespository.AddAsync(teacher);
        }

        public async Task Edit(SaveTeacherViewModel vm)
        {
            Teachers teacher = new();
            teacher.Id = vm.Id;
            teacher.Name = vm.Name;
            teacher.LastName = vm.LastName;
            teacher.BornDate = vm.BornDate;
            teacher.AreaId = vm.AreaId;

            await _teacherRespository.EditAsync(teacher);
        }

        public async Task Delete(int id)
        {
            var teacher = await _teacherRespository.GetByIdAsync(id);
            await _teacherRespository.DeleteAsync(teacher);
        }

        public async Task<List<TeacherViewModel>> GetAllViewModel()
        {
            var TeacherList = await _teacherRespository.GetAllWithIncludeAsync(new List<string> {"Areas"});

            return TeacherList.Select(teacher => new TeacherViewModel
            {
                Id = teacher.Id,
                Name = teacher.Name,
                LastName = teacher.LastName,
                BornDate = teacher.BornDate,
                AreaId = teacher.AreaId,
                Area = teacher.Areas.Description

            }).ToList();
        }

        public async Task<List<TeacherViewModel>> GetAllViewModelWithFilters(FilterTeacherViewModel filter)
        {
            var TeacherList = await _teacherRespository.GetAllWithIncludeAsync(new List<string> { "Areas" });

            var ListViewModel = TeacherList.Select(teacher => new TeacherViewModel()
            {
                Id = teacher.Id,
                Name = teacher.Name,
                LastName = teacher.LastName,
                BornDate = teacher.BornDate,
                AreaId = teacher.AreaId,
                Area = teacher.Areas.Description

            }).ToList();
            
            if(filter.AreaName != null)
            {
                ListViewModel = ListViewModel.Where(teacher => teacher.Area.Contains(filter.AreaName)).ToList();
            }

            return ListViewModel;
        }

        public async Task<SaveTeacherViewModel> GetByIdSaveViewModel(int id)
        {
            var Teacher = await _teacherRespository.GetByIdAsync(id);

            SaveTeacherViewModel vm = new();

            vm.Id = Teacher.Id;
            vm.Name = Teacher.Name;
            vm.LastName = Teacher.LastName;
            vm.BornDate = Teacher.BornDate;
            vm.AreaId = Teacher.AreaId;

            return vm;
        }
    }
}
