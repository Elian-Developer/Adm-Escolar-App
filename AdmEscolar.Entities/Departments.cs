using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmEscolar.Entities
{
    public class Departments
    {
        public int Id { get; set; }
        public string? Description { get; set; }

        //Navigation Property

        public ICollection<AdmEmployees>? AdmEmployees { get; set; }

    }
}
