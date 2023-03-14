using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmEscolar.Business.ViewModels.Teachers
{
    public class TeacherViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public DateTime? BornDate { get; set; }
        public int AreaId { get; set; }
        public string? Area { get; set; }
    }
}
