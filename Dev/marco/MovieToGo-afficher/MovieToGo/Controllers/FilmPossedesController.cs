using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieToGo.Models;
using MovieToGo.ViewModels;

namespace MovieToGo.Controllers
{
    public class FilmPossedesController : Controller
    {
        private readonly MovieToGoDbContext _context;

        static HttpClient client = new HttpClient();
        private readonly UserManager<IdentityUser> _userManager;

        public FilmPossedesController(MovieToGoDbContext context, UserManager<IdentityUser> userManager)
        {
            if (client.BaseAddress != null)
            {
                client = new HttpClient();
            }
            client.BaseAddress = new Uri("http://localhost:5001/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            _userManager = userManager;
            _context = context;
        }

        ///get all film
        static async Task<Film[]> GetFilmsAsync()
        {
            Film[] product = null;
            HttpResponseMessage response = await client.GetAsync("api/Films");
            if (response.IsSuccessStatusCode)
            {
                product = await response.Content.ReadAsAsync<Film[]>();
            }
            return product;
        }

        ///get all film posede
        static async Task<FilmPossede[]> GetFilmPossedeAsync()
        {
            FilmPossede[] product = null;
            HttpResponseMessage response = await client.GetAsync("api/FilmPossedes");
            if (response.IsSuccessStatusCode)
            {
                product = await response.Content.ReadAsAsync<FilmPossede[]>();
            }
            return product;
        }

        static async Task<Film> GetFilmAsync(string path)
        {
            Film product = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                product = await response.Content.ReadAsAsync<Film>();
            }
            return product;
        }

        // GET: FilmPossedes
        public async Task<IActionResult> Index()
        {

            var userID = _userManager.GetUserId(HttpContext.User);
            //var movieToGoDbContext = _context.FilmPossede.Include(f => f.IdFilmNavigation).Include(f => f.IdUserNavigation);
            //var asyncFilms = await GetFilmsAsync();
            //var movieToGoDbContext = _context.FilmPossede.Where(f => f.IdUser == userID);
            var filmPoss = GetFilmPossedeAsync().Result.AsQueryable().Where(f => f.IdUser == userID).ToList();

            List<Film> film = new List<Film>();

            foreach (var item in filmPoss)
            {
                //item.IdFilm;
                film.Add(GetFilmAsync("api/Films/" + item.IdFilm).Result);
            }


           
            //Film film = null;
            //string pathAndId = "api/Films/" + 1;
            //film = await GetFilmAsync(pathAndId);
            return View(film);
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
            ViewData["IdUser"] = new SelectList(_context.Set<Users>(), "Id", "Id");
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
            ViewData["IdUser"] = new SelectList(_context.Set<Users>(), "Id", "Id", filmPossede.IdUser);
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
            ViewData["IdUser"] = new SelectList(_context.Set<Users>(), "Id", "Id", filmPossede.IdUser);
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
            ViewData["IdUser"] = new SelectList(_context.Set<Users>(), "Id", "Id", filmPossede.IdUser);
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

        public async Task<IActionResult> WatchAsync(short id)
        {
            var userID = _userManager.GetUserId(HttpContext.User);
            var filmPoss = GetFilmPossedeAsync().Result.AsQueryable().Where(f => f.IdUser == userID).ToList();

            List<Film> film = new List<Film>();

            foreach (var item in filmPoss)
            {
                film.Add(GetFilmAsync("api/Films/" + item.IdFilm).Result);
            }

            ViewBag.pathFile = "http://localhost:5001/video/" + id + ".mp4";
            ViewBag.idFilm = id;
            return View(film);
        }
    }
}
