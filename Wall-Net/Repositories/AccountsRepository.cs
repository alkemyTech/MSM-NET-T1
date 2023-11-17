using Microsoft.EntityFrameworkCore;
using Wall_Net.DataAccess;
using Wall_Net.Models;

namespace Wall_Net.Repositories
{
    public class AccountsRepository : IAccountsRepository
    {
        private readonly WallNetDbContext _dbContext;
        public AccountsRepository(WallNetDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<Account>> GetAllAccounts()
        {
            return await _dbContext.Accounts.ToListAsync();
        }
        public async Task<Account> GetAccountById(int id)
        {
            var account = _dbContext.Accounts.FirstOrDefault(a => a.Id == id);
            return account;
        }
        public async Task InsertAccount(Account account)
        {
            var userRelacionado = _dbContext.Users.FirstOrDefault(p => p.Id == account.User_Id);
            account.User = userRelacionado;
            _dbContext.Accounts.Add(account);
        }
        public async Task UpdateAccount(Account account)
        {

            var userRelacionado = _dbContext.Users.FirstOrDefault(p => p.Id == account.User_Id);
            account.User = userRelacionado;
            _dbContext.Accounts.Update(account);
        }
        public async Task DeleteAccount(int id)
        {
            var account = await _dbContext.Accounts.FirstOrDefaultAsync(p => p.Id == id);
            if (account != null)
            {
                _dbContext.Accounts.Remove(account);
            }
        }

    }
}