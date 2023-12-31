﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Wall_Net.Models;
using Wall_Net.DataAccess;
using Wall_Net.Services;

[Route("api/catalogue")]
[ApiController]
public class CatalogueController : ControllerBase
{
    private readonly WallNetDbContext _context;
    private readonly ICatalogueService _catalogueService;

    public CatalogueController(ICatalogueService catalogueService)
    {
        _catalogueService = catalogueService;
    }

    // GET: api/catalogue
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        try
        {
            var catalogues= await _catalogueService.GetAllCatalogueItems();
            return Ok(catalogues);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Internal Server Error" });
        }
    }
    
    // GET: api/catalogue/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        try
        {
            var catalogueItem = await _catalogueService.GetCatalogueItemById(id);

            return Ok(catalogueItem);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Internal Server Error" });
        }
    }

    /*
    // POST: api/catalogue
    [HttpPost]
    public async Task<ActionResult<Catalogue>> PostCatalogue(Catalogue catalogue)
    {
        try
        {
            _context.Catalogues.Add(catalogue);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCatalogue", new { id = catalogue.Id }, catalogue);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Internal Server Error" });
        }
    }

    // PUT: api/catalogue/1
    [HttpPut("{id}")]
    public async Task<IActionResult> PutCatalogue(int id, Catalogue catalogue)
    {
        try
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
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Internal Server Error" });
        }
    }

    // DELETE: api/catalogue/1
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCatalogue(int id)
    {
        try
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
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Internal Server Error" });
        }
    }

    private bool CatalogueExists(int id)
    {
            return _context.Catalogues.Any(e => e.Id == id);   
    }*/
}
