using Wall_Net.Models;
using Wall_Net.Repositories;
using Wall_Net.UnitOfWorks;

namespace Wall_Net.Services
{
    public class RolesServices : IRolesServices
    {
        //private readonly IRolesRepository _rolesRepository;
        private readonly UnitOfWork _unitOfWork;
        public RolesServices(/*IRolesRepository rolesRepository,*/ UnitOfWork unitOfWork)
        {
            //_rolesRepository = rolesRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task AddRoles(Roles rol)
        {
            //await _rolesRepository.Add(rol);
            await _unitOfWork.RolesRepository.Add(rol);
        }

        public async Task DeleteRoles(int id)
        {
            await _unitOfWork.RolesRepository.Delete(id);
        }

        public async Task<IEnumerable<Roles>> GetAllRoles()
        {
            return  await _unitOfWork.RolesRepository.GetAll();
        }

        public async Task<Roles> GetRolesById(int id)
        {
            return await _unitOfWork.RolesRepository.GetById(id);
        }
        public async Task UpdateRoles(Roles rol)
        {
            await _unitOfWork.RolesRepository.Update(rol);
        }
    }
}
