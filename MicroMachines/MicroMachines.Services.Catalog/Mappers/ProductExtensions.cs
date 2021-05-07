using MicroMachines.Services.Catalog.Dtos;
using MicroMachines.Services.Catalog.Data.Models;
using MicroMachines.Common.Contracts;

namespace MicroMachines.Services.Catalog.Mappers
{
    public static class ProductExtensions
    {
        public static ProductDto ToDto(this Product product)
        {
            return new ProductDto(product.Id, product.Name, product.CategoryId, product.Category.Name, product.Price);
        }

        public static OrderItemDto ToOrderItemDto(this Product product, int quantity)
        {
            return new OrderItemDto(product.Id, product.Name, product.Price, quantity);
        }
    }
}
