using Wall_Net.Models;

namespace Wall_Net.Services
{
    public interface ITransactionService
    {
        Task<IEnumerable<Transaction>> GetAllTransactionsAsync(int pageNumber, int pageSize);
        Task<Transaction> GetTransactionByIdAsync(int id);
        Task AddTransactionAsync(Transaction transaction);
        Task UpdateTransactionAsync(Transaction transaction);
        Task DeleteTransactionAsync(int id);
        Task ObtenerIdUsuarioActual(int id);
        Task<IEnumerable<Transaction>> GetTransactionsByUserIdOrderedByDateAsync(int userId);
        Task CreateTransactionAsync(Transaction transaction);
    }

}
