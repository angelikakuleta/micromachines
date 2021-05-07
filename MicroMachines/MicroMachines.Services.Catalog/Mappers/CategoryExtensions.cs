using MicroMachines.Services.Catalog.Dtos;
using MicroMachines.Services.Catalog.Data.Models;

namespace MicroMachines.Services.Catalog.Mappers
{
    public static class CategoryExtensions
    {
        public static CategoryDto ToDto(this Category product)
        {
            return new CategoryDto(product.Id, product.Name);
        }
    }
}
