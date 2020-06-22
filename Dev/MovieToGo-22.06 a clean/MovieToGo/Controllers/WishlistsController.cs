using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieToGo.ApiFunctions;
using MovieToGo.Models;
using Newtonsoft.Json;

namespace MovieToGo.Controllers
{
    public class WishlistsController : Controller
    {
        private readonly MovieToGoDbContext _context;

        static HttpClient client = new HttpClient();
        private readonly UserManager<IdentityUser> _userManager;
        public WishlistsController(MovieToGoDbContext context, UserManager<IdentityUser> userManager)
        {
            client = ConfigureHttpClient.configureHttpClient(client);
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
        static async Task<Wishlist[]> GetWishlistAsync()
        {
            Wishlist[] product = new Wishlist[] { };
            HttpResponseMessage response = await client.GetAsync("api/Wishlists");
            if (response.IsSuccessStatusCode)
            {
                product = await response.Content.ReadAsAsync<Wishlist[]>();
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

        

        // GET: Wishlists
        public async Task<IActionResult> Index()
        {
           
            var userID = _userManager.GetUserId(HttpContext.User);
            var wishlist = GetWishlistAsync().Result.AsQueryable().Where(f => f.IdUser == userID).ToList();

           

            List<Film> films = new List<Film>();

            foreach (var item in wishlist)
            {
                //item.IdFilm;
                films.Add(GetFilmAsync("api/Films/" + item.IdFilm).Result);
            }

            //Film film = null;
            //string pathAndId = "api/Films/" + 1;
            //film = await GetFilmAsync(pathAndId);
            return View(films);
        }

        // GET: Wishlists/Details/5
        public async Task<IActionResult> Details(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wishlist = await _context.Wishlist
                .Include(w => w.IdFilmNavigation)
                .Include(w => w.IdUserNavigation)
                .FirstOrDefaultAsync(m => m.IdWishlist == id);
            if (wishlist == null)
            {
                return NotFound();
            }

            return View(wishlist);
        }

        // GET: Wishlists/Create
        public IActionResult Create()
        {
            ViewData["IdFilm"] = new SelectList(_context.Film, "IdFilm", "Nom");
            ViewData["IdUser"] = new SelectList(_context.Set<Users>(), "Id", "Id");
            return View();
        }

        // POST: Wishlists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdWishlist,IdFilm,IdUser")] Wishlist wishlist)
        {
            if (ModelState.IsValid)
            {
                _context.Add(wishlist);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdFilm"] = new SelectList(_context.Film, "IdFilm", "Nom", wishlist.IdFilm);
            ViewData["IdUser"] = new SelectList(_context.Set<Users>(), "Id", "Id", wishlist.IdUser);
            return View(wishlist);
        }

        // GET: Wishlists/Edit/5
        public async Task<IActionResult> Edit(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wishlist = await _context.Wishlist.FindAsync(id);
            if (wishlist == null)
            {
                return NotFound();
            }
            ViewData["IdFilm"] = new SelectList(_context.Film, "IdFilm", "Nom", wishlist.IdFilm);
            ViewData["IdUser"] = new SelectList(_context.Set<Users>(), "Id", "Id", wishlist.IdUser);
            return View(wishlist);
        }

        // POST: Wishlists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(short id, [Bind("IdWishlist,IdFilm,IdUser")] Wishlist wishlist)
        {
            if (id != wishlist.IdWishlist)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(wishlist);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WishlistExists(wishlist.IdWishlist))
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
            ViewData["IdFilm"] = new SelectList(_context.Film, "IdFilm", "Nom", wishlist.IdFilm);
            ViewData["IdUser"] = new SelectList(_context.Set<Users>(), "Id", "Id", wishlist.IdUser);
            return View(wishlist);
        }

        // GET: Wishlists/Delete/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Delete(short? id)
        {
            var userID = _userManager.GetUserId(HttpContext.User);
          
            var wishlist = GetWishlistAsync().Result.AsQueryable().Where(f => f.IdUser == userID).ToList();
            
            List<Film> films = new List<Film>();

            var wishToDel = wishlist.Where(f => f.IdFilm == id).FirstOrDefault();

            var result = await client.DeleteAsync(ConfigureHttpClient.apiUrl + "api/Wishlists/" + wishToDel.IdWishlist);

            return RedirectToAction(nameof(Index));
        }

        // POST: Wishlists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(short id)
        {
            var wishlist = await ApiFilms.DeleteWishlist(id);
            return RedirectToAction(nameof(Index));
        }

        private bool WishlistExists(short id)
        {
            return _context.Wishlist.Any(e => e.IdWishlist == id);
        }
    }
}
