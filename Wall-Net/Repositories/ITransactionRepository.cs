using Wall_Net.Models;

namespace Wall_Net.Repositories;
public interface ITransactionRepository
{
    Task<IEnumerable<Transaction>> GetAllTransactionsAsync(int pageNumber, int pageSize);
    Task<Transaction> GetTransactionByIdAsync(int id);
    Task AddTransactionAsync(Transaction transaction);
    Task UpdateTransactionAsync(Transaction transaction);
    Task DeleteTransactionAsync(int id);
    Task ObtenerIdUsuarioActual(int id);
    Task<IEnumerable<Transaction>> GetTransactionsByUserIdOrderedByDateAsync(int userId);
    Task<IEnumerable<Transaction>> GetTransactionsByUserIdAsync(int userId);
}
