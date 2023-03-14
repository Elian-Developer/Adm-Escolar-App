using AdmEscolar.Business.ViewModels.Area;
using AdmEscolar.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmEscolar.Business.ViewModels.Teachers
{
    public class SaveTeacherViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "You should set Name Teacher.")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "You should set LastName Teacher.")]
        public string? LastName { get; set; }
        public DateTime? BornDate { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "You should set Area Teacher.")]
        public int AreaId { get; set; }
        public List<AreaViewModel>? Areas { get; set; }

    }
}
