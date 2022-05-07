using AutoMapper;
using Hair_Salon_API.Models;
using Hair_Salon_API.Services.Interfaces;
using Hair_Salon_API.Services.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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

        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate(AuthenticateRequest model)
        {
            AuthenticateResponse response = await _userService.Authenticate(model);

            if (response == null)
            {
                return BadRequest(new { message = "Username or password is incorrect." });
            }

            return Ok(response);
        }

        [Authorize]
        [HttpGet]
        public async Task<IEnumerable<UserDTO>> Get()
        {
            return _mapper.Map<IEnumerable<UserDTO>>(await _userService.GetUsersAsync());
        }

        [HttpGet("{userId}"),Authorize]
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
