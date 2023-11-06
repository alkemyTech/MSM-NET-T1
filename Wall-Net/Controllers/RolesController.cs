using Microsoft.AspNetCore.Mvc;
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
            _rolesServices=rolesServices;
        }

        // GET: api/<RolesController>
        [HttpGet]
        public IActionResult Get()
        {
            var roles=_rolesServices.GetAllRoles();
            return Ok(roles);
        }

        // GET api/<RolesController>/{id}
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var rol=_rolesServices.GetRolesById(id);
            if(rol != null)
            {
                return Ok(rol);
            }
            return NotFound();
        }

        // POST api/<RolesController>
        [HttpPost]
        public IActionResult Post(Roles rol)
        {
            _rolesServices.AddRoles(rol);
            return CreatedAtAction(nameof(Get), new { Id = rol.Id }, rol);
        }

        // PUT api/<RolesController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, Roles updateRol)
        {
            var rol = _rolesServices.GetRolesById(id);
            if (rol == null)
            {
                return NotFound();
            }
            rol.Name = updateRol.Name;
            rol.Description = updateRol.Description;

            _rolesServices.UpdateRoles(rol);
            return NoContent();
        }

        // DELETE api/<RolesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var rol = _rolesServices.GetRolesById(id);
            if(rol  != null)
            {
                _rolesServices.DeleteRoles(id);
                return NoContent();
            }
            return NotFound();
        }
    }
}
