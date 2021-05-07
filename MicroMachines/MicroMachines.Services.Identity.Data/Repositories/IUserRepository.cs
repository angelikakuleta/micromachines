using MicroMachines.Common;
using MicroMachines.Services.Identity.Data.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MicroMachines.Services.Identity.Data.Repositories
{
    public interface IUserRepository : IBaseRepository<User> {
        Task<IList<Account>> GetAccounts(Guid id);
    }
}