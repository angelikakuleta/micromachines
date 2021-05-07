using MicroMachines.Common;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MicroMachines.Services.Shopping.Data.Models
{
    public class Transaction : Entity
    {
        public Guid AccountFromId { get; set; }
        public Guid AccountToId { get; set; }
        public DateTime TimeStamp { get; set; }
        public decimal Amount { get; set; }
        public TransactionStatus Status { get; set; }
    }

    public enum TransactionStatus { Unconfirmed, Confirmed }
}
