using Wall_Net.Models;
using Wall_Net.Repositories;

namespace Wall_Net.Services
{
    public class FixedTermDepositServices
    {
        private readonly IFixedTermDepositRepository _FixedTermDepositRepository;

        public FixedTermDepositServices(IFixedTermDepositRepository FixedTermDepositRepository)
        {
            _FixedTermDepositRepository = FixedTermDepositRepository;
        }

        public async Task AddFixedTermDeposit(FixedTermDeposit fixedTerm)
        {
            await _FixedTermDepositRepository.Add(fixedTerm);
        }

        public async Task DeleteFixedTermDeposit(int id)
        {
            await _FixedTermDepositRepository.Delete(id);
        }

        public async Task<IEnumerable<FixedTermDeposit>> GetAllFixedTermDeposit()
        {
            return await _FixedTermDepositRepository.GetAll();
        }

        public async Task<FixedTermDeposit> GetFixedTermDepositById(int id)
        {
            return await _FixedTermDepositRepository.GetById(id);
        }

        public async Task UpdateFixedTermDeposit(FixedTermDeposit fixedTerm)
        {
            await _FixedTermDepositRepository.Update(fixedTerm);
        }
    }
}
