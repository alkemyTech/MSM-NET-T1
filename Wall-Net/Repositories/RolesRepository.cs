using Microsoft.EntityFrameworkCore;
using Wall_Net.DataAccess;
using Wall_Net.Models;

namespace Wall_Net.Repositories
{
    public class RolesRepository : IRolesRepository
    {
        private readonly WallNetDbContext _dbContext;

        public RolesRepository(WallNetDbContext dbContext)
        {
            _dbContext = dbContext;
        }

         public async Task<IEnumerable<Roles>> GetAll()
        {
            return await _dbContext.roles.ToListAsync();
        }

        public async Task<Roles> GetById(int id)
        {
            return await _dbContext.roles.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task Add(Roles Roles)
        {
                _dbContext.roles.Add(Roles);
                await _dbContext.SaveChangesAsync();
        }

        public async Task Update(Roles Roles)
        {
                _dbContext.roles.Update(Roles);
                await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var Roles = _dbContext.roles.FirstOrDefault(p => p.Id == id);
            if (Roles != null)
            {
                _dbContext.roles.Remove(Roles);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
