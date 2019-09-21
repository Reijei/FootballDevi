using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FootballxG.Models;

namespace FootballxG.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PractiseController : ControllerBase
    {
        private readonly DataDbContext _context;

        public PractiseController(DataDbContext context)
        {
            _context = context;
        }

        // GET: api/Practise
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Practise>>> GetPractise()
        {
            return await _context.Practise.ToListAsync();
        }

        // GET: api/Practise/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Practise>> GetPractise(int? id)
        {
            var practise = await _context.Practise.FindAsync(id);

            if (practise == null)
            {
                return NotFound();
            }

            return practise;
        }

        // PUT: api/Practise/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPractise(int? id, Practise practise)
        {
            if (id != practise.PractiseID)
            {
                return BadRequest();
            }

            _context.Entry(practise).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PractiseExists(id))
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

        // POST: api/Practise
        [HttpPost]
        public async Task<ActionResult<Practise>> PostPractise(Practise practise)
        {
            _context.Practise.Add(practise);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPractise", new { id = practise.PractiseID }, practise);
        }

        // DELETE: api/Practise/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Practise>> DeletePractise(int? id)
        {
            var practise = await _context.Practise.FindAsync(id);
            if (practise == null)
            {
                return NotFound();
            }

            _context.Practise.Remove(practise);
            await _context.SaveChangesAsync();

            return practise;
        }

        private bool PractiseExists(int? id)
        {
            return _context.Practise.Any(e => e.PractiseID == id);
        }
    }
}
