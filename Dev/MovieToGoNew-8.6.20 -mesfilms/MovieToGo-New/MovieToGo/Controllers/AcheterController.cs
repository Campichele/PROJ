using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieToGo.Models;
using Newtonsoft.Json;
using Stripe;

namespace MovieToGoFilm.Controllers
{
    public class AcheterController : Controller
    {
        private readonly MovieToGoDbContext _context;

        public AcheterController(MovieToGoDbContext context)
        {
            _context = context;
        }

        public async Task<FilmPossede> AddFilm(FilmPossede film)
        {
            FilmPossede responseFilm;
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(film), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync("https://movietogoapi.azurewebsites.net/api/FilmPossedes", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    responseFilm = JsonConvert.DeserializeObject<FilmPossede>(apiResponse);
                }
            }
            return responseFilm;
        }



        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> ChargeAsync(string stripeEmail, string stripeToken, short searchID)
        {
            var customers = new CustomerService();
            var charges = new ChargeService();
            ///test
            ///

            //var price = (from p in _context.Film select new Film(){Prix= p.Prix});
            //price = price.Where(s => s.IdFilm == searchID);

            //decimal test = ViewBag.price;

            var film = await _context.Film.FindAsync(searchID);
            var price = film.Prix * 100;
            var name = film.Nom;
            var link = film.Fichier;
            ViewBag.link = link;

            var customer = customers.Create(new CustomerCreateOptions
            {
                Email = stripeEmail,
                Source = stripeToken
            });



            var charge = charges.Create(new ChargeCreateOptions
            {
                Amount = Convert.ToInt32(price),
                Description = name,
                Currency = "CHF",
                Customer = customer.Id
            });
            //Confirmation validation du payement 
            if (charge.Status == "succeeded")
            {
                FilmPossede newAchat = new FilmPossede();

                newAchat.IdFilm = 1;
                newAchat.IdUser = 1;
                await AddFilm(newAchat);
                string BalanceTransactionId = charge.BalanceTransactionId;
                ViewBag.nom = film.Nom;
                ViewBag.prix = film.Prix;
                ViewBag.newIdU = newAchat.IdUser;
                ViewBag.newId1 = newAchat.IdFilm;
                return View();
            }


            return View();
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
