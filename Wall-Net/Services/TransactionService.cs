using Wall_Net.Models;
using Wall_Net.Repositories;

namespace Wall_Net.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;

        public TransactionService(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public async Task<IEnumerable<Transaction>> GetAllTransactionsAsync()
        {
            return await _transactionRepository.GetAllTransactionsAsync();
        }

        public async Task<Transaction> GetTransactionByIdAsync(int id)
        {
            return await _transactionRepository.GetTransactionByIdAsync(id);
        }

        public async Task AddTransactionAsync(Transaction transaction)
        {
            await _transactionRepository.AddTransactionAsync(transaction);
        }

        public async Task UpdateTransactionAsync(Transaction transaction)
        {
            await _transactionRepository.UpdateTransactionAsync(transaction);
        }

        public async Task DeleteTransactionAsync(int id)
        {
            await _transactionRepository.DeleteTransactionAsync(id);
        }
    }
}
