using MicroMachines.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace MicroMachines.Services.Shopping.Data.Models
{
    public class Order : Entity
    {
        public IList<OrderItem> Itenarary { get; set; }
        public Guid PurchasedBy { get; set; }
        public DateTime PurchaseDate { get; set; }

        [ForeignKey("Transaction")]
        public Guid TransactionId { get; set; } 
        public Transaction Transaction { get; set; }

        public OrderStatus Status { get; set; }

        public decimal Total => Itenarary.Sum(x => x.UnitPrice * x.Quantity);
    }

    public enum OrderStatus { Pending, Denied, Confirmed, Cancelled }
}
