using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Security.Principal;
using Wall_Net.DataAccess;
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
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Get(int? numpag)
        {
            var accounts = await _accountServices.GetAll();

            if (accounts != null)
            {
                int cantidadRegistros = 5;
                var data = await Paginacion<Account>.CrearPaginacion(accounts, numpag ?? 1, cantidadRegistros);

                if (numpag.HasValue && (numpag < 1 || numpag > data.PaginasTotales))
                {
                    var pagNoEncontrada = new
                    {
                        Status = NotFound(),
                        message = "Página no encontrada",
                    };
                    return BadRequest(pagNoEncontrada);
                }

                string url = $"{Request.Scheme}://{Request.Host}{Request.Path}";
                string pagSig = data.PaginaInicio < data.PaginasTotales ? $"{url}?numpag={data.PaginaInicio + 1}" : null;
                string pagAnt = data.PaginaInicio > 1 ? $"{url}?numpag={data.PaginaInicio - 1}" : null;
                var respuesta = new
                {
                    Status = Ok(),
                    PaginaSiguiente = pagSig,
                    PaginaAnterior = pagAnt,
                    Response = data
                };

                return Ok(respuesta);
            }
            else
            {
                return NotFound("No se encontraron cuentas");
            }
        }
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
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
        public async Task<IActionResult> Post()
        {
            var currentUser = GetCurrentUserId();
            int id = currentUser.Id;

            var eAccount = await _accountServices.GetByUserId(id);
            if (eAccount != null)
            {
                return BadRequest("Este usuario ya posee una cuenta");
            }
            var newAccount = new Account
            {
                Money = 0,  // Inicializar el campo Money con cero.
                UserId = currentUser.Id  // Asignar el ID del usuario actual.
            };
            await _accountServices.Insert(newAccount);
            return StatusCode(201, new { message = "La cuenta ha sido creada exitosamente." });

        }
        [HttpPost("Deposito/{id}")]
        public async Task<IActionResult> Deposito(int id, [FromBody] Account account)
        {
            try
            {
                var currentUser = GetCurrentUserId();
                int idCurrent = currentUser.Id;
                if (id == idCurrent)
                {
                    var eAccount = await _accountServices.GetByUserId(id);
                    if (eAccount != null)
                    {
                        eAccount.Money += account.Money;
                        //await _accountServices.Update(eAccount);
                        var transaction = new Transaction
                        {
                            Amount = account.Money,
                            AccountId = eAccount.Id,
                            Concept = "Deposito",
                            Type = "topup",
                            UserId = currentUser.Id,
                        };
                        eAccount.Transactions.Add(transaction);
                        decimal points = account.Money * 2 / 100;
                        eAccount.User.Points += points;
                        await _accountServices.Update(eAccount);
                    }
                    return StatusCode(201, new { message = "El deposito se genero satisfactoriamente" });
                }
                else
                {
                    return StatusCode(400, new { message = "El Id ingresado no corresponde a su cuenta" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal Server Error" });
            }
        }
        [HttpPost("Transferencia/{id}")]
        public async Task<IActionResult> Transferencia(int id, [FromBody] Account account)
        {
            try
            {
                var currentUser = GetCurrentUserId();
                var sendAccount = await _accountServices.GetByUserId(currentUser.Id);



                var recAccount = await _accountServices.GetByUserId(id);
                if (recAccount != null)
                {
                    if (sendAccount.Money > 100)
                    {
                        var montoTransferido = account.Money;
                        sendAccount.Money -= montoTransferido;
                        recAccount.Money += montoTransferido;
                        await _accountServices.Update(recAccount);
                    }
                    else
                    {
                        return BadRequest("Tu Saldo es insuficiente");
                    }

                    //await _accountServices.Update(eAccount);
                    var transaction = new Transaction
                    {
                        Amount = account.Money,
                        AccountId = currentUser.Id,
                        Concept = "Transferencia",
                        Type = "topup",
                        UserId = currentUser.Id,
                        ToAccountId = recAccount.Id,
                    };
                    sendAccount.Transactions.Add(transaction);
                    decimal points = account.Money * 3 / 100;
                    sendAccount.User.Points += points;
                    await _accountServices.Update(sendAccount);
                }
                return StatusCode(201, new { message = "El deposito se genero satisfactoriamente" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal Server Error" });
            }
        }
        [HttpPut]
        public async Task<IActionResult> Put(int id, [FromBody] Account updateAccount)
        {
            var account = await _accountServices.GetById(id);
            if (account == null)
            {
                return NotFound();
            }
            updateAccount.Money = account.Money;
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

            return Ok();
        }
        private User GetCurrentUserId()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                var userIdClaim = identity.FindFirst("Id");

                if (userIdClaim != null && int.TryParse(userIdClaim.Value, out int userId))
                {
                    return new User
                    {
                        Id = userId
                    };
                }
            }
            return null;
        }

    }
}