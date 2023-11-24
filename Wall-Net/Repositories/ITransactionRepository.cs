using Wall_Net.Models;

namespace Wall_Net.Repositories;
public interface ITransactionRepository
{
    Task<IEnumerable<Transaction>> GetAllTransactionsAsync();

    Task<IEnumerable<Transaction>>GetAllTransactionById(int id);
    Task<Transaction> GetTransactionByIdAsync(int id);
    Task AddTransactionAsync(Transaction transaction);
    Task UpdateTransactionAsync(Transaction transaction);
    Task DeleteTransactionAsync(int id);
}
