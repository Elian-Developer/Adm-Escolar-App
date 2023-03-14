using AdmEscolar.Business.ViewModels.Teachers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmEscolar.Business.Interfaces.Services
{
    public interface ITeacherService : IGenericService<SaveTeacherViewModel, TeacherViewModel>
    {
        Task<List<TeacherViewModel>> GetAllViewModelWithFilters(FilterTeacherViewModel filter);
    }
}
