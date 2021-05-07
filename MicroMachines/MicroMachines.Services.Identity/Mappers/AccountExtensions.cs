using MicroMachines.Services.Identity.Dtos;
using MicroMachines.Services.Identity.Data.Models;

namespace MicroMachines.Services.Identity.Mappers
{
    public static class AccountExtensions
    {
        public static AccountDto ToDto(this Account account)
        {
            return new AccountDto(account.Id, account.Name, account.UserId, account.Balance, account.IsClosed);
        }
    }
}
