using MicroMachines.Services.Shopping.Data.Models;
using MicroMachines.Services.Shopping.Dtos;
using System;
using System.Linq;

namespace MicroMachines.Services.Shopping.Mappers
{
    public static class TransactionExtensions
    {
        public static Transaction ToTransaction(this CreateTransactionDto dto)
        {
            return new Transaction
            {
                AccountFromId = dto.AccountFromId,
                AccountToId = dto.AccountToId,
                TimeStamp = DateTime.UtcNow,
                Amount = dto.Amount,
                Status = TransactionStatus.Unconfirmed
            };
        }
    }
}
