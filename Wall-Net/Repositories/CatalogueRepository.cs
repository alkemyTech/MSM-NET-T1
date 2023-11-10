using Wall_Net.Models;
using Microsoft.EntityFrameworkCore;
using Wall_Net.DataAccess;

namespace Wall_Net.Repositories;
public class CatalogueRepository : ICatalogueRepository
{
    private readonly WallNetDbContext _context;

    public CatalogueRepository(WallNetDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Catalogue>> GetAllCatalogueItems()
    {
        return await _context.Catalogues.ToListAsync();
    }

    public async Task<Catalogue> GetCatalogueItemById(int id)
    {
        return await _context.Catalogues.FindAsync(id);
    }

    public async Task AddCatalogueItem(Catalogue catalogue)
    {
        _context.Catalogues.Add(catalogue);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateCatalogueItem(int id, Catalogue updatedCatalogue)
    {
        if (id != updatedCatalogue.Id)
        {
            throw new ArgumentException("ID mismatch");
        }

        _context.Entry(updatedCatalogue).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteCatalogueItem(int id)
    {
        var catalogueItem = await _context.Catalogues.FindAsync(id);
        if (catalogueItem != null)
        {
            _context.Catalogues.Remove(catalogueItem);
            await _context.SaveChangesAsync();
        }
    }
}
