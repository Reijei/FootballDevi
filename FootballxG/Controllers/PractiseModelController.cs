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
    public class PractiseModelController : ControllerBase
    {
        private readonly DataDbContext _context;

        public PractiseModelController(DataDbContext context)
        {
            _context = context;
        }

        // GET: api/PractiseModel
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PractiseModel>>> GetPractiseModel()
        {
            return await _context.PractiseModel.ToListAsync();
        }

        // GET: api/PractiseModel/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PractiseModel>> GetPractiseModel(int? id)
        {
            var practiseModel = await _context.PractiseModel.FindAsync(id);

            if (practiseModel == null)
            {
                return NotFound();
            }

            return practiseModel;
        }

        // PUT: api/PractiseModel/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPractiseModel(int? id, PractiseModel practiseModel)
        {
            if (id != practiseModel.PractiseID)
            {
                return BadRequest();
            }

            _context.Entry(practiseModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PractiseModelExists(id))
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

        // POST: api/PractiseModel
        [HttpPost]
        public async Task<ActionResult<PractiseModel>> PostPractiseModel(PractiseModel practiseModel)
        {
            _context.PractiseModel.Add(practiseModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPractiseModel", new { id = practiseModel.PractiseID }, practiseModel);
        }

        // DELETE: api/PractiseModel/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PractiseModel>> DeletePractiseModel(int? id)
        {
            var practiseModel = await _context.PractiseModel.FindAsync(id);
            if (practiseModel == null)
            {
                return NotFound();
            }

            _context.PractiseModel.Remove(practiseModel);
            await _context.SaveChangesAsync();

            return practiseModel;
        }

        private bool PractiseModelExists(int? id)
        {
            return _context.PractiseModel.Any(e => e.PractiseID == id);
        }
    }
}
