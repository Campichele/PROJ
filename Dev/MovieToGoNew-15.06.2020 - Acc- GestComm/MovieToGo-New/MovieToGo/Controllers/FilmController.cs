﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieToGo.Models;
using System.Net;
using System.Net.Http;
using MovieToGo.ApiFunctions;
using static System.Net.WebRequestMethods;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;
using X.PagedList;

namespace MovieToGoFilm.Controllers
{
    [Authorize(Roles ="Admin, User")]
    public class FilmController : Controller
    {
        private readonly MovieToGoDbContext _context;

        static HttpClient client = new HttpClient();

        public FilmController(MovieToGoDbContext context)
        {
            client = ConfigureHttpClient.configureHttpClient(client);

            _context = context;
        }

        // GET: Film
        [AllowAnonymous]
        public ViewResult Index(string searchOrder, string currentFilter, string searchString, string searchInt, string searchPriceUp, int? page)
        {
            
            
            int pageSize = 5;
            int pageNumber = (page ?? 1);

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            if (searchInt != null)
            {
                page = 1;
            }
            else
            {
                searchInt = currentFilter;
            }

            if (searchPriceUp != null)
            {
                page = 1;
            }
            else
            {
                searchPriceUp = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var films = ApiFilms.GetFilmsAsync(client).Result.AsQueryable();
            films = films.OrderByDescending(s => s.DateDeSortie);

            if (!String.IsNullOrEmpty(searchString))
            {
                searchString = searchString.ToLower();
                films = films.Where(s => s.Nom.ToLower().Contains(searchString));
                //var film = films.FirstOrDefault(films => films.Nom.Contains(searchString));
            }

            if(!String.IsNullOrEmpty(searchInt))
            {
                if (IsNum(searchInt))
                {
                    int sInt = Convert.ToInt32(searchInt);
                    films = films.Where(s => Convert.ToInt32(s.Duree) <= sInt);
                }
                //films = films.Where(s => s.Duree.ToString().Contains(searchInt));
            }

            if (!String.IsNullOrEmpty(searchPriceUp))
            {
                if (IsNum(searchPriceUp))
                {
                    int sPriceUp = Convert.ToInt32(searchPriceUp);
                    films = films.Where(s => Convert.ToInt32(s.Prix) <= sPriceUp);
                }
                //films = films.Where(s => s.Duree.ToString().Contains(searchInt));
            }

            return View(films.ToPagedList(pageNumber, pageSize));

        }

        private bool IsNum(string nombre)
        {
            try
            {
                int.Parse(nombre);
                return true;
            }
            catch (Exception)
            {
                return false;
                
            }
        }

        [HttpPost]
        [AllowAnonymous]
        public string Index(string searchString, bool notUsed)
        {
            return "From [HttpPost]Index : filter on " + searchString;
        }

        // GET: Film/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Details(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var film = await _context.Film
            //    .Include(f => f.IdDistributeurNavigation)
            //    .Include(f => f.IdLangueNavigation)
            //    .Include(f => f.IdNationaliteNavigation)
            //    .Include(f => f.IdSousTitreNavigation)
            //    .FirstOrDefaultAsync(m => m.IdFilm == id);
            var film = await ApiFilms.GetFilmAsync(client, id);
            if (film == null)
            {
                return NotFound();
            }
            //Affiche les commentaires en fonction du film(id)
            ViewBag.IdFilm = film.IdFilm;
            return View(film);
        }


        // GET: Film/Create
        [Authorize(Roles ="Admin")]
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
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([Bind("IdFilm,IdDistributeur,IdSousTitre,IdLangue,IdNationalite,Nom,DateDeSortie,Description,Duree,Prix,Fichier")] Film film)
        {
            if (ModelState.IsValid)
            {

                Film newFilm = await ApiFilms.AddFilm(film);
                //_context.Add(film);
                //await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdDistributeur"] = new SelectList(_context.Distributeur, "IdDistributeur", "Nom", film.IdDistributeur);
            ViewData["IdLangue"] = new SelectList(_context.Langue, "IdLangue", "Nom", film.IdLangue);
            ViewData["IdNationalite"] = new SelectList(_context.Nationalite, "IdNationalite", "Nom", film.IdNationalite);
            ViewData["IdSousTitre"] = new SelectList(_context.SousTitre, "IdSousTitre", "Nom", film.IdSousTitre);
            return View(film);
        }

        // GET: Film/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var film = await _context.Film.FindAsync(id);
            var film = await ApiFilms.GetFilmAsync(client, id);
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
        [Authorize(Roles = "Admin")]
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
                    //using (var httpClient = new HttpClient())
                    //{
                    //    var request = new HttpRequestMessage
                    //    {
                    //        RequestUri = new Uri(ConfigureHttpClient.apiUrl + "api/Films/" + id),
                    //        Method = new HttpMethod("Patch"),
                    //        Content = new StringContent("[{ \"op\": \"replace\", \"path\": \"Name\", \"value\": \"" + reservation.Name + "\"},{ \"op\": \"replace\", \"path\":\"StartLocation\", \"value\": \"" + reservation.StartLocation + "\"}]", Encoding.UTF8, "application/json")
                    //    };

                    //    var response = await httpClient.SendAsync(request);
                    //}
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
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var film = await _context.Film
            //    .Include(f => f.IdDistributeurNavigation)
            //    .Include(f => f.IdLangueNavigation)
            //    .Include(f => f.IdNationaliteNavigation)
            //    .Include(f => f.IdSousTitreNavigation)
            //    .FirstOrDefaultAsync(m => m.IdFilm == id);

            var film = await ApiFilms.GetFilmAsync(client, id);

            if (film == null)
            {
                return NotFound();
            }

            return View(film);
        }

        // POST: Film/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(short id)
        {
            var film = await ApiFilms.DeleteFilm(id);
            //context.Film.Remove(film);
            //await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FilmExists(short id)
        {
            return _context.Film.Any(e => e.IdFilm == id);
        }

        ///Stripe
        public async Task<IActionResult> Acheter(short? IdFilm)
        {
            //var price = (from p in _context.Film select new Film() { Prix = p.Prix });
            //price = price.Where(s => s.IdFilm == IdFilm);
            //ViewBag.price = price;

            //ViewBag.IdFilm = IdFilm;

            //var film2 = await _context.Film.FindAsync(IdFilm);

            //string Id =  "" + IdFilm;

            var film = await ApiFilms.GetFilmAsync(client, IdFilm);


            decimal price = film.Prix;
            string name = film.Nom;
            //passer l'id fu film au controller
            ViewBag.price = price * 100;
            ViewBag.Displayprice = price;
            ViewBag.id = IdFilm;
            ViewBag.name = name;
            return View();
        }

    }
}