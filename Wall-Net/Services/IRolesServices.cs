using Wall_Net.Models;

namespace Wall_Net.Services
{
    public interface IRolesServices
    {
        Task<Roles> GetRolesById(int id);
        Task<IEnumerable<Roles>> GetAllRoles();
        Task AddRoles(Roles rol);
        Task UpdateRoles(Roles rol);
        Task DeleteRoles(int id);
    }
}
