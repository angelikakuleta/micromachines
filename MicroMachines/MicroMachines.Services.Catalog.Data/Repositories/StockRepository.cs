using MicroMachines.Common.Contracts;
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
    public class StockRepository : IStockRepository
    {
        private readonly CatalogContext _context;

        public StockRepository(CatalogContext context)
        {
            _context = context;
            context.Database.EnsureCreated();
        }

        public async Task<Stock> Add(Stock entity)
        {
            _context.Stocks.Add(entity);
            await Save();
            return await GetSingle(x => x.Id == entity.Id);
        }

        public async Task Delete(Stock entity)
        {
            _context.Stocks.Remove(entity);
            await Save();
        }

        public async Task<Stock> Edit(Stock entity)
        {
            _context.Stocks.Update(entity);
            await Save();
            return entity;
        }

        public async Task<IList<Stock>> GetAll()
        {
            return await _context.Stocks
                .Include(x => x.Balances)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Stock> GetSingle(Expression<Func<Stock, bool>> condition)
        {
            return (await _context.Stocks
                .Include(x => x.Balances)
                .AsNoTracking()
                .Where(condition)
                .ToListAsync())
                .FirstOrDefault();
        }

        public async Task<ItemBalance> GetBalance(Guid productId)
        {
            return (await _context.ItemBalances
                .Where(x => x.ProductId == productId)
                .Include(x => x.Stock)
                .ToListAsync())
                .FirstOrDefault();
        }

        public async Task<ItemBalance> ChangeBalance(Guid productId, int quantity)
        {
            var itemBalance = await GetBalance(productId);
            if (itemBalance.Amount + quantity < 0) throw new ArgumentException();

            itemBalance.Amount += quantity;
            _context.ItemBalances.Update(itemBalance);
            await Save();

            return itemBalance;
        }

        public async Task<bool> TakeAll(IEnumerable<CreateOrderItemDto> itenarary)
        {
            var itemBalances = new List<ItemBalance>();
            foreach (var item in itenarary)
            {
                var itemBalance = await _context.ItemBalances.Where(x => x.ProductId == item.ProductId).FirstOrDefaultAsync();
                if (itemBalance == null || itemBalance.Amount - item.Quantity < 0) return false;
                itemBalance.Amount -= item.Quantity;
                itemBalances.Add(itemBalance);
            }

            _context.ItemBalances.UpdateRange(itemBalances);
            await _context.SaveChangesAsync();
            return true;
        }

        private async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
