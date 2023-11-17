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
            return _dbContext.Accounts.Include(p => p.User)
                .FirstOrDefault(a => a.Id == id);
        }
        public async Task<Account> GetAccountByUserId(int userId)
        {
            return await _dbContext.Accounts.FirstOrDefaultAsync(a => a.User_Id == userId);   
            
        }
        public async Task InsertAccount(Account account)
        {
            _dbContext.Accounts.Add(account);
        }
        public async Task UpdateAccount(Account account)
        {
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