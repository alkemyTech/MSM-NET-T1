using Wall_Net.Models;

namespace Wall_Net.Services
{
    public interface IUserServices
    {
        IEnumerable<User> GetAllUsers();
        User GetUserById(int id);
        void AddUser(User user);
        void UpdateUser(User user);
        void DeleteUserbyId(int id);
    }
}
