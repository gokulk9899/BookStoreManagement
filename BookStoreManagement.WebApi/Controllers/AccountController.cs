
using BookStoreManagement.WebApi.Dtos;
using BookStoreManagement.WebApi.Models;
using BookStoreManagement.WebApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookStoreManagement.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUnitOfWork unitWork;
        private readonly IConfiguration configuration;

        public AccountController(IUnitOfWork unitWork,IConfiguration configuration)
        {
            this.unitWork = unitWork;
            this.configuration = configuration;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginRequestDto userDto) {
            var user = await unitWork.userRepository.Authenticate(userDto.UserName, userDto.Password);
            if (user == null) {
                return Unauthorized();
            }
            var loginResponse = new LoginResponseDto();
            loginResponse.UserId = user.UserId;
            loginResponse.UserName = user.UserName;
            loginResponse.Token = CreateToken(user);
            return Ok(loginResponse);
        }

        private string CreateToken(User user) {
            var secretKey = configuration.GetSection("AppSettings:Key").Value;
            var key = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes(secretKey));

            var claims = new Claim[] {
                new Claim(ClaimTypes.Name,user.UserName),
                new Claim(ClaimTypes.NameIdentifier,user.UserId.ToString())
            };

            var signingCredentials = new SigningCredentials(
                key, SecurityAlgorithms.HmacSha256
                );
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(5),
                SigningCredentials = signingCredentials
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

               

        // POST api/<AccountController>
        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp(UserDto userDto)
        {
            if (await unitWork.userRepository.UserAlreadyRegistered(userDto.UserName)) {
                return BadRequest("User already exists");
            }



            var registeredUser = await Task.FromResult(
                unitWork.userRepository.Register(userDto.UserName, userDto.Password));
            registeredUser.Email = userDto.Email;
            unitWork.userRepository.AddUser(registeredUser);
            await unitWork.SaveAsync();
            return StatusCode(201);
        }

        

        
    }
}
