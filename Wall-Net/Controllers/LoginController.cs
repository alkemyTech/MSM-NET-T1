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
using BCrypt.Net;

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
        public IActionResult Login([FromBody] LoginUser userLogin)
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

        private User Authenticate(LoginUser userLogin)
        {
            var currentUser = _dbContext.Users.FirstOrDefault(user => user.Email.ToLower() == userLogin.Email.ToLower());

            if (currentUser != null)
            {
                var passwordMatched = BCrypt.Net.BCrypt.Verify(userLogin.Password, currentUser.Password);
                if (passwordMatched)
                {
                    return currentUser;
                }
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
            var rol = _dbContext.Roles.FirstOrDefault(p => p.Id == user.Rol_Id);
            var points = user.Points;

            var id = user.Id;

            //Crea los Claims
            var subject = new ClaimsIdentity(new[]
                    {
                    new Claim(ClaimTypes.GivenName,user.FirstName),
                    new Claim(ClaimTypes.NameIdentifier, user.FirstName),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Surname, user.LastName),
                    new Claim(ClaimTypes.Role,rol.Name),
                    new Claim("Points",Convert.ToString(points)),
                    new Claim("Id",Convert.ToString(id))
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
        [HttpGet]
        public async Task<ActionResult<User>> Get()
        {
            var currentUser = GetCurrentUser();

            if (currentUser != null)
            {
                return Ok(currentUser);
            }
            else
            {
                return Unauthorized();
            }
        }

        private User GetCurrentUser()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;

            if (identity != null)
            {
                var userClaim = identity.Claims;
                return new User
                {
                    FirstName = userClaim.FirstOrDefault(o => o.Type == ClaimTypes.NameIdentifier)?.Value,
                    Email = userClaim.FirstOrDefault(o => o.Type == ClaimTypes.Email)?.Value,
                    LastName = userClaim.FirstOrDefault(o => o.Type == ClaimTypes.Surname)?.Value
                };
            }

            return null;
        }

    }
}