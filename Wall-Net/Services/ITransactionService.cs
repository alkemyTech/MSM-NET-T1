using Wall_Net.Models;
using Wall_Net.Models.DTO;

namespace Wall_Net.Services
{
    public interface ITransactionService
    {

        Task<IEnumerable<Transaction>> GetAllTransactionsAsync(int pageNumber, int pageSize);

        Task<IEnumerable<Transaction>> GetAllById(int id);
        Task<Transaction> GetTransactionByIdAsync(int id);
        Task AddTransactionAsync(Transaction transaction);
        Task UpdateTransactionAsync(TransactionDTO transaction);
        Task DeleteTransactionAsync(int id);
        Task ObtenerIdUsuarioActual(int id);
        Task<IEnumerable<Transaction>> GetTransactionsByUserIdOrderedByDateAsync(int userId);
        Task CreateTransactionAsync(Transaction transaction);
    }

}
