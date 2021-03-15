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
    public class FilmPossedesController : ControllerBase
    {
        private readonly MovieToGoDbContext _context;

        public FilmPossedesController(MovieToGoDbContext context)
        {
            _context = context;
        }

        // GET: api/FilmPossedes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FilmPossede>>> GetFilmPossede()
        {
            return await _context.FilmPossede.ToListAsync();
        }

        // GET: api/FilmPossedes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FilmPossede>> GetFilmPossede(short id)
        {
            var filmPossede = await _context.FilmPossede.FindAsync(id);

            if (filmPossede == null)
            {
                return NotFound();
            }

            return filmPossede;
        }

        // PUT: api/FilmPossedes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFilmPossede(short id, FilmPossede filmPossede)
        {
            if (id != filmPossede.IdFilmPossede)
            {
                return BadRequest();
            }

            _context.Entry(filmPossede).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FilmPossedeExists(id))
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

        // POST: api/FilmPossedes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<FilmPossede>> PostFilmPossede(FilmPossede filmPossede)
        {
            _context.FilmPossede.Add(filmPossede);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFilmPossede", new { id = filmPossede.IdFilmPossede }, filmPossede);
        }

        // DELETE: api/FilmPossedes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<FilmPossede>> DeleteFilmPossede(short id)
        {
            var filmPossede = await _context.FilmPossede.FindAsync(id);
            if (filmPossede == null)
            {
                return NotFound();
            }

            _context.FilmPossede.Remove(filmPossede);
            await _context.SaveChangesAsync();

            return filmPossede;
        }

        private bool FilmPossedeExists(short id)
        {
            return _context.FilmPossede.Any(e => e.IdFilmPossede == id);
        }
    }
}
