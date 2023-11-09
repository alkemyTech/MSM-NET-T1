using Wall_Net.Models;
using Wall_Net.Repositories;
using Wall_Net.UnitOfWorks;

namespace Wall_Net.Services
{
    public class UserServices : IUserServices
    {
        //private readonly IUserRepository _wallNetRepository;
        private readonly UnitOfWork _unitOfWork;

        public UserServices(/*IUserRepository wallNetRepository*/ 
            UnitOfWork unitOfWork)
        {
            //_wallNetRepository = wallNetRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task <IEnumerable<User>> GetAllUsers()
        {
            //return _wallNetRepository.GetAll();
            return await _unitOfWork.UserRepository.GetAll();
        }
        public async Task <User> GetUserById(int id)
        {
            return await _unitOfWork.UserRepository.GetById(id);
        }
        public async Task AddUser(User user)
        {
            await _unitOfWork.UserRepository.Add(user);
        }
        public async Task UpdateUser(User user)
        {
            await _unitOfWork.UserRepository.Update(user);
        }
        public async Task DeleteUserbyId(int id)
        {
            await _unitOfWork.UserRepository.Delete(id);
        }
        public async Task SaveChanges()
        {
            await _unitOfWork.Commit();
        }
    }
}
