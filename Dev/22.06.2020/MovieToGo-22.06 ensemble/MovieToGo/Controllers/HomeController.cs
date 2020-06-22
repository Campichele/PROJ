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
using MovieToGo.ViewModels;
using System.Security.Authentication;
using MimeKit;
using MailKit.Net.Smtp;
using PaulMiami.AspNetCore.Mvc.Recaptcha;

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

        public IActionResult Contact()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        [ValidateRecaptcha]
        [Obsolete]
        public IActionResult Contact(ContactViewModel model)
        {
            var captcha = ModelState["g-recaptcha-response"];
            if (captcha != null && captcha.Errors.Any())
            {
                this.ViewBag.Error = "The captacha is wrong";
                return View(model);
            }

            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Name", "from.website@example.com"));
            message.To.Add(new MailboxAddress("MovieToGoOnline@gmail.com"));
            message.Subject = $"[Contact from your website] { model.Subject }";

            var builder = new BodyBuilder
            {
                HtmlBody = $"<div><span style='font-weight: bold'>De</span> : {model.Name} </div><div><span style='font-weight: bold'>Mail</span> : {model.Email}</div><div style='margin-top: 30px'>{model.Message}</div>"
            };

            message.Body = builder.ToMessageBody();

            

            //Connect and authenticate with the SMTP server
            using (var client = new SmtpClient())
            {
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;
                client.SslProtocols = System.Security.Authentication.SslProtocols.Tls11;

                client.Connect("smtp.gmail.com", 587, false);

                client.AuthenticationMechanisms.Remove("XOAUTH2");
                client.Authenticate("MovieToGoOnline@gmail.com", "Etml$sig2");

                client.Send(message);
                client.Disconnect(true);
            }

            return View(model);
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
