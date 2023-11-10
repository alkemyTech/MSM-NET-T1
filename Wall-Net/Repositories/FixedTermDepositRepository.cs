using Microsoft.EntityFrameworkCore;
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
            return await _dbContext.FixedTerms.ToListAsync();
        }

        public async Task<FixedTermDeposit> GetById(int id)
        {
            return await _dbContext.FixedTerms.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task Add(FixedTermDeposit FixedTermDeposit)
        {
            _dbContext.FixedTerms.Add(FixedTermDeposit);
        }

        public async Task Update(FixedTermDeposit FixedTermDeposit)
        {
            _dbContext.FixedTerms.Update(FixedTermDeposit);
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