using System;

namespace MicroMachines.Services.Identity.Dtos
{
    public record AccountDto(Guid Id, string Name, Guid UserId, decimal Balance, bool IsClosed);
}
