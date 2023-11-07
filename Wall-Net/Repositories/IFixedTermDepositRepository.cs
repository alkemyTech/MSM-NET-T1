using Wall_Net.Models;

namespace Wall_Net.Repositories
{
    public interface IFixedTermDepositRepository
    {
        Task<FixedTermDeposit> GetById(int id);
        Task<IEnumerable<FixedTermDeposit>> GetAll();
        Task Add(FixedTermDeposit rol);
        Task Update(FixedTermDeposit rol);
        Task Delete(int id);
    }
}
