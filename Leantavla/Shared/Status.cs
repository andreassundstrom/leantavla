using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Leantavla.Shared
{
    public class Status
    {

        public int StatusId { get; set; }
        public string StatusNamn { get; set; }
        [JsonIgnore]
        public Bräda Bräda { get; set; }
        public int BrädaId { get; set; }
        public int Sortering { get; set; }
    }
}
