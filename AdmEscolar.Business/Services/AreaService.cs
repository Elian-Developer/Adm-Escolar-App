using AdmEscolar.Business.Interfaces.Repositories;
using AdmEscolar.Business.Interfaces.Services;
using AdmEscolar.Business.ViewModels.AdmEmployee;
using AdmEscolar.Business.ViewModels.Area;
using AdmEscolar.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmEscolar.Business.Services
{
    public class AreaService : IAreaService
    {
        private readonly IAreaRepository _areaRepository;
        
        public AreaService(IAreaRepository areaRepository)
        {
            _areaRepository = areaRepository;
        }

        public async Task Add(SaveAreaViewModel vm)
        {
            Areas area = new();
            area.Id = vm.Id;
            area.Description = vm.Description;

            await _areaRepository.AddAsync(area);
        }

        public async Task Edit(SaveAreaViewModel vm)
        {
            Areas area = new();
            area.Id = vm.Id;
            area.Description = vm.Description;

            await _areaRepository.EditAsync(area);
        }

        public async Task Delete(int id)
        {
            var Area = await _areaRepository.GetByIdAsync(id);
            await _areaRepository.DeleteAsync(Area);
        }

        public async Task<List<AreaViewModel>> GetAllViewModel()
        {
            var AreaList = await _areaRepository.GetAllAsync();

            return AreaList.Select(area => new AreaViewModel()
            {
                Id = area.Id,
                Description = area.Description,

            }).ToList();
        }

        public async Task<SaveAreaViewModel> GetByIdSaveViewModel(int id)
        {
            var Area = await _areaRepository.GetByIdAsync(id);

            SaveAreaViewModel vm = new();
            vm.Id = Area.Id;
            vm.Description = Area.Description;

            return vm;
        }
    }
}
