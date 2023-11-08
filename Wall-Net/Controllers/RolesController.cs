﻿using Microsoft.AspNetCore.Mvc;
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

        // GET: api/Roles
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var roles= await _rolesServices.GetAllRoles();
            return Ok(roles);
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
        public async Task<IActionResult> Put(Roles updateRol)
        {
            var rol = await _rolesServices.GetRolesById(updateRol.Id);
            if (rol == null)
            {
                return NotFound();
            }
            else if (updateRol.Name == "Admin" || updateRol.Name == "Regular")
            {
                return BadRequest();
            }

            rol.Name = updateRol.Name;
            rol.Description = updateRol.Description;

            await _rolesServices.UpdateRoles(rol);
            return NoContent();
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