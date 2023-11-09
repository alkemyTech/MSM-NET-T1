using Wall_Net.Models;
using Wall_Net.Repositories;

namespace Wall_Net.Services
{

    public class CatalogueService : ICatalogueService
    {
        private readonly ICatalogueRepository _catalogueRepository;

        public CatalogueService(ICatalogueRepository catalogueRepository)
        {
            _catalogueRepository = catalogueRepository;
        }

        public async Task<IEnumerable<Catalogue>> GetAllCatalogueItems()
        {
            return await _catalogueRepository.GetAllCatalogueItems();
        }

        public async Task<Catalogue> GetCatalogueItemById(int id)
        {
            return await _catalogueRepository.GetCatalogueItemById(id);
        }

        public async Task AddCatalogueItem(Catalogue catalogue)
        {
            await _catalogueRepository.AddCatalogueItem(catalogue);
        }

        public async Task UpdateCatalogueItem(int id, Catalogue updatedCatalogue)
        {
            await _catalogueRepository.UpdateCatalogueItem(id, updatedCatalogue);
        }

        public async Task DeleteCatalogueItem(int id)
        {
            await _catalogueRepository.DeleteCatalogueItem(id);
        }
    }

}
