using Wall_Net.Models;
using Wall_Net.Models.DTO;
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

        public async Task<IEnumerable<Transaction>> GetAllTransactionsAsync(int pageNumber, int pageSize)
        {
            return await _unitOfWork.TransactionRepository.GetAllTransactionsAsync(pageNumber, pageSize);
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
            await _unitOfWork.Commit();
        }

        public async Task UpdateTransactionAsync(TransactionDTO transaction)
        {
            await _unitOfWork.TransactionRepository.UpdateTransactionAsync(transaction);
            await _unitOfWork.Commit();
        }

        public async Task DeleteTransactionAsync(int id)
        {
            await _unitOfWork.TransactionRepository.DeleteTransactionAsync(id);
            await _unitOfWork.Commit();
        }
        public async Task ObtenerIdUsuarioActual(int id)
        {
            await _unitOfWork.TransactionRepository.ObtenerIdUsuarioActual(id);
        }
        public async Task<IEnumerable<Transaction>> GetTransactionsByUserIdOrderedByDateAsync(int userId)
        {
            var userTransactions = await _unitOfWork.TransactionRepository.GetTransactionsByUserIdAsync(userId);

            return userTransactions.OrderByDescending(t => t.Date);
        }
        public async Task CreateTransactionAsync(Transaction transaction)
        {
            try
            {
                // Aquí interactuarías con tu repositorio (por ejemplo, Entity Framework Core) para agregar la transacción a la base de datos
                await _unitOfWork.TransactionRepository.AddTransactionAsync(transaction);
                await _unitOfWork.Commit(); // Otra forma de guardar cambios, dependiendo de tu implementación de repositorio
            }
            catch (Exception ex)
            {
                throw new Exception("Error al guardar la transacción en el repositorio: " + ex.Message);
            }
        }

    }
}
