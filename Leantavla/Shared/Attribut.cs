using System;

namespace Leantavla.Shared
{
    public class Attribut
    {
        public int AttributId { get; set; }
        
        public int AttributtypId { get; set; }
        public Attributtyp Attributtyp { get; set; }
        
        public string StringValue { get; set; }
        public DateTime? DateValue { get; set; }
    }
}