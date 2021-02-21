using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leantavla.Shared
{
    public class Lapp
    {
        public int LappId { get; set; }
        [Required]
        public int StatusId { get; set; }
        public Status Status { get; set; }
        public int BrädaId { get; set; }
        
        //public Bräda Bräda { get; set; }
        public List<Attribut> Attribut { get; set; }
    }
}
