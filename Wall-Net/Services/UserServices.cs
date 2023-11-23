using Wall_Net.Models;
using Wall_Net.UnitOfWorks;

namespace Wall_Net.Services
{
    public class UserServices : IUserServices
    {
        private readonly UnitOfWork _unitOfWork;

        public UserServices( 
            UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task <IEnumerable<User>> GetAllUsers(int pageNumber, int pageSize)
        {
            return await _unitOfWork.UserRepository.GetAll(pageNumber, pageSize);
        }
        public async Task<User> GetUserById(int id)
        {
            return await _unitOfWork.UserRepository.GetById(id);
        }
        public async Task AddUser(User user)
        {
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(user.Password);
            user.Password = hashedPassword;

            _unitOfWork.UserRepository.Add(user);
            await _unitOfWork.Commit();
        }
        public async Task UpdateUser(User user)
        {
            _unitOfWork.UserRepository.Update(user);
            await _unitOfWork.Commit();
        }
        public async Task DeleteUserbyId(int id)
        {
            _unitOfWork.UserRepository.Delete(id);
            await _unitOfWork.Commit();
        }
        public async Task SaveChanges()
        {
            await _unitOfWork.Commit();
        }
    }
}
