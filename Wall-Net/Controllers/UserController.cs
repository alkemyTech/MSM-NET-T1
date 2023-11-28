using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Wall_Net.Models;
using Wall_Net.Services;

namespace Wall_Net.Controllers
{   
        [ApiController]
        [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserServices _userServices;

        public UserController(IUserServices userServices)
        {
            _userServices = userServices;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task <IActionResult> Get(int pageNumber = 1, int pageSize = 10)
        {
            try
            {
                var users = await _userServices.GetAllUsers(pageNumber, pageSize);
                return Ok(users);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal Server Error" });
            }
        }

        [HttpGet("{Id}")]
        [Authorize]
        public async Task <IActionResult> Get(int Id)
        {
            try
            {
                var user = await _userServices.GetUserById(Id);
                if (user == null)
                {
                    return NotFound();
                }
                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal Server Error" });
            }
        }

        [HttpPost]
        //[Authorize]
        public async Task <IActionResult> Post(User user)
        {
            try
            {
                //Comprobar si los campos enviados son correectos
                if (!ModelState.IsValid)
                {
                    return BadRequest("El usuario no se creo exitosamente.");
                }

                // Comprobar si el correo electrónico ya existe
                var users = await _userServices.GetAllUsers(1, 10);
                foreach (var u in users)
                {
                    if (u.Email == user.Email)
                    {
                        return BadRequest("El correo electrónico ya existe.");
                    }
                }

                user.Rol_Id = 2;

                await _userServices.AddUser(user);

                var newUser = await _userServices.GetUserById(user.Id);

                var newAccount = new Account
                {
                    CreationDate = DateTime.Now,
                    Money = 0,
                    IsBlocked = false,
                    UserId = user.Id,
                };

                if (newUser.Account == null)
                {
                    newUser.Accounts.Add(newAccount);
                }

                await _userServices.UpdateUser(newUser);

                return CreatedAtAction(nameof(Get), new { Id = user.Id }, user);

                
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal Server Error" });
            }
        }

        [Authorize]
        [HttpPut("{Id}")]
        public async Task <IActionResult> Put(int Id, User updatedUser)
        {
            try
            {
                var user = await _userServices.GetUserById(Id);
                if (user == null)
                {
                    return NotFound();
                }
                user.FirstName = updatedUser.FirstName;
                user.LastName = updatedUser.LastName;
                //user.Points = updatedUser.Points;
                await _userServices.UpdateUser(user);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal Server Error" });
            }
        }

        [Authorize]
        [HttpDelete("{Id}")]
        public async Task <IActionResult> Delete(int Id)
        {
            try
            {
                var user = await _userServices.GetUserById(Id);
                if (user == null)
                {
                    return NotFound();
                }
                await _userServices.DeleteUserbyId(Id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal Server Error" });
            }
        }
    }
}
