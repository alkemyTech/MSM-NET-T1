using Wall_Net.Models;

namespace Wall_Net.Services
{
    public interface IUserServices
    {
        Task <IEnumerable<User>> GetAllUsers();
        Task <User> GetUserById(int id);
        Task AddUser(User user);
        Task UpdateUser(User user);
        Task DeleteUserbyId(int id);
    }
}
