using MicroMachines.Services.Identity.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace MicroMachines.Services.Identity.Data.Context
{
    public static class UserContextSeeder
    {
        public static void SeedDatabase(this UserContext context, ModelBuilder modelBuilder)
        {
            var user = new User[]
            {
                new User
                {
                    FirstName = "Jesse",
                    LastName = "Durgan",
                    Email = "krfj6benqe@temporary-mail.net",                   
                    PhoneNo = "419-291-7726",
                    Address = "1649  Olive Street, Windermere, FL 34786"
                },
                new User
                {
                    FirstName = "Gary",
                    LastName = "Dodge",
                    Email = "r4zoaylsw4g@temporary-mail.net",
                    PhoneNo = "432-234-2968",
                    Address = "2138  Scenicview Drive, Long Branch, NJ 07740"                  
                }
            };

            var accounts = new Account[]
            {
                new Account { Name = "Personal", UserId = user[0].Id, Balance = 827.80M, IsClosed = false },
                new Account { Name = "Free Credits", UserId = user[0].Id, Balance = 236.42M, IsClosed = true },
                new Account { Name = "Personal", UserId = user[1].Id, Balance = 8.62M, IsClosed = false }
            };

            modelBuilder.Entity<User>().HasData(user);
            modelBuilder.Entity<Account>().HasData(accounts);
        }
    }
}
