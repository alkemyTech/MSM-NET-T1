using Wall_Net.Models;
using Wall_Net.Models.DTO;

namespace Wall_Net.Repositories;
public interface ITransactionRepository
{
    Task<IEnumerable<Transaction>> GetAllTransactionsAsync(int pageNumber, int pageSize);

    Task<IEnumerable<Transaction>>GetAllTransactionById(int id);
    Task<Transaction> GetTransactionByIdAsync(int id);
    Task AddTransactionAsync(Transaction transaction);
    Task UpdateTransactionAsync(TransactionDTO transaction);
    Task DeleteTransactionAsync(int id);
    Task ObtenerIdUsuarioActual(int id);
    Task<IEnumerable<Transaction>> GetTransactionsByUserIdOrderedByDateAsync(int userId);
    Task<IEnumerable<Transaction>> GetTransactionsByUserIdAsync(int userId);
}
