using AdmEscolar.Business.Interfaces.Repositories;
using AdmEscolar.Data.Contexts;
using AdmEscolar.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmEscolar.Business.Repository
{
    public class DepartmentRepository : GenericRepository<Departments>, IDepartmentRepository
    {
        private readonly ApplicationContext _dbContext;

        public DepartmentRepository(ApplicationContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
