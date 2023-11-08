using Wall_Net.Models;
using Wall_Net.Repositories;

namespace Wall_Net.Services
{
    public class RolesServices : IRolesServices
    {
        private readonly IRolesRepository _rolesRepository;

        public RolesServices(IRolesRepository rolesRepository)
        {
            _rolesRepository = rolesRepository;
        }

        public async Task AddRoles(Roles rol)
        {
             await _rolesRepository.Add(rol);
        }

        public async Task DeleteRoles(int id)
        {
            await _rolesRepository.Delete(id);
        }

        public async Task<IEnumerable<Roles>> GetAllRoles()
        {
            return  await _rolesRepository.GetAll();
        }

        public async Task<Roles> GetRolesById(int id)
        {
            return await _rolesRepository.GetById(id);
        }
        
        public async Task UpdateRoles(Roles rol)
        {
            await _rolesRepository.Update(rol);
        }
    }
}
