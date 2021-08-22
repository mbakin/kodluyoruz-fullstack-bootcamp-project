using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Movies.API.Models;
using Movies.Business;

namespace Movies.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private IUserService userService;
        private IConfiguration config;

        public AccountController(IUserService userService, IConfiguration configuration)
        {
            this.userService = userService;
            this.config = configuration;
        }
        [HttpPost]
        public IActionResult Login(UserLoginModel userLoginModel)
        {
            var user = userService.GetUser(userLoginModel.Email, userLoginModel.Password);
            if (user == null)
            {
                return BadRequest(new {message = "Wrong username or wrong password."});
            }

            // TODO 1: Burada, JWT uretecegiz ve kullaniciya verecegiz.

            string issuer = "kodluyoruz.com";
            string audience = "kodluyoruz.com";
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.userName),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role)

            };
            // var keyFromJson = config.GetSection("Bearer")["securityKey"];
            var key= "azerBaba-basaramadim.mp3";
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credential = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512);

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                notBefore:DateTime.Now,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credential
            );

            return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
        }
    }
}
