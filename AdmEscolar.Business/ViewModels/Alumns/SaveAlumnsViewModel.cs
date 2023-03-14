using AdmEscolar.Business.ViewModels.Province;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmEscolar.Business.ViewModels.Alumns
{
    public class SaveAlumnsViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "You should set Matricula or ID Alumn")]
        public int? Matricula { get; set; }
        [Required(ErrorMessage = "You should set Name Alumn")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "You should set LastName Alumn")]
        public string? LastName { get; set; }
        public DateTime? BornDate { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "You should set Province Alumn")]
        public int ProvinceId { get; set; }
        public List<ProvinceViewModel>? Provinces { get; set; }
    }
}
