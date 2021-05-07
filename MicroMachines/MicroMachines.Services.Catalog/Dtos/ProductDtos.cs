using System;

namespace MicroMachines.Services.Catalog.Dtos
{
    public record ProductDto(Guid Id, string Name, Guid CategoryId, string CategoryName, decimal Price);
}