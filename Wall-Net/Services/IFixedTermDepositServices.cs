using Wall_Net.Models;

namespace Wall_Net.Services
{
    public interface IFixedTermDepositServices
    {
        Task<FixedTermDeposit> GetFixedTermDepositById(int id);
        Task<FixedTermDeposit> GetFixedByUser(int idUser, int idFixed);
        Task<IEnumerable<FixedTermDeposit>> GetAllFixedTermDeposit();
        Task<IEnumerable<FixedTermDeposit>> GetAllById(int id);
        Task AddFixedTermDeposit(FixedTermDeposit fixedTerm, int idUser);
        Task UpdateFixedTermDeposit(FixedTermDeposit fixedTerm);
        Task UpdateAccountMoney(FixedTermDeposit fixedTerm);
        Task DeleteFixedTermDeposit(int id);
    }
}
