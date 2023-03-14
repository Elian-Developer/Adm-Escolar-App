using AdmEscolar.Business.Interfaces.Repositories;
using AdmEscolar.Business.Interfaces.Services;
using AdmEscolar.Business.ViewModels.Province;
using AdmEscolar.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmEscolar.Business.Services
{
    public class ProvinceService : IProvinceService
    {
        private readonly IProvinceRepository _provinceRepository;
        public ProvinceService(IProvinceRepository provinceRepository)
        {
            _provinceRepository = provinceRepository;
        }

        public async Task Add(SaveProvinceViewModel vm)
        {
            Province province = new();
            province.Id = vm.Id;
            province.Description = vm.Description;

            await _provinceRepository.AddAsync(province);
        }

        public async Task Edit(SaveProvinceViewModel vm)
        {
            Province province = new();
            province.Id = vm.Id;
            province.Description = vm.Description;

            await _provinceRepository.EditAsync(province);
        }

        public async Task Delete(int id)
        {
            var province = await _provinceRepository.GetByIdAsync(id);
            await _provinceRepository.DeleteAsync(province);
        }

        public async Task<List<ProvinceViewModel>> GetAllViewModel()
        {
            var ProvinceList = await _provinceRepository.GetAllAsync();
            
            return ProvinceList.Select(province => new ProvinceViewModel()
            {
                Id = province.Id,
                Description = province.Description,

            }).ToList();
        }

        public async Task<SaveProvinceViewModel> GetByIdSaveViewModel(int id)
        {
            var Province = await _provinceRepository.GetByIdAsync(id);

            SaveProvinceViewModel vm = new();
            vm.Id = Province.Id;
            vm.Description = Province.Description;

            return vm;
        }
    }
}
