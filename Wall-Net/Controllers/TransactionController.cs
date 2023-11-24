using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Wall_Net.Models;
using Wall_Net.Services;

[Route("api/transactions")]
[ApiController]
public class TransactionController : ControllerBase
{
    private readonly ITransactionService _transactionService;

    public TransactionController(ITransactionService transactionService)
    {
        _transactionService = transactionService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllTransactions(int pageNumber = 1, int pageSize = 10)
    {
        var transactions = await _transactionService.GetAllTransactionsAsync(pageNumber, pageSize);
        return Ok(transactions);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetTransaction(int id)
    {
        var transaction = await _transactionService.GetTransactionByIdAsync(id);

        if (transaction == null)
        {
            return NotFound();
        }

        return Ok(transaction);
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


    [HttpPost("transactions")]
    public async Task<IActionResult> CreateTransaction([FromBody] Transaction transaction)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        if (transaction == null)
        {
            return BadRequest("Invalid transaction data");
        }
        try
        {
            await _transactionService.CreateTransactionAsync(transaction);
            return CreatedAtAction("GetTransaction", new { id = transaction.TransactionId }, transaction);
        }
        catch (Exception ex)
        {
            // Manejo de errores
            return StatusCode(500, "Error al guardar la transacción: " + ex.Message);
        }
    }


    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTransaction(int id, [FromBody] Transaction transaction)
    {
        var existingTransaction = await _transactionService.GetTransactionByIdAsync(id);

        if (existingTransaction == null)
        {
            return NotFound();
        }

        await _transactionService.UpdateTransactionAsync(transaction);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTransaction(int id)
    {
        var transaction = await _transactionService.GetTransactionByIdAsync(id);

        if (transaction == null)
        {
            return NotFound();
        }

        await _transactionService.DeleteTransactionAsync(id);

        return NoContent();
    }
}
