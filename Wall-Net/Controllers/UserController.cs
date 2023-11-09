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
        [Authorize]
        public IActionResult Get()
        {
            var users = _userServices.GetAllUsers();
            return Ok(users);
        }

        [HttpGet("{Id}")]
        public IActionResult Get(int Id)
        {
            var user = _userServices.GetUserById(Id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public IActionResult Post(User user)
        {
            _userServices.AddUser(user);
            return CreatedAtAction(nameof(Get), new { Id = user.Id }, user);
        }


        [HttpPut("{Id}")]
        public IActionResult Put(int Id, User updatedUser)
        {
            var user = _userServices.GetUserById(Id);
            if (user == null)
            {
                return NotFound();
            }
            user.FirstName = updatedUser.FirstName;
            user.LastName = updatedUser.LastName;
            user.Points = updatedUser.Points;
            _userServices.UpdateUser(user);
            return NoContent();
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            var user = _userServices.GetUserById(Id);
            if (user == null)
            {
                return NotFound();
            }
            _userServices.DeleteUserbyId(Id);
            return NoContent();
        }
    }
}
