using Wall_Net.DataAccess;
using Wall_Net.Models;

namespace Wall_Net.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly WallNetDbContext _dbcontext;

        public UserRepository(WallNetDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public IEnumerable<User> GetAll()
        {
            return _dbcontext.Users.ToList();
        }

        public User GetById(int id)
        {
            return _dbcontext.Users.FirstOrDefault(p => p.Id == id);
        }

        public void Add(User user)
        {
            _dbcontext.Users.Add(user);
            _dbcontext.SaveChanges();
        }

        public void Update(User user)
        {
            _dbcontext.Users.Update(user);
            _dbcontext.SaveChanges();
        }

        public void Delete(int id)
        {
            var user = _dbcontext.Users.FirstOrDefault(p => p.Id == id);
            if (user != null)
            {
                _dbcontext.Users.Remove(user);
                _dbcontext.SaveChanges();
            }
        }
    }
}
