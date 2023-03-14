using AdmEscolar.Business.ViewModels.Alumns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmEscolar.Business.Interfaces.Services
{
    public interface IAlumnsService : IGenericService<SaveAlumnsViewModel, AlumnsViewModel>
    {
        Task<List<AlumnsViewModel>> GetAllViewModelWithFilter(FilterAlumnViewModel filter);
    }
}
