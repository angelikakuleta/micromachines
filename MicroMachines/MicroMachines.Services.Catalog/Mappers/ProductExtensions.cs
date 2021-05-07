using MicroMachines.Services.Catalog.Dtos;
using MicroMachines.Services.Catalog.Data.Models;

namespace MicroMachines.Services.Catalog.Mappers
{
    public static class ProductExtensions
    {
        public static ProductDto ToDto(this Product product)
        {
            return new ProductDto(product.Id, product.Name, product.CategoryId, product.Category.Name, product.Price);
        }
    }
}
