using Wall_Net.Models;

namespace Wall_Net.Services
{
    public interface ITransactionService
    {
        Task<IEnumerable<Transaction>> GetAllTransactionsAsync();

        Task<IEnumerable<Transaction>> GetAllById(int id);
        Task<Transaction> GetTransactionByIdAsync(int id);
        Task AddTransactionAsync(Transaction transaction);
        Task UpdateTransactionAsync(Transaction transaction);
        Task DeleteTransactionAsync(int id);
    }

}
