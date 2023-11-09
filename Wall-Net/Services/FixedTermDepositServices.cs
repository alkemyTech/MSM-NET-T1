using Wall_Net.Models;
using Wall_Net.Repositories;
using Wall_Net.UnitOfWorks;

namespace Wall_Net.Services
{
    public class FixedTermDepositServices : IFixedTermDepositServices
    {
        //private readonly IFixedTermDepositRepository _FixedTermDepositRepository;
        private readonly UnitOfWork _unitOfWork;

        public FixedTermDepositServices(/*IFixedTermDepositRepository FixedTermDepositRepository*/UnitOfWork unitOfWork)
        {
            //_FixedTermDepositRepository = FixedTermDepositRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task AddFixedTermDeposit(FixedTermDeposit fixedTerm)
        {
            //await _FixedTermDepositRepository.Add(fixedTerm);
            await _unitOfWork.FixedTermDepositRepository.Add(fixedTerm);
        }

        public async Task DeleteFixedTermDeposit(int id)
        {
            await _unitOfWork.FixedTermDepositRepository.Delete(id);
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
            await _unitOfWork.FixedTermDepositRepository.Update(fixedTerm);
        }
    }
}
