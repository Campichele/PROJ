using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
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

        static HttpClient client = new HttpClient();

        private readonly UserManager<IdentityUser> _userManager;


        public AcheterController(MovieToGoDbContext context, UserManager<IdentityUser> userManager)
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

        public async Task<FilmPossede> AddFilm(FilmPossede film)
        {
            FilmPossede responseFilm;
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(film), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync("http://localhost:5001/api/FilmPossedes", content))
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

        public async Task<IActionResult> ChargeAsync(string stripeEmail, string stripeToken, short searchID, string userID)
        {
            var customers = new CustomerService();
            var charges = new ChargeService();
            ///test
            ///

            //var price = (from p in _context.Film select new Film(){Prix= p.Prix});
            //price = price.Where(s => s.IdFilm == searchID);

            //decimal test = ViewBag.price;
            var user = await _context.Film.FindAsync(userID);
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
                var userIDFilm = _userManager.GetUserId(HttpContext.User);
                FilmPossede newAchat = new FilmPossede();
                newAchat.IdFilm = film.IdFilm;
                newAchat.IdUser = userIDFilm;
                await AddFilm(newAchat);
                string BalanceTransactionId = charge.BalanceTransactionId;
                ViewBag.nom = film.Nom;
                ViewBag.prix = film.Prix;
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
