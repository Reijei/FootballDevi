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
            //return await _context.Practise.ToListAsync();

            string userId = User.Claims.First(c => c.Type == "UserID").Value;

            var match = (from a in _context.Practise
                         where a.UserID == userId

                         select new
                         {
                             a.PractiseID,
                             a.DateTime,
                             a.TeamName,
                             a.Serie,
                             a.Goals,
                             a.Corners,
                             a.Side,
                             a.Free,
                             a.Total,
                             a.Xg,
                         }).ToList();
            return Ok(new { match });

        }

        // GET: api/Practise/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Practise>> GetPractise(int? id)
        {
            var match = (from a in _context.Practise
                         where a.PractiseID == id

                         select new
                         {
                             a.PractiseID,
                             a.DateTime,
                             a.TeamName,
                             a.Serie,
                             a.Goals,
                             a.Corners,
                             a.Side,
                             a.Free,
                             a.Total,
                             a.Xg,
                         }).FirstOrDefault();
            var shot = (from a in _context.Shot
                        where a.PractiseID == id

                        select new
                        {
                            a.ShotID,
                            a.DateTime,
                            a.Time,
                            a.Half,
                            a.ShooterName,
                            a.TeamName,
                            a.Opponent,
                            a.Assist,
                            a.PositionX,
                            a.PositionY,
                            a.BodyPart,
                            a.Result,
                            a.Breakway,
                            a.Pattern,
                            a.BigChange,
                            a.NoChange,
                            a.Defenders,
                            a.Xg,
                            a.Comments,
                            a.MatchID,
                            a.PractiseID,
                        }).ToList();
            return Ok(new { match, shot });
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
            try
            {


                if (practise.PractiseID == null)
                {
                    practise.UserID = User.Claims.First(c => c.Type == "UserID").Value;
                    _context.Practise.Add(practise);

                }
                else
                {
                    practise.UserID = User.Claims.First(c => c.Type == "UserID").Value;

                    _context.Entry(practise).State = EntityState.Modified;
                }
                foreach (var item in practise.Shot)
                {
                    if (item.ShotID == null || item.ShotID < 0)
                    {
                        _context.Shot.Add(item);

                    }
                    else
                    {
                        _context.Entry(item).State = EntityState.Modified;
                    }

                }


                _context.SaveChanges();

                return Ok();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        // DELETE: api/Practise/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Practise>> DeletePractise(int? id)
        {
            Practise practise = _context.Practise.Include(y => y.Shot)
                .SingleOrDefault(x => x.PractiseID == id);

            foreach (var item in practise.Shot.ToList())
            {
                _context.Shot.Remove(item);
            }

            _context.Practise.Remove(practise);
            _context.SaveChanges();

            return Ok(practise);
        }

        private bool PractiseExists(int? id)
        {
            return _context.Practise.Any(e => e.PractiseID == id);
        }
    }
}
