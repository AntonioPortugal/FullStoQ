using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Recodme.RD.FullStoQ.Data.Person;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : BaseController
    {
        private readonly IConfiguration _config;
        public AccountController(IConfiguration config)
        {
            _config = config;
        }

        [HttpGet("CreateRole")]
        public void CreateRole(string roleName)
        {
            var role = new IdentityRole();
            role.Name = roleName;
        }

        [HttpGet("Secret")]
        [Authorize]
        public ActionResult<string> Secret()
        {
            return "All right, keep your secrets then";
        }

        [HttpGet]
        public ActionResult<string> Login()
        {
            var mockUser = new Account(Guid.NewGuid());
            mockUser.Email = "x@wtv.pt";
            mockUser.PasswordHash = "apalavrapassetemdeserfacil";
            return GenerateJsonWebToken(mockUser);
        }

        private string GenerateJsonWebToken(Account user)
        {
            var jwtKey = _config["Jwt:key"];
            var keyBytes = Encoding.UTF8.GetBytes(jwtKey);
            var key = new SymmetricSecurityKey(keyBytes);

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var issuer = _config["Jwt:Issuer"];

            var audience = _config["Jwt:Audience"];

            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Email)
            };

            var token = new JwtSecurityToken(issuer, audience, claims, expires: DateTime.Now.AddHours(2), signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}