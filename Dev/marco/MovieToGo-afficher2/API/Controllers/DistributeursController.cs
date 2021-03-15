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
    public class DistributeursController : ControllerBase
    {
        private readonly MovieToGoDbContext _context;

        public DistributeursController(MovieToGoDbContext context)
        {
            _context = context;
        }

        // GET: api/Distributeurs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Distributeur>>> GetDistributeur()
        {
            return await _context.Distributeur.ToListAsync();
        }

        // GET: api/Distributeurs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Distributeur>> GetDistributeur(short id)
        {
            var distributeur = await _context.Distributeur.FindAsync(id);

            if (distributeur == null)
            {
                return NotFound();
            }

            return distributeur;
        }

        // PUT: api/Distributeurs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDistributeur(short id, Distributeur distributeur)
        {
            if (id != distributeur.IdDistributeur)
            {
                return BadRequest();
            }

            _context.Entry(distributeur).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DistributeurExists(id))
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

        // POST: api/Distributeurs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Distributeur>> PostDistributeur(Distributeur distributeur)
        {
            _context.Distributeur.Add(distributeur);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDistributeur", new { id = distributeur.IdDistributeur }, distributeur);
        }

        // DELETE: api/Distributeurs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Distributeur>> DeleteDistributeur(short id)
        {
            var distributeur = await _context.Distributeur.FindAsync(id);
            if (distributeur == null)
            {
                return NotFound();
            }

            _context.Distributeur.Remove(distributeur);
            await _context.SaveChangesAsync();

            return distributeur;
        }

        private bool DistributeurExists(short id)
        {
            return _context.Distributeur.Any(e => e.IdDistributeur == id);
        }
    }
}
