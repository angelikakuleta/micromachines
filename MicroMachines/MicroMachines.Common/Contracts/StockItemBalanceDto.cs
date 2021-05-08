using System;

namespace MicroMachines.Common.Contracts
{
    public record StockItemBalanceDto(Guid ProductId, int Amount, Guid StockId, string StockName);
}
