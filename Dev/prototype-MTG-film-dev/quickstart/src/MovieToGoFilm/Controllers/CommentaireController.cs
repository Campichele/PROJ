using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieToGoFilm.Models;

namespace MovieToGoFilm.Controllers
{
    public class CommentaireController : Controller
    {
        private readonly MovieToGoContext _context;

        public CommentaireController(MovieToGoContext context)
        {
            _context = context;
        }

        // GET: Commentaire old
        //public async Task<IActionResult> Index(string searchID)
        //{
        //    var commentaires = from m in _context.Commentaire
        //                       select m;

        //    if (!String.IsNullOrEmpty(searchID))
        //    {

        //        commentaires = commentaires.Where(s => s.IdFilm == Convert.ToInt32(searchID));
        //    }

        //    return View(await commentaires.ToListAsync());

        //    //var movieToGoContext = _context.Commentaire.Include(c => c.IdFilmNavigation).Include(c => c.IdUserNavigation);
        //    //return View(await movieToGoContext.ToListAsync());
        //}


        // GET: Commentaire
        public async Task<IActionResult> Index(short searchID)
        {
            var commentaires = from m in _context.Commentaire
                               select m;

            commentaires = commentaires.Where(s => s.IdFilm == searchID);

            return View(await commentaires.ToListAsync());

            //var movieToGoContext = _context.Commentaire.Include(c => c.IdFilmNavigation).Include(c => c.IdUserNavigation);
            //return View(await movieToGoContext.ToListAsync());
        }

 

        // GET: Commentaire/Details/5
        public async Task<IActionResult> Details(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var commentaire = await _context.Commentaire
                .Include(c => c.IdFilmNavigation)
                .Include(c => c.IdUserNavigation)
                .FirstOrDefaultAsync(m => m.IdCommentaire == id);
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
                _context.Add(commentaire);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", new { searchID = commentaire.IdFilm });
            }
            ViewData["IdFilm"] = new SelectList(_context.Film, "IdFilm", "Nom", commentaire.IdFilm);
            ViewData["IdUser"] = new SelectList(_context.Utilisateur, "IdUser", "Email", commentaire.IdUser);

            return View(commentaire);
        }

       

        // GET: Commentaire/Edit/5
        //public async Task<IActionResult> Edit(short? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var commentaire = await _context.Commentaire.FindAsync(id);
        //    if (commentaire == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["IdFilm"] = new SelectList(_context.Film, "IdFilm", "Nom", commentaire.IdFilm);
        //    ViewData["IdUser"] = new SelectList(_context.Utilisateur, "IdUser", "Email", commentaire.IdUser);
        //    return View(commentaire);
        //}

        // POST: Commentaire/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(short id, [Bind("IdCommentaire,IdUser,IdFilm,Commentaire1,Statut")] Commentaire commentaire)
        //{
        //    if (id != commentaire.IdCommentaire)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(commentaire);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!CommentaireExists(commentaire.IdCommentaire))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["IdFilm"] = new SelectList(_context.Film, "IdFilm", "Nom", commentaire.IdFilm);
        //    ViewData["IdUser"] = new SelectList(_context.Utilisateur, "IdUser", "Email", commentaire.IdUser);
        //    return View(commentaire);
        //}

        // GET: Commentaire/Delete/5
        public async Task<IActionResult> Delete(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var commentaire = await _context.Commentaire
                .Include(c => c.IdFilmNavigation)
                .Include(c => c.IdUserNavigation)
                .FirstOrDefaultAsync(m => m.IdCommentaire == id);
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
            var commentaire = await _context.Commentaire.FindAsync(id);
            _context.Commentaire.Remove(commentaire);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", new { searchID = commentaire.IdFilm });
            //return RedirectToAction("Index", new { commentaire.IdFilmNavigation.IdFilm});
        }

        private bool CommentaireExists(short id)
        {
            return _context.Commentaire.Any(e => e.IdCommentaire == id);
        }
    }
}
