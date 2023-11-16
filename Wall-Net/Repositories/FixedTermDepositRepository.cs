using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Wall_Net.DataAccess;
using Wall_Net.Models;

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
                .Include(p => p.FixedTerms)
                .FirstOrDefaultAsync(p => p.Id == id);
            var fixeds = user.FixedTerms;
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
                .Include(p => p.FixedTerms)
                .FirstOrDefaultAsync(p => p.Id == idUser);
            var fixedTerms = user.FixedTerms;
            var fTerm = fixedTerms.FirstOrDefault(p => p.Id == idFixed);

            return fTerm;
        }
        
        public async Task Add(FixedTermDeposit FixedTermDeposit, int idUser)
        {
            FixedTermDeposit.Account= _dbContext.Accounts.FirstOrDefault(p => p.Id == FixedTermDeposit.AccountId);

            if (FixedTermDeposit.Account.Money >= FixedTermDeposit.amount)
            {
                FixedTermDeposit.creation_date = DateTime.Now;
                FixedTermDeposit.state = "Activo";
                FixedTermDeposit.User= _dbContext.Users.FirstOrDefault(p => p.Id == FixedTermDeposit.UserId);
                _dbContext.FixedTerms.Add(FixedTermDeposit);  
            }
            
        }
        public async Task UpdateAccount(FixedTermDeposit updateFixedTermDeposit)
        {
            updateFixedTermDeposit.Account.Money -= updateFixedTermDeposit.amount;
            _dbContext.FixedTerms.Update(updateFixedTermDeposit);
        }
        public async Task Update(FixedTermDeposit updateFixedTermDeposit)
        {
            updateFixedTermDeposit.Account.Money -= updateFixedTermDeposit.amount;
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