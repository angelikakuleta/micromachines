using MicroMachines.Services.Shopping.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace MicroMachines.Services.Shopping.Data.Context
{
    public class ShoppingContext : DbContext
    {
        public ShoppingContext([NotNull] DbContextOptions options) : base(options)
        {
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
    }
}
