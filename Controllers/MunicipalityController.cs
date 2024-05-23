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
    public class MunicipalityController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MunicipalityController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Municipality>>> GetMunicipality()
        {
            return await _context.Municipalities.ToListAsync();
        }

        [HttpPost]
        public async Task<IActionResult> PostMunicipality([FromBody] Municipality municipality)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.Municipalities.Add(municipality);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetMunicipality), new { id = municipality.Id }, municipality);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMunicipality(int id)
        {
            var municipality = await _context.Municipalities.FindAsync(id);

            if (municipality == null)
                return NotFound();

            return Ok(municipality);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutMunicipality(int id, Municipality municipality)
        {
            if (id != municipality.Id)
            {
                return BadRequest();
            }

            _context.Entry(municipality).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MunicipalityExists(id))
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
        public async Task<IActionResult> DeleteMunicipality(int id)
        {
            var municipality = await _context.Municipalities.FindAsync(id);
            if (municipality == null)
            {
                return NotFound();
            }

            _context.Municipalities.Remove(municipality);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MunicipalityExists(int id)
        {
            return _context.Municipalities.Any(e => e.Id == id);
        }
    }
}
