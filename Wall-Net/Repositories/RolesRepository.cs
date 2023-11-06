using Wall_Net.DataAccess;
using Wall_Net.Models;

namespace Wall_Net.Repositories
{
    public class RolesRepository : IRolesRepository
    {
        private readonly Wall_Net_DbContext _dbContext;

        public RolesRepository(Wall_Net_DbContext dbContext)
        {
            _dbContext = dbContext;
        }

         public IEnumerable<Roles> GetAll()
        {
            return _dbContext.roles.ToList();
        }

        public Roles GetById(int id)
        {
            return _dbContext.roles.FirstOrDefault(p => p.Id == id);
        }

        public void Add(Roles Roles)
        {
            if(Roles.Name == "Admin" || Roles.Name == "Regular") 
            { 
                _dbContext.roles.Add(Roles);
                _dbContext.SaveChanges();
            }
 
        }

        public void Update(Roles Roles)
        {
            if (Roles.Name == "Admin" || Roles.Name == "Regular")
            {
                _dbContext.roles.Update(Roles);
                _dbContext.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var Roles = _dbContext.roles.FirstOrDefault(p => p.Id == id);
            if (Roles != null)
            {
                _dbContext.roles.Remove(Roles);
                _dbContext.SaveChanges();
            }
        }
    }
}
