using Wall_Net.Models;

namespace Wall_Net.Services
{
    public interface IAccountServices
    {
        Task<IEnumerable<Account>> GetAll();
        Task<Account> GetById(int id);
        Task<Account> GetByUserId(int id);
        Task Insert(Account account);
        Task Update(Account account);
        Task Delete(int id);
    }
}
