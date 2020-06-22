using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NationalitesController : ControllerBase
    {
        private readonly MovieToGoDbContext _context;

        public NationalitesController(MovieToGoDbContext context)
        {
            _context = context;
        }

        // GET: api/Nationalites
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Nationalite>>> GetNationalite()
        {
            return await _context.Nationalite.ToListAsync();
        }

        // GET: api/Nationalites/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Nationalite>> GetNationalite(short id)
        {
            var nationalite = await _context.Nationalite.FindAsync(id);

            if (nationalite == null)
            {
                return NotFound();
            }

            return nationalite;
        }

        // PUT: api/Nationalites/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNationalite(short id, Nationalite nationalite)
        {
            if (id != nationalite.IdNationalite)
            {
                return BadRequest();
            }

            _context.Entry(nationalite).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NationaliteExists(id))
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

        // POST: api/Nationalites
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Nationalite>> PostNationalite(Nationalite nationalite)
        {
            _context.Nationalite.Add(nationalite);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNationalite", new { id = nationalite.IdNationalite }, nationalite);
        }

        // DELETE: api/Nationalites/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Nationalite>> DeleteNationalite(short id)
        {
            var nationalite = await _context.Nationalite.FindAsync(id);
            if (nationalite == null)
            {
                return NotFound();
            }

            _context.Nationalite.Remove(nationalite);
            await _context.SaveChangesAsync();

            return nationalite;
        }

        private bool NationaliteExists(short id)
        {
            return _context.Nationalite.Any(e => e.IdNationalite == id);
        }
    }
}
