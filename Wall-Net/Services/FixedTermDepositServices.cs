using Wall_Net.Models;
using Wall_Net.UnitOfWorks;

namespace Wall_Net.Services
{
    public class FixedTermDepositServices : IFixedTermDepositServices
    {
        private readonly UnitOfWork _unitOfWork;

        public FixedTermDepositServices(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddFixedTermDeposit(FixedTermDeposit fixedTerm)
        {
            _unitOfWork.FixedTermDepositRepository.Add(fixedTerm);
            await _unitOfWork.Commit();
        }

        public async Task DeleteFixedTermDeposit(int id)
        {
            _unitOfWork.FixedTermDepositRepository.Delete(id);
            await _unitOfWork.Commit();
        }

        public async Task<IEnumerable<FixedTermDeposit>> GetAllFixedTermDeposit()
        {
            return await _unitOfWork.FixedTermDepositRepository.GetAll();
        }

        public async Task<FixedTermDeposit> GetFixedTermDepositById(int id)
        {
            return await _unitOfWork.FixedTermDepositRepository.GetById(id);
        }

        public async Task UpdateFixedTermDeposit(FixedTermDeposit fixedTerm)
        {
            _unitOfWork.FixedTermDepositRepository.Update(fixedTerm);
            await _unitOfWork.Commit();
        }
        public async Task SaveChanges()
        {
            await _unitOfWork.Commit();
        }
    }
}
