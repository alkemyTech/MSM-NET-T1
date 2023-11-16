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
            var fixeds = await _FixedTernDepositServices.GetAllFixedTermDeposit();
            var fixedDTO= _mapper.Map<List<FixedTermsDepositDTO>>(fixeds);
            var ordenFechaFixed = fixedDTO.OrderBy(p => p.creation_date);
            return Ok(ordenFechaFixed);
        }

        // GET api/FixedTermDepositController/{id}
        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> Get(int id)
        {
            var fixedTerm= await _FixedTernDepositServices.GetFixedTermDepositById(id);
            if (fixedTerm == null)
            {
                return NotFound();
            }
            return Ok(fixedTerm);
        }

        [HttpGet("/Fixed/{idFixed}")]
        [Authorize]
        public async Task<IActionResult> GetDetailsFixedById(int idFixed)
        {
              
                var fixedTerms = await _FixedTernDepositServices.GetAllById(idUser());
                var fixedTerm = await _FixedTernDepositServices.GetFixedTermDepositById(idFixed);
                if (fixedTerms == null || fixedTerm==null)
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


        // GET api/Fixed
        
        [HttpGet("/Fixed/AllMyFixed")]
        [Authorize]
        public async Task<IActionResult> GetMyFixed()
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

        // POST api/FixedTermDepositController
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post(FixedTermsDepositDTO fixedDTO)
        {
            if (ModelState.IsValid )
            {
               
                await _FixedTernDepositServices.AddFixedTermDeposit(fixedDTO,idUser());
                return Ok("Su plazo fijo fue creado con exito");
      
            }

            return BadRequest();
        }

        // PUT api/FixedTermDepositController
        [HttpPut]
        [Authorize]
        public async Task<IActionResult> Put(FixedTermDeposit updateFixedTerm)
        {
            if(ModelState.IsValid)
            {
                var fixedTerm = await _FixedTernDepositServices.GetFixedTermDepositById(updateFixedTerm.Id);
                if (fixedTerm == null)
                {
                    return NotFound();
                }
                fixedTerm.amount = updateFixedTerm.amount;
                fixedTerm.creation_date = updateFixedTerm.creation_date;
                fixedTerm.closing_date = updateFixedTerm.closing_date;
                fixedTerm.nominalRate = updateFixedTerm.nominalRate;
                fixedTerm.state = updateFixedTerm.state;

                await _FixedTernDepositServices.UpdateFixedTermDeposit(fixedTerm);
                return NoContent();
            }
            return BadRequest();
            
        }

        // DELETE api/FixedTermDepositController/{id}
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            var fixedTerm = await _FixedTernDepositServices.GetFixedTermDepositById(id);
            if( fixedTerm == null)
            {
                return NotFound();
            }
            await _FixedTernDepositServices.DeleteFixedTermDeposit(id);
            return NoContent();
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
