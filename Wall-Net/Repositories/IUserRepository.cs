using Wall_Net.Models;

namespace Wall_Net.Repositories
{
    public interface IUserRepository
    {
        Task <IEnumerable<User>> GetAll(int pageNumber, int pageSize);
        Task <User> GetById(int id);
        Task Add(User user);
        Task Update(User user);
        Task Delete(int id);
    }
}
