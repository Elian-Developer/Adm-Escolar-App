using AdmEscolar.Business.ViewModels.Departments;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmEscolar.Business.ViewModels.AdmEmployee
{
    public class SaveAdmEmpViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "You should set Employee Name")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "You should set Employee LastName")]
        public string? LastName { get; set; }
        public DateTime? BornDate { get; set; }
        [Range(1,int.MaxValue, ErrorMessage = "You should set Employee Department")]
        public int DepartmentId { get; set; }
        public List<DepartmentViewModel>? Departments { get; set; }


    }
}
