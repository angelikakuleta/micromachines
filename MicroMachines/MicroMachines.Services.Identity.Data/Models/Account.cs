using MicroMachines.Common;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MicroMachines.Services.Identity.Data.Models {
    public class Account : Entity
    {
        public string Name { get; set; }
        public decimal Balance { get; set; }
        public bool IsClosed { get; set; }

        [ForeignKey("User")]
        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
