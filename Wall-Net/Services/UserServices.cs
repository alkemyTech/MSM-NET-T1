using Wall_Net.Models;
using Wall_Net.Repositories;
using Wall_Net.UnitOfWorks;

namespace Wall_Net.Services
{
    public class UserServices : IUserServices
    {
        //private readonly IUserRepository _wallNetRepository;
        private readonly UnitOfWork _unitOfWork;

        public UserServices(/*IUserRepository wallNetRepository*/ UnitOfWork unitOfWork)
        {
            //_wallNetRepository = wallNetRepository;
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<User> GetAllUsers()
        {
            //return _wallNetRepository.GetAll();
            return _unitOfWork.UserRepository.GetAll();
        }
        public User GetUserById(int id)
        {
            return _unitOfWork.UserRepository.GetById(id);
        }
        public void AddUser(User user)
        {
            _unitOfWork.UserRepository.Add(user);
        }
        public void UpdateUser(User user)
        {
            _unitOfWork.UserRepository.Update(user);
        }
        public void DeleteUserbyId(int id)
        {
            _unitOfWork.UserRepository.Delete(id);
        }
        public void SaveChanges()
        {
            _unitOfWork.Save();
        }
    }
}
