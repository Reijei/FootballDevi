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
    public class ShotModelController : ControllerBase
    {
        private readonly DataDbContext _context;

        public ShotModelController(DataDbContext context)
        {
            _context = context;
        }

        // GET: api/ShotModel
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShotModel>>> GetShotModel()
        {
            return await _context.ShotModel.ToListAsync();
        }

        // GET: api/ShotModel/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ShotModel>> GetShotModel(int? id)
        {
            var shotModel = await _context.ShotModel.FindAsync(id);

            if (shotModel == null)
            {
                return NotFound();
            }

            return shotModel;
        }

        // PUT: api/ShotModel/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShotModel(int? id, ShotModel shotModel)
        {
            if (id != shotModel.ShotID)
            {
                return BadRequest();
            }

            _context.Entry(shotModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShotModelExists(id))
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

        // POST: api/ShotModel
        [HttpPost]
        public async Task<ActionResult<ShotModel>> PostShotModel(ShotModel shotModel)
        {
            _context.ShotModel.Add(shotModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetShotModel", new { id = shotModel.ShotID }, shotModel);
        }

        // DELETE: api/ShotModel/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ShotModel>> DeleteShotModel(int? id)
        {
            var shotModel = await _context.ShotModel.FindAsync(id);
            if (shotModel == null)
            {
                return NotFound();
            }

            _context.ShotModel.Remove(shotModel);
            await _context.SaveChangesAsync();

            return shotModel;
        }

        private bool ShotModelExists(int? id)
        {
            return _context.ShotModel.Any(e => e.ShotID == id);
        }
    }
}
