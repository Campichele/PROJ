using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieToGoFilm.Models;
using Stripe;

namespace MovieToGoFilm.Controllers
{
    public class AcheterController : Controller
    {
        private readonly MovieToGoContext _context;

        public AcheterController(MovieToGoContext context)
        {
            _context = context;
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
            var price = film.Prix*100;
            var name = film.Nom;

            var customer = customers.Create(new CustomerCreateOptions
            {
                Email = stripeEmail,
                Source = stripeToken
            });



            var charge = charges.Create(new ChargeCreateOptions
            {
                Amount = Convert.ToInt32(price) ,
                Description = name,
                Currency = "CHF",
                Customer = customer.Id
            });
            //Confirmation validation du payement 
            if (charge.Status == "succeeded")
            {
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
