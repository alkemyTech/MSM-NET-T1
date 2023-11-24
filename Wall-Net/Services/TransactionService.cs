using Wall_Net.Models;
using Wall_Net.Repositories;
using Wall_Net.UnitOfWorks;

namespace Wall_Net.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly UnitOfWork _unitOfWork;

        public TransactionService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Transaction>> GetAllTransactionsAsync()
        {
            return await _unitOfWork.TransactionRepository.GetAllTransactionsAsync();
        }

        public async Task<IEnumerable<Transaction>> GetAllById(int id)
        {
            return await _unitOfWork.TransactionRepository.GetAllTransactionById(id);
        }

        public async Task<Transaction> GetTransactionByIdAsync(int id)
        {
            return await _unitOfWork.TransactionRepository.GetTransactionByIdAsync(id);
        }

        public async Task AddTransactionAsync(Transaction transaction)
        {
            await _unitOfWork.TransactionRepository.AddTransactionAsync(transaction);
        }

        public async Task UpdateTransactionAsync(Transaction transaction)
        {
            await _unitOfWork.TransactionRepository.UpdateTransactionAsync(transaction);
        }

        public async Task DeleteTransactionAsync(int id)
        {
            await _unitOfWork.TransactionRepository.DeleteTransactionAsync(id);
        }
    }
}
