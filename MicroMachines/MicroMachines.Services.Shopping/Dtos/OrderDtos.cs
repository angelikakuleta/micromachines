using MicroMachines.Common.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MicroMachines.Services.Shopping.Dtos
{
    public record OrderDto(Guid Id, Guid PurchasedBy, DateTime PurchaseDate, string Status, decimal Total, IList<OrderItemDto> Itenarary);

    public record CreateOrderDto()
    {
        [Required]
        public Guid PurchasedBy { get; set; }

        [Required, MinLength(1)]
        public IEnumerable<CreateOrderItemDto> Itenarary { get; set; }
    };
}
