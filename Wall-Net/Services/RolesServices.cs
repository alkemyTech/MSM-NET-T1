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

        public void AddRoles(Roles rol)
        {
             _rolesRepository.Add(rol);
        }

        public void DeleteRoles(int id)
        {
            _rolesRepository.Delete(id);
        }

        public IEnumerable<Roles> GetAllRoles()
        {
            return _rolesRepository.GetAll();
        }

        public Roles GetRolesById(int id)
        {
            return _rolesRepository.GetById(id);
        }

<<<<<<< HEAD
        public void UpdateRoles(Roles rol)
=======
        public async Task UpdateRoles(Roles rol)
>>>>>>> Agrega FixedTermDeposit
        {
            _rolesRepository.Update(rol);
        }
    }
}
