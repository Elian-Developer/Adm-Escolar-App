using AdmEscolar.Business.Interfaces.Repositories;
using AdmEscolar.Business.Interfaces.Services;
using AdmEscolar.Business.Repository;
using AdmEscolar.Business.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmEscolar.Business
{
    public static class ServiceRegistration
    {
        public static void AddApplicationLayer(this IServiceCollection services, IConfiguration configuration)
        {

            #region Repositories
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<IAlumnsRepository, AlumnsRepository>();
            services.AddTransient<ITeacherRepository, TeacherRepository>();
            services.AddTransient<IAdmEmployeeRepository, AdmEmployeeRepository>();
            services.AddTransient<IClassroomRepository, ClassroomRepository>();
            services.AddTransient<IProvinceRepository, ProvinceRepository>();
            services.AddTransient<IAreaRepository, AreaRepository>();
            services.AddTransient<IDepartmentRepository, DepartmentRepository>();
            #endregion

            #region services
            services.AddTransient<IAlumnsService, AlumnsService>();
            services.AddTransient<ITeacherService, TeacherService>();
            services.AddTransient<IAdmEmployeeService, AdmEmployeeService>();
            services.AddTransient<IClassroomsService, ClassroomService>();
            services.AddTransient<IProvinceService, ProvinceService>();
            services.AddTransient<IAreaService, AreaService>();
            services.AddTransient<IDepartmentService, DepartmentService>();
            #endregion

        }
    }
}
