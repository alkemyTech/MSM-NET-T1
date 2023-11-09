using Wall_Net.Models;
using Wall_Net.UnitOfWorks;

namespace Wall_Net.Services
{
    public class AccountServices : IAccountServices
    {
        private readonly UnitOfWork _unitOfWork;

        public AccountServices(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<Account>> GetAll()
        {
            return await _unitOfWork.AccountsRepository.GetAllAccounts();
        }
        public async Task<Account> GetById(int id)
        {
            return await _unitOfWork.AccountsRepository.GetAccountById(id);
        }
        public async Task Insert(Account account)
        {
            await _unitOfWork.AccountsRepository.InsertAccount(account);
            await _unitOfWork.Commit();
        }
        public async Task Update(Account account)
        {
            await _unitOfWork.AccountsRepository.UpdateAccount(account);
            await _unitOfWork.Commit();
        }
        public async Task Delete(int accountId) 
        {
            var account = _unitOfWork.AccountsRepository.GetAccountById(accountId);
            if (account != null) 
            {
                await _unitOfWork.AccountsRepository.DeleteAccount(accountId);
                await _unitOfWork.Commit();
            }
           
        }
        public async Task SaveChanges()
        {
            await _unitOfWork.Commit();
        }
    }
    
}
