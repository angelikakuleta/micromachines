using MicroMachines.Services.Catalog.Data.Models;
using MicroMachines.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MicroMachines.Services.Catalog.Data.Repositories
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        Task<IList<Product>> GetByCategory(Guid categoryId);
    }
}
