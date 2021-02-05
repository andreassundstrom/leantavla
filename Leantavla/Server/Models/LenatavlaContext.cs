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
    }
}
