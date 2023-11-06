using Wall_Net.Models;

namespace Wall_Net.Services
{
    public interface IRolesServices
    {
        Roles GetRolesById(int id);
        IEnumerable<Roles> GetAllRoles();
        void AddRoles(Roles rol);
        void UpdateRoles(Roles rol);
        void DeleteRoles(int id);
    }
}
