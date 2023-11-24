using Wall_Net.Models;

namespace Wall_Net.Repositories
{
    public interface IAccountsRepository
    {
        Task<IEnumerable<Account>> GetAllAccounts();
        Task<Account> GetAccountById(int id);
        Task<Account> GetAccountByUserId(int id);
        Task InsertAccount(Account account);
        Task UpdateAccount(Account account);
        Task DeleteAccount(int id);
    }
}
