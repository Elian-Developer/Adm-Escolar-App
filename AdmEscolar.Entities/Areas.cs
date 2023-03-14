using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmEscolar.Entities
{
    public class Areas
    {
        public int Id { get; set; }
        public string? Description { get; set; }

        //Navigation Property
        public ICollection<Teachers>? Teachers { get; set; }
    }
}
