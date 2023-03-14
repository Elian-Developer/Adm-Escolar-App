using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmEscolar.Entities
{
    public class Alumns
    {
        public int Id { get; set; }
        public int? Matricula { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public DateTime? BornDate { get; set; }

        //Foreign Key
        public int ProvinceId { get; set; }

        //Navigation Property
        public Province? Province { get; set; }



    }
}
