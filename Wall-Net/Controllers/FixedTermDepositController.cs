using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Wall_Net.Models;
using Wall_Net.Models.DTO;
using Wall_Net.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Wall_Net.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FixedTermDepositController : Controller
    {
        private readonly IFixedTermDepositServices _FixedTernDepositServices;
        public readonly IMapper _mapper;

        public FixedTermDepositController(IFixedTermDepositServices FixedTernDepositServices, IMapper mapper)
        {
            _FixedTernDepositServices = FixedTernDepositServices;
            _mapper = mapper;
        }

        // GET: api/FixedTermDepositController
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Get()
        {
            try
            {
                var fixeds = await _FixedTernDepositServices.GetAllFixedTermDeposit();
                var fixedDTO = _mapper.Map<List<FixedTermsDepositDTO>>(fixeds);
                var ordenFechaFixed = fixedDTO.OrderBy(p => p.creation_date);
                return Ok(ordenFechaFixed);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal Server Error" });
            }
        }

        // GET api/FixedTermDepositController/{id}
        [HttpGet("{id}")]
        //[Authorize]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var fixedTerm = await _FixedTernDepositServices.GetFixedTermDepositById(id);
                if (fixedTerm == null)
                {
                    return NotFound();
                }
                return Ok(fixedTerm);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal Server Error" });
            }
        }

        [HttpGet("/Fixed/{idFixed}")]
        [Authorize]
        public async Task<IActionResult> GetDetailsFixedById(int idFixed)
        {
            try
            {
                var fixedTerms = await _FixedTernDepositServices.GetAllById(idUser());
                var fixedTerm = await _FixedTernDepositServices.GetFixedTermDepositById(idFixed);
                if (fixedTerms == null || fixedTerm == null)
                {
                    return NotFound("Usted no posee plazos fijo o el id no corresponde a ningun plazo fijo");
                }
                else if (fixedTerms.Contains(fixedTerm))
                {
                    var fixedDTO = _mapper.Map<FixedTermsDepositDTO>(fixedTerm);
                    return Ok(fixedDTO);
                }
                return NotFound("Usted no posee un plazo fijo correspondiente a este id");
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal Server Error" });
            }
        }
        
        [HttpGet("FixedTermDeposit/AllFixed")]
        [Authorize]
        public async Task<IActionResult> GetMyFixed()
        {
            try
            {
                var fixedTerm = await _FixedTernDepositServices.GetAllById(idUser());
                if (fixedTerm == null)
                {
                    return NotFound();
                }
                var fixedDTO = _mapper.Map<List<FixedTermsDepositDTO>>(fixedTerm);
                var ordenFechaFixed = fixedDTO.OrderBy(p => p.closing_date);
                return Ok(ordenFechaFixed);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal Server Error" });
            }
        }

        // POST api/FixedTermDepositController
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post(int mothFTD, int amount)
        {
            try
            {
                if (mothFTD>=1 && mothFTD<=12)
                {

                    var boolean= await _FixedTernDepositServices.AddFixedTermDeposit(mothFTD, amount, idUser());

                    if (boolean)
                    {
                        return Ok("Su plazo fijo fue creado con éxito");
                    }
                    return BadRequest("Su monto es superior al monto que posee en su cuenta");

                }

                return BadRequest("La cantidad de meses ingresados para el plazo fijo, no es valido.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal Server Error" });
            }
        }

        // PUT api/FixedTermDepositController
        [HttpPut("{Id}")]
        [Authorize]
        public async Task<IActionResult> Put(int Id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var fixedTerm = await _FixedTernDepositServices.GetFixedTermDepositById(Id);
                    if (fixedTerm == null)
                    {
                        return NotFound();
                    }
                    if(fixedTerm.state != "Cerrado")
                    {
                        fixedTerm.closing_date = DateTime.Now;
                        fixedTerm.state = "Cerrado";
                        fixedTerm.Account.Money += fixedTerm.amount;

                        await _FixedTernDepositServices.UpdateFixedTermDeposit(fixedTerm);
                        return NoContent();
                    }

                    return BadRequest("Este plazo fijo ya fue cerrado");
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal Server Error" });
            }
        }

        // DELETE api/FixedTermDepositController/{id}
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var fixedTerm = await _FixedTernDepositServices.GetFixedTermDepositById(id);
                if (fixedTerm == null)
                {
                    return NotFound();
                }
                await _FixedTernDepositServices.DeleteFixedTermDeposit(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal Server Error" });
            }
        }


        private int idUser()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                var id = identity.FindFirst("Id");
                var idFixed = int.TryParse(id.Value, out int userID);

                return userID;
            }
            return 0;
        }
    }
}
