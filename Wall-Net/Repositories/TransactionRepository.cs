using Microsoft.EntityFrameworkCore;
using System.Security.Principal;
using Wall_Net.DataAccess;
using Wall_Net.Models;
using Wall_Net.Models.DTO;

namespace Wall_Net.Repositories;
public class TransactionRepository : ITransactionRepository
{
    private readonly WallNetDbContext _context;

    public TransactionRepository(WallNetDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Transaction>> GetAllTransactionsAsync(int pageNumber, int pageSize)
    {
        var usuariosPaginados = await _context.Transactions
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Include(p => p.Account)
                .ToListAsync();
        return usuariosPaginados;
    }

    public async Task<Transaction> GetTransactionByIdAsync(int id)
    {
        return await _context.Transactions.FindAsync(id);
    }

    public async Task AddTransactionAsync(Transaction transaction)
    {
        _context.Transactions.Add(transaction);
    }

    public async Task UpdateTransactionAsync(TransactionDTO transaction)
    {
        var transacion = await _context.Transactions.FindAsync(transaction.TransactionId);
        transacion.Amount=transaction.Amount;
        transacion.Concept = transaction.Concept;
        transacion.Type = transaction.Type;
        _context.Transactions.Update(transacion);
    }

    public async Task DeleteTransactionAsync(int id)
    {
        var transaction = await _context.Transactions.FindAsync(id);
        if (transaction != null)
        {
            _context.Transactions.Remove(transaction);
        }
    }

    public async Task<IEnumerable<Transaction>> GetAllTransactionById(int id)
    {

        var account = await _context.Accounts
               .Include(p => p.Transactions)
               .FirstOrDefaultAsync(p => p.UserId == id);
        var transactions = account.Transactions;
        return transactions;
    }
    public async Task ObtenerIdUsuarioActual(int id)
    {
        await _context.Transactions.FindAsync(id);
    }
    public async Task<IEnumerable<Transaction>> GetTransactionsByUserIdOrderedByDateAsync(int userId)
    {
        var userTransactions = await _context.Transactions
                                            .Where(t => t.UserId == userId)
                                            .OrderByDescending(t => t.Date)
                                            .ToListAsync();

        return userTransactions;
    }

    public async Task<IEnumerable<Transaction>> GetTransactionsByUserIdAsync(int userId)
    {
        //  filtrar las transacciones por el ID del usuario.
        var userTransactions = await _context.Transactions
                                            .Where(t => t.UserId == userId)
                                            .ToListAsync();

        return userTransactions;
    }
}
