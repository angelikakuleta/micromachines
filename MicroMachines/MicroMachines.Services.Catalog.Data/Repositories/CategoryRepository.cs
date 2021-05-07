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
    public class CategoryRepository : ICategoryRepository
    {
        private readonly CatalogContext _context;

        public CategoryRepository(CatalogContext context)
        {
            _context = context;
            context.Database.EnsureCreated();
        }

        public async Task<Category> Add(Category entity)
        {
            _context.Categories.Add(entity);
            await Save();
            return await GetSingle(x => x.Id == entity.Id);
        }

        public async Task Delete(Category entity)
        {
            _context.Categories.Remove(entity);
            await Save();
        }

        public async Task<Category> Edit(Category entity)
        {
            _context.Categories.Update(entity);
            await Save();
            return entity;
        }

        public async Task<IList<Category>> GetAll()
        {
            return await _context.Categories
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Category> GetSingle(Expression<Func<Category, bool>> condition)
        {
            return (await _context.Categories
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
