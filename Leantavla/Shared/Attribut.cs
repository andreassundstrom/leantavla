using System;

namespace Leantavla.Shared
{
    /// <summary>
    /// Attribut som hör till en lapp
    /// </summary>
    public class Attribut
    {
        public int AttributId { get; set; }
        
        public int AttributtypId { get; set; }
        public Attributtyp Attributtyp { get; set; }
        
        public string StringValue { get; set; }
        public DateTime? DateValue { get; set; }
    }
}