using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieToGoFilm.Models;
using PagedList;

namespace MovieToGoFilm.Controllers
{
    public class FilmController : Controller
    {
        private readonly MovieToGoContext _context;

        public FilmController(MovieToGoContext context)
        {
            _context = context;
        }
        

        // GET: Film
        public ViewResult Index(string searchOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = searchOrder;
            ViewBag.NomSearch= String.IsNullOrEmpty(searchOrder) ? "name_desc" : "";
            ViewBag.DateSearch = searchOrder == "Date" ? "date_desc" : "Date";
            ViewBag.DescSearch = searchOrder == "Description" ? "desc_desc" : "Description";
            ViewBag.DureeSearch = searchOrder == "Duree" ? "duree_desc" : "Duree";
            ViewBag.PrixSearch = searchOrder == "Prix" ? "prix_desc" : "Prix";
            ViewBag.FichierSearch = searchOrder == "Fichier" ? "fichier_desc" : "Fichier";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var films = from m in _context.Film
                         select m;
            if (!String.IsNullOrEmpty(searchString))
            {
                films = films.Where(s => s.Nom.Contains(searchString));
                
            }

            switch (searchOrder)
            {
                case "name_desc":
                    films = films.OrderByDescending(s => s.Nom);
                    break;
                case "date_desc":
                    films = films.OrderByDescending(s => s.DateDeSortie);
                    break;
                case "duree_desc":
                    films = films.OrderByDescending(s => s.Duree);
                    break;
                case "desc_desc":
                    //films = films.OrderByDescending(s => s.Description);
                    break;
                case "fichier_desc":
                    //films = films.OrderByDescending(s => s.Fichier);
                    break;
                case "prix_desc":
                    films = films.OrderByDescending(s => s.Prix);
                    break;
                default:
                    films = films.OrderByDescending(s => s.DateDeSortie);
                    break;
            }

            int pageSize = 99;
            int pageNumber = (page ?? 1);
            return View(films.ToPagedList(pageNumber, pageSize));

            // var movieToGoContext = _context.Film.Include(f => f.IdDistributeurNavigation).Include(f => f.IdLangueNavigation).Include(f => f.IdNationaliteNavigation).Include(f => f.IdSousTitreNavigation);
            //return View(await movieToGoContext.ToListAsync());
        }

        [HttpPost]
        public string Index(string searchString, bool notUsed)
        {
            return "From [HttpPost]Index : filter on " + searchString;
        }

        // GET: Film/Details/5
        public async Task<IActionResult> Details(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var film = await _context.Film
                .Include(f => f.IdDistributeurNavigation)
                .Include(f => f.IdLangueNavigation)
                .Include(f => f.IdNationaliteNavigation)
                .Include(f => f.IdSousTitreNavigation)
                .FirstOrDefaultAsync(m => m.IdFilm == id);
            if (film == null)
            {
                return NotFound();
            }
            //Affiche les commentaires en fonction du film(id)
            ViewBag.IdFilm = film.IdFilm;
            return View(film);
        }


        // GET: Film/Create
        public IActionResult Create()
        {
            ViewData["IdDistributeur"] = new SelectList(_context.Distributeur, "IdDistributeur", "Nom");
            ViewData["IdLangue"] = new SelectList(_context.Langue, "IdLangue", "Nom");
            ViewData["IdNationalite"] = new SelectList(_context.Nationalite, "IdNationalite", "Nom");
            ViewData["IdSousTitre"] = new SelectList(_context.SousTitre, "IdSousTitre", "Nom");
            return View();
        }

        // POST: Film/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdFilm,IdDistributeur,IdSousTitre,IdLangue,IdNationalite,Nom,DateDeSortie,Description,Duree,Prix,Fichier")] Film film)
        {
            if (ModelState.IsValid)
            {
                _context.Add(film);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdDistributeur"] = new SelectList(_context.Distributeur, "IdDistributeur", "Nom", film.IdDistributeur);
            ViewData["IdLangue"] = new SelectList(_context.Langue, "IdLangue", "Nom", film.IdLangue);
            ViewData["IdNationalite"] = new SelectList(_context.Nationalite, "IdNationalite", "Nom", film.IdNationalite);
            ViewData["IdSousTitre"] = new SelectList(_context.SousTitre, "IdSousTitre", "Nom", film.IdSousTitre);
            return View(film);
        }

        // GET: Film/Edit/5
        public async Task<IActionResult> Edit(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var film = await _context.Film.FindAsync(id);
            if (film == null)
            {
                return NotFound();
            }
            ViewData["IdDistributeur"] = new SelectList(_context.Distributeur, "IdDistributeur", "Nom", film.IdDistributeur);
            ViewData["IdLangue"] = new SelectList(_context.Langue, "IdLangue", "Nom", film.IdLangue);
            ViewData["IdNationalite"] = new SelectList(_context.Nationalite, "IdNationalite", "Nom", film.IdNationalite);
            ViewData["IdSousTitre"] = new SelectList(_context.SousTitre, "IdSousTitre", "Nom", film.IdSousTitre);
            
            return View(film);
        }

        // POST: Film/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(short id, [Bind("IdFilm,IdDistributeur,IdSousTitre,IdLangue,IdNationalite,Nom,DateDeSortie,Description,Duree,Prix,Fichier")] Film film)
        {
            if (id != film.IdFilm)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(film);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FilmExists(film.IdFilm))
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
            ViewData["IdDistributeur"] = new SelectList(_context.Distributeur, "IdDistributeur", "Nom", film.IdDistributeur);
            ViewData["IdLangue"] = new SelectList(_context.Langue, "IdLangue", "Nom", film.IdLangue);
            ViewData["IdNationalite"] = new SelectList(_context.Nationalite, "IdNationalite", "Nom", film.IdNationalite);
            ViewData["IdSousTitre"] = new SelectList(_context.SousTitre, "IdSousTitre", "Nom", film.IdSousTitre);
            return View(film);
        }

        // GET: Film/Delete/5
        public async Task<IActionResult> Delete(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var film = await _context.Film
                .Include(f => f.IdDistributeurNavigation)
                .Include(f => f.IdLangueNavigation)
                .Include(f => f.IdNationaliteNavigation)
                .Include(f => f.IdSousTitreNavigation)
                .FirstOrDefaultAsync(m => m.IdFilm == id);
            if (film == null)
            {
                return NotFound();
            }

            return View(film);
        }

        // POST: Film/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(short id)
        {
            var film = await _context.Film.FindAsync(id);
            _context.Film.Remove(film);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FilmExists(short id)
        {
            return _context.Film.Any(e => e.IdFilm == id);
        }
    }
}
