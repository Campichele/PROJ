using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieToGo.Models;

namespace MovieToGo.Controllers
{
    public class FaitPartiesController : Controller
    {
        private readonly MovieToGoDbContext _context;

        public FaitPartiesController(MovieToGoDbContext context)
        {
            _context = context;
        }

        // GET: FaitParties
        public async Task<IActionResult> Index()
        {
            var movieToGoDbContext = _context.FaitPartie.Include(f => f.IdFilmNavigation).Include(f => f.IdGenreNavigation);
            return View(await movieToGoDbContext.ToListAsync());
        }

        // GET: FaitParties/Details/5
        public async Task<IActionResult> Details(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var faitPartie = await _context.FaitPartie
                .Include(f => f.IdFilmNavigation)
                .Include(f => f.IdGenreNavigation)
                .FirstOrDefaultAsync(m => m.IdGenre == id);
            if (faitPartie == null)
            {
                return NotFound();
            }

            return View(faitPartie);
        }

        // GET: FaitParties/Create
        public IActionResult Create()
        {
            ViewData["IdFilm"] = new SelectList(_context.Film, "IdFilm", "Nom");
            ViewData["IdGenre"] = new SelectList(_context.Genre, "IdGenre", "Nom");
            return View();
        }

        // POST: FaitParties/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdGenre,IdFilm")] FaitPartie faitPartie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(faitPartie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdFilm"] = new SelectList(_context.Film, "IdFilm", "Nom", faitPartie.IdFilm);
            ViewData["IdGenre"] = new SelectList(_context.Genre, "IdGenre", "Nom", faitPartie.IdGenre);
            return View(faitPartie);
        }

        // GET: FaitParties/Edit/5
        public async Task<IActionResult> Edit(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var faitPartie = await _context.FaitPartie.FindAsync(id);
            if (faitPartie == null)
            {
                return NotFound();
            }
            ViewData["IdFilm"] = new SelectList(_context.Film, "IdFilm", "Nom", faitPartie.IdFilm);
            ViewData["IdGenre"] = new SelectList(_context.Genre, "IdGenre", "Nom", faitPartie.IdGenre);
            return View(faitPartie);
        }

        // POST: FaitParties/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(short id, [Bind("IdGenre,IdFilm")] FaitPartie faitPartie)
        {
            if (id != faitPartie.IdGenre)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(faitPartie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FaitPartieExists(faitPartie.IdGenre))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdFilm"] = new SelectList(_context.Film, "IdFilm", "Nom", faitPartie.IdFilm);
            ViewData["IdGenre"] = new SelectList(_context.Genre, "IdGenre", "Nom", faitPartie.IdGenre);
            return View(faitPartie);
        }

        // GET: FaitParties/Delete/5
        public async Task<IActionResult> Delete(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var faitPartie = await _context.FaitPartie
                .Include(f => f.IdFilmNavigation)
                .Include(f => f.IdGenreNavigation)
                .FirstOrDefaultAsync(m => m.IdGenre == id);
            if (faitPartie == null)
            {
                return NotFound();
            }

            return View(faitPartie);
        }

        // POST: FaitParties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(short id)
        {
            var faitPartie = await _context.FaitPartie.FindAsync(id);
            _context.FaitPartie.Remove(faitPartie);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FaitPartieExists(short id)
        {
            return _context.FaitPartie.Any(e => e.IdGenre == id);
        }
    }
}
