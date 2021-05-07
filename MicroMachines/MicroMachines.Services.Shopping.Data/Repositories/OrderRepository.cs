using MicroMachines.Services.Shopping.Data.Context;
using MicroMachines.Services.Shopping.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MicroMachines.Services.Shopping.Data.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ShoppingContext _context;

        public OrderRepository(ShoppingContext context)
        {
            _context = context;
        }

        public async Task<Order> Add(Order entity)
        {
            _context.Orders.Add(entity);
            await Save();
            return await GetSingle(x => x.Id == entity.Id);
        }

        public async Task Delete(Order entity)
        {
            _context.Orders.Remove(entity);
            await Save();
        }

        public async Task<Order> Edit(Order entity)
        {
            _context.Orders.Update(entity);
            await Save();
            return entity;
        }

        public async Task<IList<Order>> GetAll()
        {
            return await _context.Orders
                .Include(x => x.Itenarary)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Order> GetSingle(Expression<Func<Order, bool>> condition)
        {
            return (await _context.Orders
                .Include(x => x.Itenarary)
                .AsNoTracking()
                .Where(condition)
                .ToListAsync())
                .FirstOrDefault();
        }

        public async Task<decimal> GetTotal(Guid id)
        {
            return await _context.OrderItems
                .Where(x => x.OrderId == id)
                .SumAsync(x => x.UnitPrice * x.Quantity);
        }

        private async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
