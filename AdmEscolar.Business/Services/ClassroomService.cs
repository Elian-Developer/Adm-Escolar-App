using AdmEscolar.Business.Interfaces.Repositories;
using AdmEscolar.Business.Interfaces.Services;
using AdmEscolar.Business.ViewModels.Classrooms;
using AdmEscolar.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmEscolar.Business.Services
{
    public class ClassroomService : IClassroomsService
    {
        private readonly IClassroomRepository _classroomRepository;

        public ClassroomService(IClassroomRepository classroomRepository)
        {
            _classroomRepository = classroomRepository;
        }

        public async Task Add(SaveClassroomViewModel vm)
        {
            Classrooms clas = new Classrooms();
            clas.Id = vm.Id;
            clas.Name = vm.Name;
            clas.Capacity = vm.Capacity;

            await _classroomRepository.AddAsync(clas);
        }

        public async Task Edit(SaveClassroomViewModel vm)
        {
            Classrooms clas = new();
            clas.Id = vm.Id;
            clas.Name = vm.Name;
            clas.Capacity = vm.Capacity;

            await _classroomRepository.EditAsync(clas);
        }

        public async Task Delete(int id)
        {
            var Class = await _classroomRepository.GetByIdAsync(id);
            await _classroomRepository.DeleteAsync(Class);
        }

        public async Task<List<ClassroomViewModel>> GetAllViewModel()
        {
            var ClassList = await _classroomRepository.GetAllAsync();

            return ClassList.Select(Class => new ClassroomViewModel()
            {
                Id = Class.Id,
                Name = Class.Name,
                Capacity = Class.Capacity,

            }).ToList();
        }

        public async Task<SaveClassroomViewModel> GetByIdSaveViewModel(int id)
        {
            var Class = await _classroomRepository.GetByIdAsync(id);

            SaveClassroomViewModel vm = new();
            vm.Id = Class.Id;
            vm.Name = Class.Name;
            vm.Capacity = Class.Capacity;

            return vm;
        }
    }
}
