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
    public class MatchModelController : ControllerBase
    {
        private readonly DataDbContext _context;

        public MatchModelController(DataDbContext context)
        {
            _context = context;
        }

        // GET: api/MatchModel
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MatchModel>>> GetMatchModel()
        {
            return await _context.MatchModel.ToListAsync();
        }

        // GET: api/MatchModel/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MatchModel>> GetMatchModel(int? id)
        {
            var matchModel = await _context.MatchModel.FindAsync(id);

            if (matchModel == null)
            {
                return NotFound();
            }

            return matchModel;
        }

        // PUT: api/MatchModel/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMatchModel(int? id, MatchModel matchModel)
        {
            if (id != matchModel.MatchID)
            {
                return BadRequest();
            }

            _context.Entry(matchModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MatchModelExists(id))
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

        // POST: api/MatchModel
        [HttpPost]
        public async Task<ActionResult<MatchModel>> PostMatchModel(MatchModel matchModel)
        {
            _context.MatchModel.Add(matchModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMatchModel", new { id = matchModel.MatchID }, matchModel);
        }

        // DELETE: api/MatchModel/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MatchModel>> DeleteMatchModel(int? id)
        {
            var matchModel = await _context.MatchModel.FindAsync(id);
            if (matchModel == null)
            {
                return NotFound();
            }

            _context.MatchModel.Remove(matchModel);
            await _context.SaveChangesAsync();

            return matchModel;
        }

        private bool MatchModelExists(int? id)
        {
            return _context.MatchModel.Any(e => e.MatchID == id);
        }
    }
}
