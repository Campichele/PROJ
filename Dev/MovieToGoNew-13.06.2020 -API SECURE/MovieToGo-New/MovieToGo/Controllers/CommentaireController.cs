using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
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

        public CommentaireController(MovieToGoDbContext context)
        {

            client = ConfigureHttpClient.configureHttpClient(client);

            _context = context;
        }

       
        // GET: Commentaire
        public IActionResult Index(short searchID)
        {
            //var commentaires = from m in _context.Commentaire
            //select m;

            var commentairesAsync = ApiCommentaires.GetCommentsAsync(client);
            IEnumerable<Commentaire> commentaires = commentairesAsync.Result;

            commentaires = commentaires.Where(s => s.IdFilm == searchID);

            return View(commentaires.ToList());

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



            ViewBag.IdFilmNavigation = commentaire.IdFilmNavigation.IdFilm;

            return View(commentaire);
        }

        // GET: Commentaire/Create
        public IActionResult Create()
        {
            ViewData["IdFilm"] = new SelectList(_context.Film, "IdFilm", "Nom");
            ViewData["IdUser"] = new SelectList(_context.Utilisateur, "IdUser", "Email");
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
                Commentaire newCommentaire = await ApiCommentaires.AddComment(commentaire);
                return RedirectToAction("Index", new { searchID = newCommentaire.IdFilm });
            }
            ViewData["IdFilm"] = new SelectList(await ApiFilms.GetFilmsAsync(client), "IdFilm", "Nom", commentaire.IdFilm);
            ViewData["IdUser"] = new SelectList(_context.Utilisateur, "IdUser", "Email", commentaire.IdUser);

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
