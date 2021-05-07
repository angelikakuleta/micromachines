using MicroMachines.Services.Identity.Dtos;
using MicroMachines.Services.Identity.Data.Models;

namespace MicroMachines.Services.Identity.Mappers
{
    public static class UserExtensions
    {
        public static UserDto ToDto(this User user)
        {
            return new UserDto(user.Id, user.FirstName, user.LastName, user.Email, user.PhoneNo, user.Address);
        }

        public static User FromDto(this User user, UpdateUserDto dto)
        {
            user.FirstName = dto.FirstName ?? user.FirstName;
            user.LastName = dto.LastName ?? user.LastName;
            user.PhoneNo = dto.PhoneNo ?? user.PhoneNo;
            user.Address = dto.Address ?? user.Address;

            return user;
        }
    }
}
