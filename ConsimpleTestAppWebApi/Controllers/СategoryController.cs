using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ConsimpleTestAppWebApi.Data;
using ConsimpleTestAppWebApi.Models;

namespace ConsimpleTestAppWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class СategoryController : ControllerBase
    {
        private readonly ConsimpleTestDbContext _context;

        public СategoryController(ConsimpleTestDbContext context)
        {
            _context = context;
        }

        // GET: api/Сategory
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Сategory>>> GetСategories()
        {
            return await _context.Сategories.ToListAsync();
        }

        // GET: api/Сategory/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Сategory>> GetСategory(int id)
        {
            var сategory = await _context.Сategories.FindAsync(id);

            if (сategory == null)
            {
                return NotFound();
            }

            return сategory;
        }

        // PUT: api/Сategory/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutСategory(int id, Сategory сategory)
        {
            if (id != сategory.Id)
            {
                return BadRequest();
            }

            _context.Entry(сategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!СategoryExists(id))
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

        // POST: api/Сategory
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Сategory>> PostСategory(Сategory сategory)
        {
            _context.Сategories.Add(сategory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetСategory", new { id = сategory.Id }, сategory);
        }

        // DELETE: api/Сategory/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteСategory(int id)
        {
            var сategory = await _context.Сategories.FindAsync(id);
            if (сategory == null)
            {
                return NotFound();
            }

            _context.Сategories.Remove(сategory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool СategoryExists(int id)
        {
            return _context.Сategories.Any(e => e.Id == id);
        }
    }
}
