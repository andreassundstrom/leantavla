namespace Leantavla.Shared
{
    public class Attributtyp
    {
        public int AttributtypId { get; set; }
        public string Attributnamn { get; set; }
        public string Attributbeskrivning { get; set; }
        public Datatyp Datatyp { get; set; }
    }
}