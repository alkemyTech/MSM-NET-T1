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
        
    }
}
