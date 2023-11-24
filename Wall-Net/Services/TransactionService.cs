using Wall_Net.Models;
using Wall_Net.Repositories;
using Wall_Net.UnitOfWorks;

namespace Wall_Net.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly UnitOfWork _unitOfWork;

        public TransactionService(ITransactionRepository transactionRepository, UnitOfWork unitOfWork)
        {
         _transactionRepository = transactionRepository;
         _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Transaction>> GetAllTransactionsAsync(int pageNumber, int pageSize)
        {
            return await _transactionRepository.GetAllTransactionsAsync(pageNumber, pageSize);
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
        public async Task ObtenerIdUsuarioActual(int id)
        {
            await _transactionRepository.ObtenerIdUsuarioActual(id);
        }
        public async Task<IEnumerable<Transaction>> GetTransactionsByUserIdOrderedByDateAsync(int userId)
        {
            var userTransactions = await _transactionRepository.GetTransactionsByUserIdAsync(userId);

            return userTransactions.OrderByDescending(t => t.Date);
        }
        public async Task CreateTransactionAsync(Transaction transaction)
        {
            try
            {
                // Aquí interactuarías con tu repositorio (por ejemplo, Entity Framework Core) para agregar la transacción a la base de datos
                await _transactionRepository.AddTransactionAsync(transaction);
                await _unitOfWork.Commit(); // Otra forma de guardar cambios, dependiendo de tu implementación de repositorio
            }
            catch (Exception ex)
            {
                throw new Exception("Error al guardar la transacción en el repositorio: " + ex.Message);
            }
        }

    }
}
