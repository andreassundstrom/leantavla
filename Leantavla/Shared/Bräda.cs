using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leantavla.Shared
{
    public class Bräda
    {
        public int BrädaId { get; set; }
        public string BrädaNamn { get; set; }
        public List<Lapp> Lappar { get; set; }
        public List<Attributtyp> Attributtyper { get; set; }
        public List<Status> Statusar { get; set; }
    }
}
