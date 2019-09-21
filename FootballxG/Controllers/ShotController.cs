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
    public class ShotController : ControllerBase
    {
        private readonly DataDbContext _context;

        public ShotController(DataDbContext context)
        {
            _context = context;
        }

        // GET: api/Shot
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Shot>>> GetShot()
        {
            return await _context.Shot.ToListAsync();
        }

        // GET: api/Shot/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Shot>> GetShot(int? id)
        {
            var shot = await _context.Shot.FindAsync(id);

            if (shot == null)
            {
                return NotFound();
            }

            return shot;
        }

        // PUT: api/Shot/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShot(int? id, Shot shot)
        {
            if (id != shot.ShotID)
            {
                return BadRequest();
            }

            _context.Entry(shot).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShotExists(id))
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

        // POST: api/Shot
        [HttpPost]
        public async Task<ActionResult<Shot>> PostShot(Shot shot)
        {
            _context.Shot.Add(shot);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetShot", new { id = shot.ShotID }, shot);
        }

        // DELETE: api/Shot/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Shot>> DeleteShot(int? id)
        {
            var shot = await _context.Shot.FindAsync(id);
            if (shot == null)
            {
                return NotFound();
            }

            _context.Shot.Remove(shot);
            await _context.SaveChangesAsync();

            return shot;
        }

        private bool ShotExists(int? id)
        {
            return _context.Shot.Any(e => e.ShotID == id);
        }
    }
}
