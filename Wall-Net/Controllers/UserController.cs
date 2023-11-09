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
        public async Task <IActionResult> Get()
        {
            var users = await _userServices.GetAllUsers();
            return Ok(users);
        }

        [HttpGet("{Id}")]
        public async Task <IActionResult> Get(int Id)
        {
            var user = await _userServices.GetUserById(Id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public async Task <IActionResult> Post(User user)
        {
            await _userServices.AddUser(user);
            return CreatedAtAction(nameof(Get), new { Id = user.Id }, user);
        }


        [HttpPut("{Id}")]
        public async Task <IActionResult> Put(int Id, User updatedUser)
        {
            var user = await _userServices.GetUserById(Id);
            if (user == null)
            {
                return NotFound();
            }
            user.FirstName = updatedUser.FirstName;
            user.LastName = updatedUser.LastName;
            user.Points = updatedUser.Points;
            await _userServices.UpdateUser(user);
            return NoContent();
        }

        [HttpDelete("{Id}")]
        public async Task <IActionResult> Delete(int Id)
        {
            var user = await _userServices.GetUserById(Id);
            if (user == null)
            {
                return NotFound();
            }
            await _userServices.DeleteUserbyId(Id);
            return NoContent();
        }
    }
}
