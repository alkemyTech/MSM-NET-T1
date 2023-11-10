using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Wall_Net.Models;

namespace Wall_Net.Repositories;
public interface ICatalogueRepository
{
    Task<IEnumerable<Catalogue>> GetAllCatalogueItems();
    Task<Catalogue> GetCatalogueItemById(int id);
    Task AddCatalogueItem(Catalogue catalogue);
    Task UpdateCatalogueItem(int id, Catalogue updatedCatalogue);
    Task DeleteCatalogueItem(int id);
}
 