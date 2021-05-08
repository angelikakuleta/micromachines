using System;
using System.Collections.Generic;

namespace MicroMachines.Services.Catalog.Dtos
{
    public record StockDto(Guid Id, string Name, IEnumerable<ItemBalanceDto> Balances);
    public record ItemBalanceDto(Guid Product, int Amount);
}
