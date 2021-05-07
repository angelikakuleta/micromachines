using MicroMachines.Services.Identity.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace MicroMachines.Services.Identity.Data.Context
{
    public class UserContext : DbContext
    {
        public UserContext([NotNull] DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            this.SeedDatabase(modelBuilder);
        }
    }
}
