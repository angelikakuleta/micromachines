using MicroMachines.Services.Catalog.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace MicroMachines.Services.Catalog.Data.Context
{
    public static class CatalogContextSeeder
    {
        public static void SeedDatabase(this CatalogContext context, ModelBuilder modelBuilder)
        {
            var categories = new Category[]
            {
                new Category { Name = "Trucks" },              
                new Category { Name = "Classic Air Racers" },
                new Category { Name = "Military Ground Vehicles" }
            };

            var products = new Product[]
            {
                new Product { Name = "Dumper Truck", Price = 25.00M, CategoryId = categories[0].Id },
                new Product { Name = "Fire Trucks", Price = 12.49M, CategoryId = categories[0].Id },
                new Product { Name = "Monster Truck", Price = 42.99M, CategoryId = categories[0].Id },
                new Product { Name = "Gee Bee", Price = 25.00M, CategoryId = categories[1].Id },
                new Product { Name = "F4U Corsair", Price = 10.00M, CategoryId = categories[1].Id },
                new Product { Name = "Supermarin 26B", Price = 12.50M, CategoryId = categories[1].Id },
                new Product { Name = "G.I Joe Mobat", Price = 32.49M, CategoryId = categories[2].Id },
                new Product { Name = "G.I.JOE H.I.S.S.", Price = 36.78M, CategoryId = categories[2].Id },
            };

            modelBuilder.Entity<Category>().HasData(categories);
            modelBuilder.Entity<Product>().HasData(products);
        }
    }
}
