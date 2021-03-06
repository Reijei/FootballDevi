﻿using System;
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
    public class MatchController : ControllerBase
    {
        private readonly DataDbContext _context;

        public MatchController(DataDbContext context)
        {
            _context = context;
        }

        // GET: api/Match
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Match>>> GetMatch()
        {
            // return await _context.Match.ToListAsync();

            string userId = User.Claims.First(c => c.Type == "UserID").Value;

            var match = (from a in _context.Match
                         where a.UserID == userId

                         select new
                         {
                             a.MatchID,
                             a.DateTime,
                             a.HomeName,
                             a.AwayName,
                             a.HomeGoals,
                             a.AwayGoals,
                             a.HomeCorners,
                             a.AwayCorners,
                             a.HomeSide,
                             a.AwaySide,
                             a.HomeFree,
                             a.AwayFree,
                             a.HomeTotal,
                             a.AwayTotal,
                             a.HomeXg,
                             a.AwayXg,
                             a.Serie,
                         }).ToList();

            return Ok(new { match });

        }

        // GET: api/Match/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Match>> GetMatch(int? id)
        {
            var match = (from a in _context.Match
                        where a.MatchID == id

                        select new
                        {
                            a.MatchID,
                            a.DateTime,
                            a.HomeName,
                            a.AwayName,
                            a.HomeGoals,
                            a.AwayGoals,
                            a.HomeCorners,
                            a.AwayCorners,
                            a.HomeSide,
                            a.AwaySide,
                            a.HomeFree,
                            a.AwayFree,
                            a.HomeTotal,
                            a.AwayTotal,
                            a.HomeXg,
                            a.AwayXg,
                            a.Serie,
                        }).FirstOrDefault();
            var shot = (from a in _context.Shot
                           where a.MatchID == id

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

        // PUT: api/Match/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMatch(int? id, Match match)
        {
            if (id != match.MatchID)
            {
                return BadRequest();
            }

            _context.Entry(match).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MatchExists(id))
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

        // POST: api/Match
        [HttpPost]
        public async Task<ActionResult<Match>> PostMatch(Match match)
        {
            try
            {


                if (match.MatchID == null)
                {
                    match.UserID = User.Claims.First(c => c.Type == "UserID").Value;

                    _context.Match.Add(match);

                }
                else
                {
                    match.UserID = User.Claims.First(c => c.Type == "UserID").Value;

                    _context.Entry(match).State = EntityState.Modified;
                }
                foreach (var item in match.Shot)
                {
                    if (item.ShotID < 0 || item.ShotID == null)
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

        // DELETE: api/Match/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Match>> DeleteMatch(int? id)
        {
            Match match = _context.Match.Include(y => y.Shot)
                .SingleOrDefault(x => x.MatchID == id);

            foreach (var item in match.Shot.ToList())
            {
                _context.Shot.Remove(item);
            }

            _context.Match.Remove(match);
            _context.SaveChanges();

            return Ok(match);
        }

        private bool MatchExists(int? id)
        {
            return _context.Match.Any(e => e.MatchID == id);
        }
    }
}
