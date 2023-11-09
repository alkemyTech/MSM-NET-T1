using Wall_Net.Models;
using Wall_Net.Repositories;
using Wall_Net.UnitOfWorks;

namespace Wall_Net.Services
{
    public class RolesServices : IRolesServices
    {
        private readonly UnitOfWork _unitOfWork;
        public RolesServices(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddRoles(Roles rol)
        {
            _unitOfWork.RolesRepository.Add(rol);
            await _unitOfWork.Commit();
        }

        public async Task DeleteRoles(int id)
        {
            _unitOfWork.RolesRepository.Delete(id);
            await _unitOfWork.Commit();
        }

        public async Task<IEnumerable<Roles>> GetAllRoles()
        {
            return await _unitOfWork.RolesRepository.GetAll();
        }

        public async Task<Roles> GetRolesById(int id)
        {
            return await _unitOfWork.RolesRepository.GetById(id);
        }
        public async Task UpdateRoles(Roles rol)
        {
            _unitOfWork.RolesRepository.Update(rol);
            await _unitOfWork.Commit();
        }
        public async Task SaveChanges()
        {
            await _unitOfWork.Commit();
        }
    }
}
