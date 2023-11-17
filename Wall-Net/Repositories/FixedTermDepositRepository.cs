using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Wall_Net.DataAccess;
using Wall_Net.Models;
using Wall_Net.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Wall_Net.Repositories
{
    public class FixedTermDepositRepository : IFixedTermDepositRepository
    {
        private readonly WallNetDbContext _dbContext;

        public FixedTermDepositRepository(WallNetDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<FixedTermDeposit>> GetAll()
        {
            return await _dbContext.FixedTerms
                .Include(p => p.Account)
                .Include(p => p.User)
                .ToListAsync();
        }

        public async Task<IEnumerable<FixedTermDeposit>> GetAllById(int id)
        {
            var user= await _dbContext.Users
                .Include(p => p.FixedTermDeposits)
                .FirstOrDefaultAsync(p => p.Id == id);
            var fixeds = user.FixedTermDeposits;
            return fixeds;
        }
      
        public async Task<FixedTermDeposit> GetById(int id)
        {
            return await _dbContext.FixedTerms
                .Include(p => p.Account)
                .Include(p => p.User)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<FixedTermDeposit> GetFixedByIdUser(int idUser,int idFixed)
        {
            var user = await _dbContext.Users
                .Include(p => p.FixedTermDeposits)
                .FirstOrDefaultAsync(p => p.Id == idUser);
            var fixedTerms = user.FixedTermDeposits;
            var fTerm = fixedTerms.FirstOrDefault(p => p.Id == idFixed);

            return fTerm;
        }
        
        public async Task<Boolean> Add(int monthFTD, int amount, int idUser)
        {
            var account= _dbContext.Accounts.FirstOrDefault(p => p.User_Id == idUser);

            if (account.Money >= amount)
            {
                FixedTermDeposit fixedTerm = new FixedTermDeposit();

                fixedTerm.UserId = idUser;
                fixedTerm.User = _dbContext.Users.FirstOrDefault(p => p.Id == idUser);
                fixedTerm.AccountId = account.Id;
                fixedTerm.Account = account;
                fixedTerm.creation_date = DateTime.Now;
                fixedTerm.closing_date = fixedTerm.creation_date.AddMonths(monthFTD);
                fixedTerm.amount = amount;
                fixedTerm.nominalRate = 10;
                fixedTerm.state = "Activo";

                fixedTerm.Account.Money -= fixedTerm.amount;

                _dbContext.FixedTerms.Add(fixedTerm);

                return true;
            }

            return false;

            
        }
       
        public async Task Update(FixedTermDeposit updateFixedTermDeposit)
        {
            _dbContext.FixedTerms.Update(updateFixedTermDeposit);
        }

        public async Task Delete(int id)
        {
            var FixedTermDeposit = await _dbContext.FixedTerms.FirstOrDefaultAsync(p => p.Id == id);
            if (FixedTermDeposit != null)
            {
                _dbContext.FixedTerms.Remove(FixedTermDeposit);
            }
        }
    }
}