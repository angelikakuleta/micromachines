using MicroMachines.Common;
using MicroMachines.Common.Contracts;
using MicroMachines.Services.Catalog.Data.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MicroMachines.Services.Catalog.Data.Repositories
{
    public interface IStockRepository : IBaseRepository<Stock>
    {
        Task<ItemBalance> GetBalance(Guid productId);
        Task<bool> TakeAll(IEnumerable<CreateOrderItemDto> itenarary);
        Task<ItemBalance> ChangeBalance(Guid productId, int v);
    }
}
