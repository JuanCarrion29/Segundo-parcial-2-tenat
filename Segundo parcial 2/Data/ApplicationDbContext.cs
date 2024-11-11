using Segundo_parcial_2.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Segundo_parcial_2.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<ElectricityConsumption> ElectricityConsumptions { get; set; }
    }
}
