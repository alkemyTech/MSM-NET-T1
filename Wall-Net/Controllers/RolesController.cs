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
        private readonly int records = 2;

        public RolesController(IRolesServices rolesServices)
        {
            _rolesServices = rolesServices;
        }

        
        [HttpGet]
        public async Task<IActionResult> Get([FromBody] int? page)
        {
            var roles = await _rolesServices.GetAllRoles();

            int _page = page ?? 1;
            int total_roles = roles.Count();
            int total_pages = Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(total_roles / records)));

            var allRoles = roles
                .Skip((_page - 1) * records)
                .Take(records)
                .ToList();

            return Ok(new
            {
                pages = total_pages,
                roles = allRoles,
                current_page = _page
            });
        }

        // GET api/Roles/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var rol= await _rolesServices.GetRolesById(id);
            if(rol != null)
            {
                return Ok(rol);
            }
            return NotFound();
        }

        // POST api/Roles
        [HttpPost]
        public async Task<IActionResult> Post(Roles rol)
        {
            if(rol.Name == "Admin" || rol.Name == "Regular")
            {
                await _rolesServices.AddRoles(rol);
                return CreatedAtAction(nameof(Get), new { Id = rol.Id }, rol);
            }
            return BadRequest();
        }

        // PUT api/Roles
        [HttpPut]
        [Authorize]
        public async Task<IActionResult> Put(Roles updateRol)
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

        // DELETE api/Roles/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var rol = await _rolesServices.GetRolesById(id);

            if(rol  == null)
            {
                return NotFound();
            }

            await _rolesServices.DeleteRoles(id);
            return NoContent();
        }
    }
}
