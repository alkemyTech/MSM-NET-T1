using Wall_Net.Models;

namespace Wall_Net.Services
{
    public interface IFixedTermDepositServices
    {
        Task<FixedTermDeposit> GetFixedTermDepositById(int id);
        Task<IEnumerable<FixedTermDeposit>> GetAllFixedTermDeposit();
        Task AddFixedTermDeposit(FixedTermDeposit fixedTerm);
        Task UpdateFixedTermDeposit(FixedTermDeposit fixedTerm);
        Task DeleteFixedTermDeposit(int id);
    }
}
