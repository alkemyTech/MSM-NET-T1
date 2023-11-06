using Wall_Net.Models;
using Wall_Net.Repositories;

namespace Wall_Net.Services
{
    public class UserServices : IUserServices
    {
        private readonly IUserRepository _wallNetRepository;

        public UserServices(IUserRepository wallNetRepository)
        {
            _wallNetRepository = wallNetRepository;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _wallNetRepository.GetAll();
        }
        public User GetUserById(int id)
        {
            return _wallNetRepository.GetById(id);
        }
        public void AddUser(User user)
        {
            _wallNetRepository.Add(user);
        }
        public void UpdateUser(User user)
        {
            _wallNetRepository.Update(user);
        }
        public void DeleteUserbyId(int id)
        {
            _wallNetRepository.Delete(id);
        }
    }
}
