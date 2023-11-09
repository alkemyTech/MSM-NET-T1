using Wall_Net.Models;
using Wall_Net.Repositories;

namespace Wall_Net.Services
{
    public class AccountServices : IAccountServices
    {
            private readonly IAccountsRepository _accountRepository;

            public AccountServices(IAccountsRepository accountRepository)
            {
                _accountRepository = accountRepository;
            }
            public async Task<IEnumerable<Account>> GetAll()
            {
                return await _accountRepository.GetAllAccounts();
            }
            public async Task<Account> GetById(int id)
            {
                return await _accountRepository.GetAccountById(id);
            }
            public async Task Insert(Account account)
            {
                await _accountRepository.InsertAccount(account);
            }
            public async Task Update(Account account)
            {
                await _accountRepository.UpdateAccount(account);
            }
            public async Task Delete(int accountId)
            {
                var account = _accountRepository.GetAccountById(accountId);
                if (account != null)
                {
                    await _accountRepository.DeleteAccount(accountId);
                }

            }
        }
}
