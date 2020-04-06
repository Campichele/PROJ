using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Stripe;
using StripeMovieToGo.Models;

namespace StripeMovieToGo.Controllers
{
    public class HomeController : Controller
    {
      
        public IActionResult Index()
        {
            return View();
        }
        

        public IActionResult Privacy()
        {
            return View();
        }

        //Il utilise l'adresse e-mail et le jeton de carte de la requête POST pour créer un client Stripe
        public IActionResult Charge(string stripeEmail, string stripeToken)
        {
            var customers = new CustomerService();
            var charges = new ChargeService();

            var customer = customers.Create(new CustomerCreateOptions
            {
                Email = stripeEmail,
                Source = stripeToken
            });

            //Associe la transaction au client 
            var charge = charges.Create(new ChargeCreateOptions
            {
                Amount = 800,
                Description = "Achat du film 300",
                Currency = "CHF",
                Customer = customer.Id,
                Metadata = new Dictionary<string, string>()
                {
                    {"Film","300"},
                    {"Postcode","1814"},
                }
            }); 

            //Confirmation validation du payement 
            if (charge.Status == "succeeded")
            {
                string BalanceTransactionId = charge.BalanceTransactionId;
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
