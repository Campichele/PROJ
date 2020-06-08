using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieToGo.Models;

namespace MovieToGo.Controllers
{
    public class FilmPossedesController : Controller
    {
        private readonly MovieToGoDbContext _context;


        ///API connection
        static HttpClient client = new HttpClient();

        public FilmPossedesController(MovieToGoDbContext context)
        {
            if (client.BaseAddress != null)
            {
                client = new HttpClient();
            }
            client.BaseAddress = new Uri("https://movietogoapi.azurewebsites.net/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            _context = context;
        }

        // GET: FilmPossedes
        public async Task<IActionResult> Index()
        {
            var movieToGoDbContext = _context.FilmPossede.Include(f => f.IdFilmNavigation).Include(f => f.IdUserNavigation);
            return View(await movieToGoDbContext.ToListAsync());
        }

        // GET: FilmPossedes/Details/5
        public async Task<IActionResult> Details(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filmPossede = await _context.FilmPossede
                .Include(f => f.IdFilmNavigation)
                .Include(f => f.IdUserNavigation)
                .FirstOrDefaultAsync(m => m.IdFilmPossede == id);
            if (filmPossede == null)
            {
                return NotFound();
            }

            return View(filmPossede);
        }

        // GET: FilmPossedes/Create
        public IActionResult Create()
        {
            ViewData["IdFilm"] = new SelectList(_context.Film, "IdFilm", "Nom");
            ViewData["IdUser"] = new SelectList(_context.Utilisateur, "IdUser", "Email");
            return View();
        }

        // POST: FilmPossedes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdFilmPossede,IdFilm,IdUser")] FilmPossede filmPossede)
        {
            if (ModelState.IsValid)
            {
                _context.Add(filmPossede);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdFilm"] = new SelectList(_context.Film, "IdFilm", "Nom", filmPossede.IdFilm);
            ViewData["IdUser"] = new SelectList(_context.Utilisateur, "IdUser", "Email", filmPossede.IdUser);
            return View(filmPossede);
        }

        // GET: FilmPossedes/Edit/5
        public async Task<IActionResult> Edit(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filmPossede = await _context.FilmPossede.FindAsync(id);
            if (filmPossede == null)
            {
                return NotFound();
            }
            ViewData["IdFilm"] = new SelectList(_context.Film, "IdFilm", "Nom", filmPossede.IdFilm);
            ViewData["IdUser"] = new SelectList(_context.Utilisateur, "IdUser", "Email", filmPossede.IdUser);
            return View(filmPossede);
        }

        // POST: FilmPossedes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(short id, [Bind("IdFilmPossede,IdFilm,IdUser")] FilmPossede filmPossede)
        {
            if (id != filmPossede.IdFilmPossede)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(filmPossede);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FilmPossedeExists(filmPossede.IdFilmPossede))
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
            ViewData["IdFilm"] = new SelectList(_context.Film, "IdFilm", "Nom", filmPossede.IdFilm);
            ViewData["IdUser"] = new SelectList(_context.Utilisateur, "IdUser", "Email", filmPossede.IdUser);
            return View(filmPossede);
        }

        // GET: FilmPossedes/Delete/5
        public async Task<IActionResult> Delete(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filmPossede = await _context.FilmPossede
                .Include(f => f.IdFilmNavigation)
                .Include(f => f.IdUserNavigation)
                .FirstOrDefaultAsync(m => m.IdFilmPossede == id);
            if (filmPossede == null)
            {
                return NotFound();
            }

            return View(filmPossede);
        }

        // POST: FilmPossedes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(short id)
        {
            var filmPossede = await _context.FilmPossede.FindAsync(id);
            _context.FilmPossede.Remove(filmPossede);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FilmPossedeExists(short id)
        {
            return _context.FilmPossede.Any(e => e.IdFilmPossede == id);
        }
    }
}
