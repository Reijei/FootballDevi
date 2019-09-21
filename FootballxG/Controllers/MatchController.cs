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
            return await _context.Match.ToListAsync();
        }

        // GET: api/Match/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Match>> GetMatch(int? id)
        {
            var match = await _context.Match.FindAsync(id);

            if (match == null)
            {
                return NotFound();
            }

            return match;
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
                    _context.Match.Add(match);

                }
                else
                {
                    _context.Entry(match).State = EntityState.Modified;
                }
                foreach (var item in match.Shot)
                {
                    if (item.MatchID != 0)
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
            var match = await _context.Match.FindAsync(id);
            if (match == null)
            {
                return NotFound();
            }

            _context.Match.Remove(match);
            await _context.SaveChangesAsync();

            return match;
        }

        private bool MatchExists(int? id)
        {
            return _context.Match.Any(e => e.MatchID == id);
        }
    }
}
