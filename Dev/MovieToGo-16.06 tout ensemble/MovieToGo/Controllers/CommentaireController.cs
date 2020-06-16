using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieToGo.ApiFunctions;
using MovieToGo.Models;

namespace MovieToGoFilm.Controllers
{
    public class CommentaireController : Controller
    {
        private readonly MovieToGoDbContext _context;

        static HttpClient client = new HttpClient();
        private readonly UserManager<IdentityUser> _userManager;

        public CommentaireController(MovieToGoDbContext context, UserManager<IdentityUser> userManager)
        {

            client = ConfigureHttpClient.configureHttpClient(client);
            _userManager = userManager;
            _context = context;
            
        }

       
        // GET: Commentaire
        public IActionResult Index(short searchID)
        {
            //var commentaires = from m in _context.Commentaire
            //select m;

            var commentairesAsync = ApiCommentaires.GetCommentsAsync(client);

            IEnumerable<Commentaire> commentaires = commentairesAsync.Result;
            List<Commentaire> commentairesValide = new List<Commentaire>();

            commentaires = commentaires.Where(s => s.IdFilm == searchID);

            foreach (var item in commentaires)
            {
                if (item.Statut)
                {
                    commentairesValide.Add(item);
                }
            }
            return View(commentairesValide);

        }

        public IActionResult ListComments()
        {
            var commentairesAsync = ApiCommentaires.GetCommentsAsync(client);
            IEnumerable<Commentaire> commentaires = commentairesAsync.Result;
            List<Commentaire> commentairesNotValide = new List<Commentaire>();

            foreach (var item in commentaires)
            {
                if (item.Statut == false)
                {
                    commentairesNotValide.Add(item);
                }
            }
            return View(commentairesNotValide);
        }

        // GET: Commentaire/Details/5
        public IActionResult Details(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            
            var commentaireAsync = ApiCommentaires.GetCommentAsync(client, id);

            var commentaire = commentaireAsync.Result;

            if (commentaire == null)
            {
                return NotFound();
            }



            ViewBag.IdFilmNavigation = commentaire.IdFilmNavigation;

            return View(commentaire);
        }

        //EDIT ////////////////////////////////////////////////////////////////////////////
        // GET: Comment/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var film = await _context.Film.FindAsync(id);
            var commentaire = await ApiCommentaires.GetCommentAsync(client, id);
            if (commentaire == null)
            {
                return NotFound();
            }
            ViewData["IdFilm"] = new SelectList(_context.Film, "IdFilm", "Nom");
            ViewData["ID"] = new SelectList(commentaire.IdUser, "ID", "Email");

            return View(commentaire);
        }

        // POST: Comment/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(short id)
        {
                var oldCom = await ApiCommentaires.GetCommentAsync(client, id);

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


                        oldCom.Statut = true;

                        _context.Update(oldCom);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!CommentaireExists(oldCom.IdCommentaire))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                    return RedirectToAction(nameof(ListComments));
                }

                ViewData["IdFilm"] = new SelectList(await ApiFilms.GetFilmsAsync(client), "IdFilm", "Nom", oldCom.IdFilm);
                ViewData["IdUser"] = new SelectList(oldCom.IdUser, "IdUser", "Email", oldCom.IdUser);
                return RedirectToAction(nameof(ListComments));
        }

        // EDIT //////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        // GET: Commentaire/Create
        public IActionResult Create()
        {
            var userIDFilm = _userManager.GetUserId(HttpContext.User);
            ViewData["IdFilm"] = new SelectList(_context.Film, "IdFilm", "Nom");
            ViewData["ID"] = new SelectList(userIDFilm, "ID", "Email");
            ViewBag.iduser = "fake";
            return View();
        }

        // POST: Commentaire/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCommentaire,IdUser,IdFilm,Commentaire1,Statut")] Commentaire commentaire)
        {


            if (ModelState.IsValid)
            {
                // _context.Add(commentaire);
                //await _context.SaveChangesAsync();
                commentaire.IdUser = _userManager.GetUserId(HttpContext.User);
                Commentaire newCommentaire = await ApiCommentaires.AddComment(commentaire);
                return RedirectToAction("Index", new { searchID = newCommentaire.IdFilm });
            }
            ViewData["IdFilm"] = new SelectList(await ApiFilms.GetFilmsAsync(client), "IdFilm", "Nom", commentaire.IdFilm);
            ViewData["IdUser"] = new SelectList(_userManager.GetUserId(HttpContext.User), "IdUser", "Email", commentaire.IdUser);

            return View(commentaire);
        }

        // GET: Commentaire/Delete/5
        public async Task<IActionResult> Delete(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var commentaire = await _context.Commentaire
            //    .Include(c => c.IdFilmNavigation)
            //    .Include(c => c.IdUserNavigation)
            //    .FirstOrDefaultAsync(m => m.IdCommentaire == id);

            var commentaire = await ApiCommentaires.GetCommentAsync(client, id);

            if (commentaire == null)
            {
                return NotFound();
            }

            ViewBag.IdFilmNavigation = commentaire.IdFilmNavigation.IdFilm;

            return View(commentaire);
        }

        // POST: Commentaire/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(short id)
        {
            var commentaire = await ApiCommentaires.DeleteComment(id);

            return RedirectToAction("Index", new { searchID = commentaire.IdFilm });
        }

        private bool CommentaireExists(short id)
        {
            return _context.Commentaire.Any(e => e.IdCommentaire == id);
        }
    }
}
