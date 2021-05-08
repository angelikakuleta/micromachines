using MicroMachines.Services.Catalog.Dtos;
using MicroMachines.Services.Catalog.Data.Models;
using System.Linq;
using MicroMachines.Common.Contracts;

namespace MicroMachines.Services.Catalog.Mappers
{
    public static class StockExtensions
    {
        public static StockDto ToDto(this Stock stock)
        {
            var balances = stock.Balances.Select(x => new ItemBalanceDto(x.ProductId, x.Amount));
            return new StockDto(stock.Id, stock.Name, balances);
        }

        public static StockItemBalanceDto ToDto(this ItemBalance item)
        {
            return new StockItemBalanceDto(item.ProductId, item.Amount, item.StockId, item.Stock.Name);
        }
    }
}
