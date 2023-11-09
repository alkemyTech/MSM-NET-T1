using Microsoft.AspNetCore.Mvc;
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
    public async Task<IActionResult> GetAllTransactions()
    {
        var transactions = await _transactionService.GetAllTransactionsAsync();
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

    [HttpPost]
    public async Task<IActionResult> CreateTransaction([FromBody] Transaction transaction)
    {
        if (transaction == null)
        {
            return BadRequest("Invalid transaction data");
        }

        await _transactionService.AddTransactionAsync(transaction);

        return CreatedAtAction("GetTransaction", new { id = transaction.TransactionId }, transaction);
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
