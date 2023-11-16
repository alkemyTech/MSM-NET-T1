using Wall_Net.Models;
using Wall_Net.Models.DTO;

namespace Wall_Net.Repositories
{
    public interface IFixedTermDepositRepository
    {
        Task<FixedTermDeposit> GetById(int id);
        Task<FixedTermDeposit> GetFixedByIdUser(int idUser, int idFixed);
        Task<IEnumerable<FixedTermDeposit>> GetAll();
        Task<IEnumerable<FixedTermDeposit>> GetAllById(int id);
        Task Add(FixedTermsDepositDTO rol, int idUser);
        Task Update(FixedTermDeposit rol);
        Task Delete(int id);
    }
}
