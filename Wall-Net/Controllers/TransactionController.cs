using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Wall_Net.Models;
using Wall_Net.Models.DTO;
using Wall_Net.Services;
using static StackExchange.Redis.Role;

[Route("api/transactions")]
[ApiController]
public class TransactionController : ControllerBase
{
    private readonly ITransactionService _transactionService;
    public readonly IMapper _mapper;

    public TransactionController(ITransactionService transactionService, IMapper mapper)
    {
        _transactionService = transactionService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllTransactions()
    {
        try
        {
            var transactions = await _transactionService.GetAllTransactionsAsync();
            var transactionsDTO = _mapper.Map<List<TransactionDTO>>(transactions);
            return Ok(transactionsDTO);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Internal Server Error" });
        }
    }

    [HttpGet("Transaction/AllTransaction")]
    [Authorize]
    public async Task<IActionResult> GetAllMyTransaction()
    {
        try
        {
            var transaction = await _transactionService.GetAllById(idUser());
            if (transaction == null)
            {
                return NotFound();
            }
            var transactionDTO = _mapper.Map<List<TransactionDTO>>(transaction);
            return Ok(transactionDTO);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Internal Server Error" });
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetTransaction(int id)
    {

        try
        {
            var transaction = await _transactionService.GetTransactionByIdAsync(id);

            if (transaction == null)
            {
                return NotFound();
            }

            return Ok(transaction);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Internal Server Error" });
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateTransaction([FromBody] Transaction transaction)
    {
        try
        {
            if (transaction == null)
            {
                return BadRequest("Invalid transaction data");
            }

            await _transactionService.AddTransactionAsync(transaction);

            return CreatedAtAction("GetTransaction", new { id = transaction.TransactionId }, transaction);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Internal Server Error" });
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTransaction(int id, [FromBody] Transaction transaction)
    {
        try
        {
            var existingTransaction = await _transactionService.GetTransactionByIdAsync(id);

            if (existingTransaction == null)
            {
                return NotFound();
            }

            await _transactionService.UpdateTransactionAsync(transaction);

            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Internal Server Error" });
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTransaction(int id)
    {
        try
        {
            var transaction = await _transactionService.GetTransactionByIdAsync(id);

            if (transaction == null)
            {
                return NotFound();
            }

            await _transactionService.DeleteTransactionAsync(id);

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
