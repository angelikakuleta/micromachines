using MicroMachines.Services.Identity.Data.Context;
using MicroMachines.Services.Identity.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MicroMachines.Services.Identity.Data.Repositories
{
    public class UserRepository : IUserRepository 
    {
        private readonly UserContext _context; 
        
        public UserRepository(UserContext context)
        {
            _context = context;
            context.Database.EnsureCreated();
        }

        public async Task<User> Add(User entity)
        {
            _context.Users.Add(entity);
            await Save();
            return await GetSingle(x => x.Id == entity.Id);
        }

        public async Task Delete(User entity)
        {
            _context.Users.Remove(entity);
            await Save();
        }

        public async Task<User> Edit(User entity)
        {
            _context.Users.Update(entity);
            await Save();
            return entity;
        }

        public async Task<IList<Account>> GetAccounts(Guid id)
        {
            return await _context.Accounts
                .Where(x => x.UserId == id)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IList<User>> GetAll()
        {
            return await _context.Users
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<User> GetSingle(Expression<Func<User, bool>> condition)
        {
            return (await _context.Users           
                    .Where(condition)
                    .AsNoTracking()
                    .ToListAsync())
                .FirstOrDefault();
        }

        private async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
