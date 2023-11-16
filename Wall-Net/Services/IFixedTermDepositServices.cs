using Wall_Net.Models;
using Wall_Net.Models.DTO;

namespace Wall_Net.Services
{
    public interface IFixedTermDepositServices
    {
        Task<FixedTermDeposit> GetFixedTermDepositById(int id);
        Task<FixedTermDeposit> GetFixedByUser(int idUser, int idFixed);
        Task<IEnumerable<FixedTermDeposit>> GetAllFixedTermDeposit();
        Task<IEnumerable<FixedTermDeposit>> GetAllById(int id);
        Task AddFixedTermDeposit(FixedTermsDepositDTO fixedDTO,int idUser);
        Task UpdateFixedTermDeposit(FixedTermDeposit fixedTerm);
        Task DeleteFixedTermDeposit(int id);
    }
}
