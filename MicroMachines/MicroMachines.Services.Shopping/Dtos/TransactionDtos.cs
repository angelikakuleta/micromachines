using System;
using System.ComponentModel.DataAnnotations;
using System.Transactions;

namespace MicroMachines.Services.Shopping.Dtos
{
    public record TransactionDto(Guid Id, DateTime TimeStamp, decimal Amount, TransactionStatus Status);

    public record CreateTransactionDto()
    {
        [Required]
        public Guid AccountFromId { get; set; }

        [Required]
        public Guid AccountToId { get; set; }

        [Required, Range(0.01, (double)decimal.MaxValue)]
        public decimal Amount { get; set; }
    };
}
