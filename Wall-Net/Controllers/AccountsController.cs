using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Wall_Net.Models;
using Wall_Net.Services;

namespace Wall_Net.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountServices _accountServices;
        public AccountsController(IAccountServices accountServices)
        {
            _accountServices = accountServices;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var accounts = await _accountServices.GetAll();
            if (accounts == null)
            {
                return NotFound("No se encontraron cuentas");
            }
            else
            {
                return Ok(accounts);
            }
        }
        [HttpGet("{id}")]
        //[Authorize]
        public async Task<IActionResult> Get(int id)
        {
            var account = await _accountServices.GetById(id);
            if (account == null)
            {
                return NotFound("No se encontro la cuenta");
            }
            return Ok(account);
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Account account)
        {
            await _accountServices.Insert(account);
            return CreatedAtAction(nameof(Get), new { id = account.Id }, account);
        }
        [HttpPut]
        public async Task<IActionResult> Put(int id, [FromBody] Account updateAccount)
        {
            var account = await _accountServices.GetById(id);
            if (account == null)
            {
                return NotFound();
            }
            await _accountServices.Update(account);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) 
        {
            var account = await _accountServices.GetById(id);
            if (account == null)
            {
                return NotFound();
            }
            await _accountServices.Delete(id);
            return Ok();
        }
        //Bloqueo de cuenta
        [Authorize]
        [HttpPatch("user/block/{id}")]
        public async Task<ActionResult> BlockAccount(int id)
        {
            var account = await _accountServices.GetById(id);
            if (account == null)
            {
                return NotFound();
            }
            else if (account.IsBlocked)
            {
                return BadRequest("La cuenta ya está bloqueada.");
            }
            account.IsBlocked = true;
            await _accountServices.Update(account);

            return Ok("La cuenta se ha bloqueado");
        }
        //Desbloqueo de cuenta
        //[Authorize]
        [HttpPatch("user/unlock/{id}")]
        public async Task<ActionResult> UnlockAccount(int id)
        {
            var account = await _accountServices.GetById(id);
            if (account == null)
            {
                return NotFound();
            }
            else if (!account.IsBlocked)
            {
                return BadRequest("La cuenta no se encuentra bloqueada.");
            }
            account.IsBlocked = false;
            await _accountServices.Update(account);

            return Ok("La cuenta se ha desbloqueado");
        }
    }
}
