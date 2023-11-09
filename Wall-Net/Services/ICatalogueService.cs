using Wall_Net.Models;


namespace Wall_Net.Services
{
    public interface ICatalogueService
    {
        Task<IEnumerable<Catalogue>> GetAllCatalogueItems();
        Task<Catalogue> GetCatalogueItemById(int id);
        Task AddCatalogueItem(Catalogue catalogue);
        Task UpdateCatalogueItem(int id, Catalogue updatedCatalogue);
        Task DeleteCatalogueItem(int id);
    }

}
