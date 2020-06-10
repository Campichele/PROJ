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
using MovieToGo.ApiFunctions;

namespace MovieToGo.Controllers
{
    public class HomeController : Controller
    {
        //connection  à l'API
        static HttpClient client = new HttpClient();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            client = ConfigureHttpClient.configureHttpClient(client);

            _logger = logger;
        }


        public async Task<ViewResult> IndexAsync()
        {
            //declaration
            int idMax;
            var rand = new Random();
            Film film = null;
            ///randomizer
            var asyncFilms = await ApiFilms.GetFilmsAsync(client);
            if (asyncFilms.FirstOrDefault() != null)
            {
                idMax = asyncFilms.OrderByDescending(p => p.IdFilm).FirstOrDefault().IdFilm;
                //boucle while qui regenere un random si l'id n'existe pas dans la BD
                while (film == null)
                {
                    var randId = rand.Next(1, idMax + 1);
                    string pathAndId = "api/Films/" + randId;
                    film = await ApiFilms.GetFilmAsync(client, Convert.ToInt16(randId));
                }
                ViewBag.idFilm = film.IdFilm;
            }
            else
            {
                ViewBag.idFilm = 1;
            }

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
