using MicroMachines.Services.Catalog.Data.Context;
using MicroMachines.Services.Catalog.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MicroMachines.Services.Catalog.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly CatalogContext _context;

        public ProductRepository(CatalogContext context)
        {
            _context = context;
            context.Database.EnsureCreated();
        }

        public async Task<Product> Add(Product entity)
        {
            _context.Products.Add(entity);
            await Save();
            return await GetSingle(x => x.Id == entity.Id);
        }

        public async Task Delete(Product entity)
        {
            _context.Products.Remove(entity);
            await Save();
        }

        public async Task<Product> Edit(Product entity)
        {
            _context.Products.Update(entity);
            await Save();
            return entity;
        }

        public async Task<IList<Product>> GetAll()
        {
            return await _context.Products
                .Include(x => x.Category)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IList<Product>> GetByCategory(Guid categoryId)
        {
            return await _context.Products
                .Include(x => x.Category)
                .AsNoTracking()
                .Where(x => x.Category.Id == categoryId)
                .ToListAsync();
        }

        public async Task<Product> GetSingle(Expression<Func<Product, bool>> condition)
        {
            return (await _context.Products
                .Include(x => x.Category)
                .AsNoTracking()
                .Where(condition)
                .ToListAsync())
                .FirstOrDefault();
        }

        private async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
