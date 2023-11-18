using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Wall_Net.Models;
using Wall_Net.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Wall_Net.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : Controller
    {
        private readonly IRolesServices _rolesServices;

        public RolesController(IRolesServices rolesServices)
        {
            _rolesServices = rolesServices;
        }

        
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var roles = await _rolesServices.GetAllRoles();
                return Ok(roles);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal Server Error" });
            }
        }

        // GET api/Roles/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var rol = await _rolesServices.GetRolesById(id);
                if (rol != null)
                {
                    return Ok(rol);
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal Server Error" });
            }
        }

        // POST api/Roles
        [HttpPost]
        public async Task<IActionResult> Post(Roles rol)
        {
            try
            {
                if (rol.Name == "Admin" || rol.Name == "Regular")
                {
                    await _rolesServices.AddRoles(rol);
                    return CreatedAtAction(nameof(Get), new { Id = rol.Id }, rol);
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal Server Error" });
            }
        }

        // PUT api/Roles
        [HttpPut]
        [Authorize]
        public async Task<IActionResult> Put(Roles updateRol)
        {
            try
            {
                var rol = await _rolesServices.GetRolesById(updateRol.Id);
                if (rol == null)
                {
                    return NotFound();
                }
                else if (updateRol.Name == "Admin" || updateRol.Name == "Regular")
                {

                    rol.Name = updateRol.Name;
                    rol.Description = updateRol.Description;

                    await _rolesServices.UpdateRoles(rol);
                    return NoContent();
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal Server Error" });
            }
        }

        // DELETE api/Roles/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var rol = await _rolesServices.GetRolesById(id);

                if (rol == null)
                {
                    return NotFound();
                }

                await _rolesServices.DeleteRoles(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal Server Error" });
            }
        }
    }
}
