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

            var stocks = new Stock[]
            {
                new Stock { Name = "A12" },
                new Stock { Name = "E17" },
                new Stock { Name = "E42" }
            };

            var itemBalances = new ItemBalance[]
            {
                new ItemBalance { ProductId = products[0].Id, StockId = stocks[0].Id, Amount = 60 },
                new ItemBalance { ProductId = products[1].Id, StockId = stocks[0].Id, Amount = 517 },
                new ItemBalance { ProductId = products[2].Id, StockId = stocks[0].Id, Amount = 0 },
                new ItemBalance { ProductId = products[3].Id, StockId = stocks[0].Id, Amount = 193 },
                new ItemBalance { ProductId = products[4].Id, StockId = stocks[1].Id, Amount = 98 },
                new ItemBalance { ProductId = products[5].Id, StockId = stocks[1].Id, Amount = 55 },
                new ItemBalance { ProductId = products[6].Id, StockId = stocks[2].Id, Amount = 329 },
                new ItemBalance { ProductId = products[7].Id, StockId = stocks[2].Id, Amount = 110 }
            };

            modelBuilder.Entity<Category>().HasData(categories);
            modelBuilder.Entity<Product>().HasData(products);
            modelBuilder.Entity<Stock>().HasData(stocks);
            modelBuilder.Entity<ItemBalance>().HasData(itemBalances);
        }
    }
}
