using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieToGo.Models;

namespace MovieToGo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActeursController : ControllerBase
    {
        private readonly MLR1 _context;

        public ActeursController(MLR1 context)
        {
            _context = context;
        }

        // GET: api/Acteurs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Acteurs>>> GetActeurs()
        {
            return await _context.Acteurs.ToListAsync();
        }

        // GET: api/Acteurs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Acteurs>> GetActeurs(short id)
        {
            var acteurs = await _context.Acteurs.FindAsync(id);

            if (acteurs == null)
            {
                return NotFound();
            }

            return acteurs;
        }

        // PUT: api/Acteurs/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutActeurs(short id, Acteurs acteurs)
        {
            if (id != acteurs.IdActeur)
            {
                return BadRequest();
            }

            _context.Entry(acteurs).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActeursExists(id))
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

        // POST: api/Acteurs
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Acteurs>> PostActeurs(Acteurs acteurs)
        {
            _context.Acteurs.Add(acteurs);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetActeurs", new { id = acteurs.IdActeur }, acteurs);
        }

        // DELETE: api/Acteurs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Acteurs>> DeleteActeurs(short id)
        {
            var acteurs = await _context.Acteurs.FindAsync(id);
            if (acteurs == null)
            {
                return NotFound();
            }

            _context.Acteurs.Remove(acteurs);
            await _context.SaveChangesAsync();

            return acteurs;
        }

        private bool ActeursExists(short id)
        {
            return _context.Acteurs.Any(e => e.IdActeur == id);
        }
    }
}
