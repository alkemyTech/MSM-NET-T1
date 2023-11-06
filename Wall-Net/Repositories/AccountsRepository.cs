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
            return _dbContext.Accounts.FirstOrDefault(a => a.id == id);
        }
        public async Task InsertAccount(Account account)
        {
            _dbContext.Accounts.Add(account);
            await _dbContext.SaveChangesAsync();
        }
        public async Task UpdateAccount(Account account)
        {
            _dbContext.Accounts.Update(account);
            await _dbContext.SaveChangesAsync();
        }
        public async Task DeleteAccount(int id)
        {
            var account = await _dbContext.Accounts.FirstOrDefaultAsync(p => p.id == id);
            if (account != null)
            {
                _dbContext.Accounts.Remove(account);
                await _dbContext.SaveChangesAsync();
            }
        }

    }
}
