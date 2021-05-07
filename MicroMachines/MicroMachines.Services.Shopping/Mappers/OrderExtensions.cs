using MicroMachines.Common.Contracts;
using MicroMachines.Services.Shopping.Data.Models;
using MicroMachines.Services.Shopping.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MicroMachines.Services.Shopping.Mappers
{
    public static class OrderExtensions
    {
        public static OrderDto ToDto(this Order order)
        {
            var itenarary = order.Itenarary.Select(x => new OrderItemDto(x.ProductId, x.ProductName, x.UnitPrice, x.Quantity)).ToList();
            return new OrderDto(order.Id, order.PurchasedBy, order.PurchaseDate, order.Status.ToString(), order.Total, itenarary);
        }

        public static Order ToOrder(this CreateOrderDto dto, IReadOnlyCollection<OrderItemDto> orderItemDtos)
        {
            var order = new Order
            {
                PurchasedBy = dto.PurchasedBy,
                PurchaseDate = DateTime.UtcNow,
                Status = OrderStatus.Pending
            };

            order.Itenarary = orderItemDtos.Select(x => new OrderItem
            {
                OrderId = order.Id,
                ProductId = x.ProductId,
                ProductName = x.ProductName,                
                UnitPrice = x.UnitPrice,
                Quantity = x.Quantity
            }).ToList();

            return order;
        }

        public static void FromDto(this OrderItem item, OrderItemDto dto)
        {
            item.ProductName = dto.ProductName;
            item.UnitPrice = dto.UnitPrice;
        }
    }
}
