using MicroMachines.Services.Catalog.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace MicroMachines.Services.Catalog.Data.Context
{
    public class CatalogContext : DbContext
    {
        public CatalogContext([NotNull] DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            this.SeedDatabase(modelBuilder);
        }
    }
}
