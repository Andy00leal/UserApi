using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserApi.Data;
using UserApi.Models;

namespace UserApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CountryController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Country>>> GetCountry()
        {
            return await _context.Countries.ToListAsync();
        }

        [HttpPost]
        public async Task<IActionResult> PostCountry([FromBody] Country country)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.Countries.Add(country);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetCountry), new { id = country.Id }, country);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCountry(int id)
        {
            var country = await _context.Countries.FindAsync(id);

            if (country == null)
                return NotFound();

            return Ok(country);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCountry(int id, Country country)
        {
            if (id != country.Id)
            {
                return BadRequest();
            }

            _context.Entry(country).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CountryExists(id))
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCountry(int id)
        {
            var country = await _context.Countries.FindAsync(id);
            if (country == null)
            {
                return NotFound();
            }

            _context.Countries.Remove(country);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CountryExists(int id)
        {
            return _context.Countries.Any(e => e.Id == id);
        }
    }
}
