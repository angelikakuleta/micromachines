using MicroMachines.Common;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MicroMachines.Services.Catalog.Data.Models
{
    public class ItemBalance
    {
        [Key]
        public Guid ProductId { get; set; }

        public int Amount { get; set; }

        [ForeignKey("Stock")]
        public Guid StockId { get; set; }
        public Stock Stock { get; set; }
    }
}
