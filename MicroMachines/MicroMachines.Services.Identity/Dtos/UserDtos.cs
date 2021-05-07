using System;
using System.ComponentModel.DataAnnotations;

namespace MicroMachines.Services.Identity.Dtos
{
    public record UserDto(Guid Id, string FirstName, string LastName, string Email, string PhoneNo, string Address);

    public record UpdateUserDto()
    {
        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }

        [Phone]
        public string PhoneNo { get; set; }

        [MaxLength(200)]
        public string Address { get; set; }
    };
}
