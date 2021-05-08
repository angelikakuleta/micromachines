using MicroMachines.Common;
using System;
using System.Collections.Generic;

namespace MicroMachines.Services.Catalog.Data.Models
{
    public class Stock : Entity
    {
        public string Name { get; set; }
        public IList<ItemBalance> Balances { get; set; }
    }
}
