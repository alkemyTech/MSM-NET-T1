using Wall_Net.Models;

namespace Wall_Net.Repositories
{
    public class FixedTermDepositRepository : IFixedTermDepositRepository
    {
        private readonly Wall-Net-DbContext _dbContext;

        public FixedTermDepositRepository(Wall-Net-DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<FixedTermDeposit>> GetAll()
        {
            return await _dbContext.FixedTermDeposit.ToListAsync();
        }

        public async Task<FixedTermDeposit> GetById(int id)
        {
            return await _dbContext.FixedTermDeposit.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task Add(FixedTermDeposit FixedTermDeposit)
        {
            _dbContext.FixedTermDeposit.Add(FixedTermDeposit);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(FixedTermDeposit FixedTermDeposit)
        {
            _dbContext.FixedTermDeposit.Update(FixedTermDeposit);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var FixedTermDeposit = _dbContext.FixedTermDeposit.FirstOrDefault(p => p.Id == id);
            if (FixedTermDeposit != null)
            {
                _dbContext.FixedTermDeposit.Remove(FixedTermDeposit);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
