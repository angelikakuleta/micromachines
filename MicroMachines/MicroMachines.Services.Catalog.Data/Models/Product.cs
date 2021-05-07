using MicroMachines.Common;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MicroMachines.Services.Catalog.Data.Models
{
    public class Product : Entity
    {
        public string Name { get; set; }

        [ForeignKey("Category")]
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
        
        public decimal Price { get; set; }
    }
}
