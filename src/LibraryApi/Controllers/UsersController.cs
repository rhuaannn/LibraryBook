using AutoMapper;
using LibraryApplication.Interfaces;
using LibraryApplication.Services;
using LibraryDomain.DTOs;
using LibraryDomain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public UsersController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

       
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            var createdUser = await _userService.CreateUserAsync(user);
            return Ok(createdUser);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var user =await _userService.GetAllUsersAsync();
            return Ok(user);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var user =await _userService.GetUserByIdAsync(id);
            return Ok(user);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deleted =await _userService.DeleteUserAsync(id);
            return Ok(deleted);
        }
    }
}
