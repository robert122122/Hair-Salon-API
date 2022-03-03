using AutoMapper;
using Hair_Salon_API.Models;
using Hair_Salon_API.Services.Interfaces;
using Hair_Salon_API.Services.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hair_Salon_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController:ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<UserDTO>> Get()
        {
            return _mapper.Map<IEnumerable<UserDTO>>(await _userService.GetUsersAsync());
        }

        [HttpGet("{userId}")]
        public async Task<UserDTO> Get(int userId)
        {
            return _mapper.Map<UserDTO>(await _userService.GetUserAsync(userId));
        }

        [HttpPost]
        public async Task<UserDTO> Post(UserPostDTO userToAdd)
        {
            return _mapper.Map<UserDTO>(await _userService.AddUserAsync(_mapper.Map<UserModel>(userToAdd)));
        }

        [HttpPut("{userId}")]
        public async Task<UserDTO> Put(int userId, UserPostDTO userToUpdate)
        {
            return _mapper.Map<UserDTO>(await _userService.UpdateUserAsync(userId, _mapper.Map<UserModel>(userToUpdate)));
        }

        [HttpDelete("{userId}")]
        public async Task<UserDTO> Delete(int userId)
        {
            return _mapper.Map<UserDTO>(await _userService.DeleteUserAsync(userId));
        }
    }
}
