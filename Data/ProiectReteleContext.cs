using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProiectRetele.Models;

namespace ProiectRetele.Data
{
    public class ProiectReteleContext : DbContext
    {
        public ProiectReteleContext (DbContextOptions<ProiectReteleContext> options)
            : base(options)
        {
        }

        public DbSet<ProiectRetele.Models.Mecanic> Mecanic { get; set; } = default!;

        public DbSet<ProiectRetele.Models.Programare>? Programare { get; set; }

        public DbSet<ProiectRetele.Models.Factura>? Factura { get; set; }

        public DbSet<ProiectRetele.Models.Masina>? Masina { get; set; }

        public DbSet<ProiectRetele.Models.Client>? Client { get; set; }
    }
}
