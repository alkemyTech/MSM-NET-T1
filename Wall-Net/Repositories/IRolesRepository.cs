using Wall_Net.Models;

namespace Wall_Net.Repositories
{
    public interface IRolesRepository
    {
        Task<Roles> GetById (int id);
        Task<IEnumerable<Roles>> GetAll();
        Task Add(Roles rol);
        Task Update(Roles rol);
        Task Delete(int id);

    }
}
