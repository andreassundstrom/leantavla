using Leantavla.Shared;
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
        public virtual DbSet<Bräda> Bräda { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Status>()
                .HasOne(p => p.Bräda)
                .WithMany(p => p.Statusar)
                .OnDelete(DeleteBehavior.NoAction);
                
        }
    }
}
