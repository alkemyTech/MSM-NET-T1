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
            return await _dbContext.Roles.ToListAsync();
        }

        public async Task<Roles> GetById(int id)
        {
            return await _dbContext.Roles.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task Add(Roles Roles)
        {
            _dbContext.Roles.Add(Roles);
        }

        public async Task Update(Roles Roles)
        {
            _dbContext.Roles.Update(Roles);
        }

        public async Task Delete(int id)
        {
            var Roles = _dbContext.Roles.FirstOrDefault(p => p.Id == id);
            if (Roles != null)
            {
                _dbContext.Roles.Remove(Roles);
            }
        }
    }
}
