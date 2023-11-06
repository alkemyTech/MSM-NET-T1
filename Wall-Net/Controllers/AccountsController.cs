using Microsoft.AspNetCore.Mvc;
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
    }
}
