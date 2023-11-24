using Microsoft.EntityFrameworkCore;
using Wall_Net.DataAccess;
using Wall_Net.Models;

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
        await _context.SaveChangesAsync();
    }

    public async Task UpdateTransactionAsync(Transaction transaction)
    {
        _context.Entry(transaction).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteTransactionAsync(int id)
    {
        var transaction = await _context.Transactions.FindAsync(id);
        if (transaction != null)
        {
            _context.Transactions.Remove(transaction);
            await _context.SaveChangesAsync();
        }
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
