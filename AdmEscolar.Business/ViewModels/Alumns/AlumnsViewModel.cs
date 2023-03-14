using AdmEscolar.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmEscolar.Business.ViewModels.Alumns
{
    public class AlumnsViewModel
    {
        public int Id { get; set; }
        public int? Matricula { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public DateTime? BornDate { get; set; }
        public int ProvinceId { get; set; }
        public string? Province { get; set; }

    }
}
