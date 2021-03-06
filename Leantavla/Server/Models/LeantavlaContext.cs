﻿using Leantavla.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Leantavla.Server.Models
{
    public class LeantavlaContext : DbContext
    {
        public LeantavlaContext(DbContextOptions<LeantavlaContext> options)
            :base(options)
        {

        }
        public virtual DbSet<Lapp> Lappar { get; set; }
        public virtual DbSet<Attributtyp> Attributtyper { get; set; }
        public virtual DbSet<Attribut> Attribut { get; set; }
        public virtual DbSet<Status> Status { get; set; }
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

            modelBuilder.Entity<Status>()
                .HasData(
                new Status { StatusId = 1, StatusNamn = "Ny" },
                new Status { StatusId = 2, StatusNamn = "Pågående" },
                new Status { StatusId = 3, StatusNamn = "Avslutad" }
                );
        }
    }
}
