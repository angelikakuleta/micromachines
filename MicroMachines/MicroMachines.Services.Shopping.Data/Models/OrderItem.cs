using MicroMachines.Common;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MicroMachines.Services.Shopping.Data.Models
{
    public class OrderItem : Entity
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }

        [ForeignKey("Order")]
        public Guid OrderId { get; set; }
        public Order Order { get; set; }
    }
}