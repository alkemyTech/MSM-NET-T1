using Wall_Net.Models;

namespace Wall_Net.Repositories
{
    public interface IRolesRepository
    {
        Roles GetById (int id);
        IEnumerable<Roles> GetAll();
        void Add(Roles rol);
        void Update(Roles rol);
        void Delete(int id);

    }
}
