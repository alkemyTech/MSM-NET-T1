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
            try
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
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal Server Error" });
            }
        }
        [HttpGet("{id}")]
        //[Authorize]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var account = await _accountServices.GetById(id);
                if (account == null)
                {
                    return NotFound("No se encontro la cuenta");
                }
                return Ok(account);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal Server Error" });
            }
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Account account)
        {
            try
            {
                await _accountServices.Insert(account);
                return CreatedAtAction(nameof(Get), new { id = account.Id }, account);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal Server Error" });
            }
        }
        [HttpPut]
        public async Task<IActionResult> Put(int id, [FromBody] Account updateAccount)
        {
            try
            {
                var account = await _accountServices.GetById(id);
                if (account == null)
                {
                    return NotFound();
                }
                await _accountServices.Update(account);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal Server Error" });
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) 
        {
            try
            {
                var account = await _accountServices.GetById(id);
                if (account == null)
                {
                    return NotFound();
                }
                await _accountServices.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal Server Error" });
            }
        }
        //Bloqueo de cuenta
        [Authorize]
        [HttpPatch("user/block/{id}")]
        public async Task<ActionResult> BlockAccount(int id)
        {
            try
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
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal Server Error" });
            }
        }
        //Desbloqueo de cuenta
        //[Authorize]
        [HttpPatch("user/unlock/{id}")]
        public async Task<ActionResult> UnlockAccount(int id)
        {
            try
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
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal Server Error" });
            }
        }
    }
}
