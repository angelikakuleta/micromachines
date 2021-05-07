using MicroMachines.Common;
using MicroMachines.Services.Shopping.Data.Models;
using System;
using System.Threading.Tasks;

namespace MicroMachines.Services.Shopping.Data.Repositories
{
    public interface IOrderRepository : IBaseRepository<Order>
    {
        Task<decimal> GetTotal(Guid id);
    }
}
