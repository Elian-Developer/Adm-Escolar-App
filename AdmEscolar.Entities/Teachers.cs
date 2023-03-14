using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmEscolar.Entities
{
    public class Teachers
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public DateTime? BornDate { get; set; } 
        
        //Foreign Key
        public int AreaId { get; set; } 

        //Navigation Property
        public Areas? Areas { get; set; }

    }
}
