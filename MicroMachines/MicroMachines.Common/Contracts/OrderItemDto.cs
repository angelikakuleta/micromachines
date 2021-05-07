using System;
using System.ComponentModel.DataAnnotations;

namespace MicroMachines.Common.Contracts
{
    public record OrderItemDto(Guid ProductId, string ProductName, decimal UnitPrice, int Quantity);
    public record CreateOrderItemDto([Required]Guid ProductId, [Required, Range(1, 999)] int Quantity);
}
