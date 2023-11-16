using Wall_Net.Models;

namespace Wall_Net.Repositories
{
    public interface IFixedTermDepositRepository
    {
        Task<FixedTermDeposit> GetById(int id);
        Task<FixedTermDeposit> GetFixedByIdUser(int idUser, int idFixed);
        Task<IEnumerable<FixedTermDeposit>> GetAll();
        Task<IEnumerable<FixedTermDeposit>> GetAllById(int id);
        Task Add(FixedTermDeposit rol, int idUser);
        Task Update(FixedTermDeposit rol);
        Task UpdateAccount(FixedTermDeposit rol);
        Task Delete(int id);
    }
}
