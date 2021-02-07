using Leantavla.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Leantavla.Server.Models
{
    public class LenatavlaContext : DbContext
    {
        public LenatavlaContext(DbContextOptions<LenatavlaContext> options)
            :base(options)
        {

        }
        public virtual DbSet<Lapp> Lappar { get; set; }
        public virtual DbSet<Attributtyp> Attributtyper { get; set; }
        public virtual DbSet<Attribut> Attribut { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Attributtyp>()
                .HasData(new Attributtyp
                {
                    AttributtypId = 4,
                    Attributnamn = "Skapare",
                    Attributbeskrivning = "Personen som skapade lappen",
                    Datatyp = Datatyp.StringDatatype
                },
                new Attributtyp
                {
                    AttributtypId = 3,
                    Attributnamn = "Skapad",
                    Attributbeskrivning = "Tidpunkt för när lappen skapades",
                    Datatyp = Datatyp.DateDataType
                },
                new Attributtyp
                {
                    AttributtypId = 1,
                    Attributnamn = "Sammanfattning",
                    Attributbeskrivning = "Kort beskrivning av problemet",
                    Datatyp = Datatyp.StringDatatype
                },
                new Attributtyp
                {
                    AttributtypId = 2,
                    Attributnamn = "Beskrivning",
                    Attributbeskrivning = "Beskrivning av problemet",
                    Datatyp = Datatyp.LongStringDatatype
                }
                );
        }
    }
}
