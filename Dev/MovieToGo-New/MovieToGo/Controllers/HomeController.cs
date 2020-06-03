using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieToGo.Models;

namespace MovieToGo.Controllers
{
    public class HomeController : Controller
    {
        static HttpClient client = new HttpClient();

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            if (client.BaseAddress != null)
            {
                client = new HttpClient();
            }
            client.BaseAddress = new Uri("http://localhost:5001/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            _logger = logger;
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
        ///get film by id 
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


        public async Task<ViewResult> IndexAsync()
        {
            int idMax;
            var rand = new Random();
            Film film = null;
            ///randomizer
            var asyncFilms = await GetFilmsAsync();
            idMax = asyncFilms.OrderByDescending(p => p.IdFilm).FirstOrDefault().IdFilm;
            
            while (film == null)
            {
                var randId = rand.Next(1, idMax + 1);
                string pathAndId = "api/Films/" + randId;
                film = await GetFilmAsync(pathAndId);
            }
            ViewBag.idFilm = film.IdFilm;
            return View(film);
        }



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
