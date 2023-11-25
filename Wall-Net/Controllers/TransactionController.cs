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
    public async Task<IActionResult> GetAllTransactions(int pageNumber = 1, int pageSize = 10)
    {
        try
        {
            var transactions = await _transactionService.GetAllTransactionsAsync(pageNumber , pageSize);
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
 

    // Listar transacciones por fecha
    [HttpGet("transactions")]
    public async Task<IActionResult> GetUserTransactions()
    {
        // Obtener el ID del usuario actual autenticado
        var userId = ObtenerIdUsuarioActual();

        var userTransactions = await _transactionService.GetTransactionsByUserIdOrderedByDateAsync(userId);

        if (userTransactions == null || !userTransactions.Any())
        {
            return NotFound("No se encontraron transacciones para este usuario.");
        }

        return Ok(userTransactions);
    }
    private int ObtenerIdUsuarioActual()
    {
        // Lógica para obtener el ID del usuario actual
        // ASP.NET Core Identity
        var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        return int.Parse(userIdClaim ?? "0"); // Si no se encuentra, se retorna 0 como valor predeterminado
    }

    //Detalle de transaccion
    [HttpGet("transactions/{id}")]
    public async Task<IActionResult> GetTransactionDetails(int id)
    {
        //obtener el ID del usuario actual autenticado.
        int userId = ObtenerIdUsuarioActual();

        var transaction = await _transactionService.GetTransactionByIdAsync(id);

        if (transaction == null)
        {
            return NotFound("La transacción no fue encontrada.");
        }

        // Verificar si la transacción pertenece al usuario autenticado
        if (transaction.UserId != userId)
        {
            return Forbid("No tienes permiso para ver esta transacción.");
        }

        return Ok(transaction);
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
    public async Task<IActionResult> UpdateTransaction(int id, TransactionDTO transaction)
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
