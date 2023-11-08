using Wall_Net.DataAccess;
using Wall_Net.Repositories;

namespace Wall_Net.UnitOfWorks
{
    public class UnitOfWork
    {
        private readonly WallNetDbContext _dbContext;
        private readonly IUserRepository _userRepository;

        public UnitOfWork(WallNetDbContext dbContext, IUserRepository userRepository)
        {
            _dbContext = dbContext;
            _userRepository = userRepository;
        }

        public IUserRepository UserRepository => _userRepository;

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
