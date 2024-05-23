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
    public class DepartmentController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DepartmentController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Department>>> GetDepartment()
        {
            return await _context.Departments.ToListAsync();
        }

        [HttpPost]
        public async Task<IActionResult> PostDepartment([FromBody] Department department)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.Departments.Add(department);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetDepartment), new { id = department.Id }, department);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDepartment(int id)
        {
            var department = await _context.Departments.FindAsync(id);

            if (department == null)
                return NotFound();

            return Ok(department);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutDepartment(int id, Department department)
        {
            if (id != department.Id)
            {
                return BadRequest();
            }

            _context.Entry(department).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepartmentExists(id))
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
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            var department = await _context.Departments.FindAsync(id);
            if (department == null)
            {
                return NotFound();
            }

            _context.Departments.Remove(department);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DepartmentExists(int id)
        {
            return _context.Departments.Any(e => e.Id == id);
        }
    }
}
