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
    public class TeamController : ControllerBase
    {
        private readonly DataDbContext _context;

        public TeamController(DataDbContext context)
        {
            _context = context;
        }

        // GET: api/Team
        [HttpGet]
        public async Task<ActionResult<Team>> GetTeam()
        {

            // userid testi
            string userId = User.Claims.First(c => c.Type == "UserID").Value;

            var team = (from a in _context.Team
                        where a.UserID == userId

                        select new
                        {
                            a.TeamID,
                            a.TeamName,
                            a.Wins,
                            a.Loses,
                            a.Serie,
                            a.Position,
                        }).ToList();

            return Ok(new { team });

           // return await _context.Team.ToListAsync();
        }

        // GET: api/Team/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Team>> GetTeam(int id)
        {
            var team = (from a in _context.Team
                        where a.TeamID == id

                        select new
                        {
                            a.TeamID,
                            a.TeamName,
                            a.Wins,
                            a.Loses,
                            a.Serie,
                            a.Position,
                            DeletedOrderItemIds = ""
                        }).FirstOrDefault();
            var players = (from a in _context.Player
                           where a.TeamID == id

                           select new
                           {
                               a.PlayerID,
                               a.TeamID,
                               a.PlayerName,
                               a.No,
                               a.Position,
                               a.Matches,
                               a.Minutes,
                               a.Goals,
                               a.Passes,
                               a.Spots,
                               a.CardYellow,
                               a.CardRed,
                               a.Xg,
                               a.XgP,
                               a.Xa,
                               a.XaP,
                               a.Xg90,
                               a.Xa90
                           }).ToList();
            return Ok(new { team, players });
        }

        // PUT: api/Team/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTeam(int id, Team team)
        {
            if (id != team.TeamID)
            {
                return BadRequest();
            }

            _context.Entry(team).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeamExists(id))
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

        // POST: api/Team
        [HttpPost]
        public async Task<ActionResult<Team>> PostTeam(Team team)
        {
            try
            {


                if (team.TeamID == null)
                {

                    team.UserID = User.Claims.First(c => c.Type == "UserID").Value;
                    _context.Team.Add(team);

                }
                else
                {
                    team.UserID = User.Claims.First(c => c.Type == "UserID").Value;

                    _context.Entry(team).State = EntityState.Modified;
                }
                foreach (var item in team.Player)
                {
                    if (item.PlayerID < 0 || item.PlayerID == null)
                    {
                        _context.Player.Add(item);

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

        // DELETE: api/Team/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Team>> DeleteTeam(int id)
        {
            Team team = _context.Team.Include(y => y.Player)
            .SingleOrDefault(x => x.TeamID == id);

            foreach (var item in team.Player.ToList())
            {
                _context.Player.Remove(item);
            }

            _context.Team.Remove(team);
            _context.SaveChanges();

            return Ok(team);
        }

        private bool TeamExists(int id)
        {
            return _context.Team.Any(e => e.TeamID == id);
        }
    }
}
