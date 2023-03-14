using AdmEscolar.Business.ViewModels.AdmEmployee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmEscolar.Business.Interfaces.Services
{
    public interface IAdmEmployeeService : IGenericService<SaveAdmEmpViewModel, AdmEmployeeViewModel>
    {
        Task<List<AdmEmployeeViewModel>> GetAllViewModelWithFilters(FilterEmployeeViewModel filter);
    }
}
