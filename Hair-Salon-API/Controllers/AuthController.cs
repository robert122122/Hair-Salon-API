using AutoMapper;
using Hair_Salon_API.Models;
using Hair_Salon_API.Services.Interfaces;
using Hair_Salon_API.Services.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Hair_Salon_API.Controllers
{

    [Route("api/authenticate")]
    [ApiController]
    public class AuthController:ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ISalonService _salonService;
        private readonly IMapper _mapper;

        public AuthController(IUserService userService, IMapper mapper, ISalonService salonService)
        {
            _userService = userService;
            _salonService = salonService;
            _mapper = mapper;
        }

        [HttpPost, Route("login")]
        public async Task<IActionResult> Login([FromBody] AuthenticateRequest user, string role)
        {

            if (user == null)
                return BadRequest("Invalid Client Request");

            if(role == "User")
            {
                var response = await _userService.Authenticate(user);

                if (response != null)
                {
                    var claims = new List<Claim>
                {
                     new Claim(ClaimTypes.Name, user.Email),
                    new Claim(ClaimTypes.Role, role)
                };

                    var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
                    var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                    var tokenOptions = new JwtSecurityToken(
                        issuer: "https://localhost:4200",
                        audience: "https://localhost:4200",
                        claims: claims,
                        expires: DateTime.Now.AddMinutes(30),
                        signingCredentials: signingCredentials
                        );

                    var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
                    return Ok(new AuthenticateResponse(response, tokenString));
                }
            }

            else if(role == "Salon")
            {
                var response = await _salonService.Authenticate(user);

                if (response != null)
                {
                    var claims = new List<Claim>
                {
                     new Claim(ClaimTypes.Name, user.Email),
                    new Claim(ClaimTypes.Role, role)
                };

                    var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
                    var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                    var tokenOptions = new JwtSecurityToken(
                        issuer: "https://localhost:4200",
                        audience: "https://localhost:4200",
                        claims: claims,
                        expires: DateTime.Now.AddMinutes(30),
                        signingCredentials: signingCredentials
                        );

                    var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
                    return Ok(new SalonAuthenticateResponse(response, tokenString));
                }
            }




            return Unauthorized();
        }
    }
}
