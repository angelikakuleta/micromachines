using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MicroMachines.Services.Identity.Dtos;
using MicroMachines.Services.Identity.Mappers;
using MicroMachines.Services.Identity.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace MicroMachines.Services.Identity.Controllers 
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase 
    {
        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository) {
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> Get()
        {
            var users = await _userRepository.GetAll();
            return Ok(users.Select(x => x.ToDto()));
        }

        [HttpGet("{id:Guid}")]
        public async Task<ActionResult<UserDto>> Get(Guid id)
        {
            var user = await _userRepository.GetSingle(x => x.Id == id);
            if (user == null) return NotFound();

            return Ok(user.ToDto());
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<ActionResult<UserDto>> Update(Guid id, [FromBody] UpdateUserDto updateUserDto)
        {
            var user = await _userRepository.GetSingle(x => x.Id == id);
            if (user == null) return NotFound();

            user.FromDto(updateUserDto);
            await _userRepository.Edit(user);
            return AcceptedAtAction(nameof(Get), user.Id, user.ToDto());
        }

        [HttpGet]
        [Route("{id:Guid}/accounts")]
        public async Task<ActionResult<IEnumerable<AccountDto>>> GetAccounts(Guid id) {
            var user = await _userRepository.GetSingle(x => x.Id == id);
            if (user == null) return NotFound();

            var accounts  = (await _userRepository.GetAccounts(id)).Select(x => x.ToDto());
            return Ok(accounts);
        }
    }
}
