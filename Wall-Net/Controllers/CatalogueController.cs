using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Wall_Net.Models;
using Wall_Net.DataAccess;

[Route("api/catalogue")]
[ApiController]
public class CatalogueController : ControllerBase
{
    private readonly WallNetDbContext _context;

    public CatalogueController(WallNetDbContext context)
    {
        _context = context;
    }

    // GET: api/catalogue
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Catalogue>>> GetCatalogue()
    {
        var catalogueItems = await _context.Catalogues.OrderByDescending(c => c.Points).ToListAsync();
        return catalogueItems;
    }

    // GET: api/catalogue/1
    [HttpGet("{id}")]
    public async Task<ActionResult<Catalogue>> GetCatalogue(int id)
    {
        var catalogueItem = await _context.Catalogues.FindAsync(id);

        if (catalogueItem == null)
        {
            return NotFound();
        }

        return catalogueItem;
    }

    // POST: api/catalogue
    [HttpPost]
    public async Task<ActionResult<Catalogue>> PostCatalogue(Catalogue catalogue)
    {
        _context.Catalogues.Add(catalogue);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetCatalogue", new { id = catalogue.Id }, catalogue);
    }

    // PUT: api/catalogue/1
    [HttpPut("{id}")]
    public async Task<IActionResult> PutCatalogue(int id, Catalogue catalogue)
    {
        if (id != catalogue.Id)
        {
            return BadRequest();
        }

        _context.Entry(catalogue).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!CatalogueExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    // DELETE: api/catalogue/1
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCatalogue(int id)
    {
        var catalogueItem = await _context.Catalogues.FindAsync(id);
        if (catalogueItem == null)
        {
            return NotFound();
        }

        _context.Catalogues.Remove(catalogueItem);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool CatalogueExists(int id)
    {
        return _context.Catalogues.Any(e => e.Id == id);
    }
}
