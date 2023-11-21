using Amazon.SecurityToken.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Wall_Net.DataAccess;
using Wall_Net.Models.DTO;
using Wall_Net.Models;
using Wall_Net.Repositories;
using System.Net.WebSockets;

namespace Wall_Net.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        IConfiguration configuration;
        private readonly WallNetDbContext _dbContext;
        public LoginController(IConfiguration configuration, WallNetDbContext dbContext)
        {
            this.configuration = configuration;
            _dbContext = dbContext;
        }

        [AllowAnonymous]
        [HttpPost]
        // POST api/Login
        [HttpPost]
        public IActionResult Login([FromBody] LoginUser userLogin)
        {
            try
            {
                var account = _dbContext.Accounts.FirstOrDefault(account => account.User.Email == userLogin.Email);
                if (account != null && account.IsBlocked)
                {
                    return Unauthorized("Su cuenta se encuentra bloqueada.");
                }

                var user = Authenticate(userLogin);
                IActionResult response = Unauthorized();

                if (user != null)
                {
                    var token = Generate(user);

                    return Ok(token);
                }

                return response;
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal Server Error" });
            }
        }

        private User Authenticate(LoginUser userLogin)
        {
            var currentUser = _dbContext.Users.FirstOrDefault(user => user.Email.ToLower() == userLogin.Email.ToLower()
                                && user.Password == userLogin.Password);

            if (currentUser != null)
            {
                return currentUser;
            }
            return null;
        }

        private string Generate(User user)
        {
            var issuer = configuration["Jwt:Issuer"];
            var audience = configuration["Jwt:Audience"];
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
            var signingCredentials = new SigningCredentials(
                                    key,
                                    SecurityAlgorithms.HmacSha512Signature
                                );

            //Rol del usuario
            var rol = _dbContext.roles.FirstOrDefault(p => p.Id == user.Rol_Id);
            var points = user.Points;
            var id = user.Id;

            //Crea los Claims
            var subject = new ClaimsIdentity(new[]
                    {
                    new Claim("Id", Convert.ToString(user.Id)),
                    new Claim(ClaimTypes.NameIdentifier, user.FirstName),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.GivenName,user.FirstName),
                    new Claim(ClaimTypes.Surname, user.LastName),
                    new Claim(ClaimTypes.Role,rol.Name),
                    new Claim("Points",Convert.ToString(points))
                    });

            //Crea el token
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = subject,
                Expires = DateTime.UtcNow.AddMinutes(10),
                Issuer = issuer,
                Audience = audience,
                SigningCredentials = signingCredentials
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var jwtToken = tokenHandler.WriteToken(token);

            return jwtToken;
        }
    }
}
