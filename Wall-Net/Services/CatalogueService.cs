using Wall_Net.Models;
using Wall_Net.Repositories;
using Wall_Net.UnitOfWorks;

namespace Wall_Net.Services
{

    public class CatalogueService : ICatalogueService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly ICatalogueRepository _catalogueRepository;

        public CatalogueService(UnitOfWork unitOfWork, ICatalogueRepository catalogueRepository)
        {
            _unitOfWork = unitOfWork;
            _catalogueRepository = catalogueRepository;
        }

        public async Task<IEnumerable<Catalogue>> GetAllCatalogueItems()
        {
            return await _unitOfWork.CatalogueRepository.GetAllCatalogueItems();
        }

        public async Task<Catalogue> GetCatalogueItemById(int id)
        {
            return await _unitOfWork.CatalogueRepository.GetCatalogueItemById(id);
        }

        public async Task AddCatalogueItem(Catalogue catalogue)
        {
            await _unitOfWork.CatalogueRepository.AddCatalogueItem(catalogue);
            await _unitOfWork.Commit();
        }

        public async Task UpdateCatalogueItem(int id, Catalogue updatedCatalogue)
        {
            await _unitOfWork.CatalogueRepository.UpdateCatalogueItem(id, updatedCatalogue);
            await _unitOfWork.Commit();
        }

        public async Task DeleteCatalogueItem(int id)
        {
            await _unitOfWork.CatalogueRepository.DeleteCatalogueItem(id);
            await _unitOfWork.Commit();
        }
    }

}
