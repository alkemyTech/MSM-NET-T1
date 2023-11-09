using Microsoft.AspNetCore.Mvc;
using Wall_Net.Models;
using Wall_Net.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Wall_Net.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FixedTermDepositController : Controller
    {
        private readonly IFixedTermDepositServices _FixedTernDepositServices;

        public FixedTermDepositController(IFixedTermDepositServices FixedTernDepositServices)
        {
            _FixedTernDepositServices = FixedTernDepositServices;
        }

        // GET: api/FixedTermDepositController
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var fixeds = await _FixedTernDepositServices.GetAllFixedTermDeposit();
            return Ok(fixeds);
        }

        // GET api/FixedTermDepositController/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var fixedTerm= await _FixedTernDepositServices.GetFixedTermDepositById(id);
            if (fixedTerm == null)
            {
                return NotFound();
            }
            return Ok(fixedTerm);
        }

        // POST api/FixedTermDepositController
        [HttpPost]
        public async Task<IActionResult> Post(FixedTermDeposit fixedTerm)
        {
            await _FixedTernDepositServices.AddFixedTermDeposit(fixedTerm);
            return CreatedAtAction(nameof(Get), new { Id = fixedTerm.Id }, fixedTerm);
        }

        // PUT api/FixedTermDepositController
        [HttpPut]
        public async Task<IActionResult> Put(FixedTermDeposit updateFixedTerm)
        {
            var fixedTerm = await _FixedTernDepositServices.GetFixedTermDepositById(updateFixedTerm.Id);
            if(fixedTerm == null)
            {
                return NotFound();
            }
            fixedTerm.amount = updateFixedTerm.amount;
            fixedTerm.creation_date = updateFixedTerm.creation_date;
            fixedTerm.closing_date= updateFixedTerm.closing_date;
            fixedTerm.nominalRate= updateFixedTerm.nominalRate;
            fixedTerm.state = updateFixedTerm.state;

            await _FixedTernDepositServices.UpdateFixedTermDeposit(fixedTerm);
            return NoContent();
        }

        // DELETE api/FixedTermDepositController/{id}
        [HttpDelete("{id}")]
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
    }
}
