using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryRegionsController : ControllerBase
    {
        private readonly AdventureWorks2022Context _context;

        public CountryRegionsController(AdventureWorks2022Context context)
        {
            _context = context;
        }

        // GET: api/CountryRegions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CountryRegion>>> GetCountryRegion()
        {
          if (_context.CountryRegion == null)
          {
              return NotFound();
          }
            return await _context.CountryRegion.ToListAsync();
        }

        // GET: api/CountryRegions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CountryRegion>> GetCountryRegion(string id)
        {
          if (_context.CountryRegion == null)
          {
              return NotFound();
          }
            var countryRegion = await _context.CountryRegion.FindAsync(id);

            if (countryRegion == null)
            {
                return NotFound();
            }

            return countryRegion;
        }

        // PUT: api/CountryRegions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCountryRegion(string id, CountryRegion countryRegion)
        {
            if (id != countryRegion.CountryRegionCode)
            {
                return BadRequest();
            }

            _context.Entry(countryRegion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CountryRegionExists(id))
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

        // POST: api/CountryRegions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CountryRegion>> PostCountryRegion(CountryRegion countryRegion)
        {
          if (_context.CountryRegion == null)
          {
              return Problem("Entity set 'AdventureWorks2022Context.CountryRegion'  is null.");
          }
            _context.CountryRegion.Add(countryRegion);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CountryRegionExists(countryRegion.CountryRegionCode))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCountryRegion", new { id = countryRegion.CountryRegionCode }, countryRegion);
        }

        // DELETE: api/CountryRegions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCountryRegion(string id)
        {
            if (_context.CountryRegion == null)
            {
                return NotFound();
            }
            var countryRegion = await _context.CountryRegion.FindAsync(id);
            if (countryRegion == null)
            {
                return NotFound();
            }

            _context.CountryRegion.Remove(countryRegion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CountryRegionExists(string id)
        {
            return (_context.CountryRegion?.Any(e => e.CountryRegionCode == id)).GetValueOrDefault();
        }
    }
}
