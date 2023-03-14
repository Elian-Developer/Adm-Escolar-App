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
    public class AdmEmployeeRepository : GenericRepository<AdmEmployees>, IAdmEmployeeRepository
    {
        private readonly ApplicationContext _dbContext;

        public AdmEmployeeRepository(ApplicationContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
