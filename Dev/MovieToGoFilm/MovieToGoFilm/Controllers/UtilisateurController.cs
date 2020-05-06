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
    public class UtilisateurController : Controller
    {
        private readonly MovieToGoContext _context;

        public UtilisateurController(MovieToGoContext context)
        {
            _context = context;
        }

        // GET: Utilisateur
        public async Task<IActionResult> Index()
        {
            var movieToGoContext = _context.Utilisateur.Include(u => u.IdDoitNavigation);
            return View(await movieToGoContext.ToListAsync());
        }

        // GET: Utilisateur/Details/5
        public async Task<IActionResult> Details(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var utilisateur = await _context.Utilisateur
                .Include(u => u.IdDoitNavigation)
                .FirstOrDefaultAsync(m => m.IdUser == id);
            if (utilisateur == null)
            {
                return NotFound();
            }

            return View(utilisateur);
        }

        // GET: Utilisateur/Create
        public IActionResult Create()
        {
            ViewData["IdDoit"] = new SelectList(_context.Droit, "IdDoit", "Nom");
            return View();
        }

        // POST: Utilisateur/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdUser,IdDoit,Nom,Prenom,Email,Password,Statut,Pseudo")] Utilisateur utilisateur)
        {
            if (ModelState.IsValid)
            {
                _context.Add(utilisateur);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdDoit"] = new SelectList(_context.Droit, "IdDoit", "Nom", utilisateur.IdDoit);
            return View(utilisateur);
        }

        // GET: Utilisateur/Edit/5
        public async Task<IActionResult> Edit(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var utilisateur = await _context.Utilisateur.FindAsync(id);
            if (utilisateur == null)
            {
                return NotFound();
            }
            ViewData["IdDoit"] = new SelectList(_context.Droit, "IdDoit", "Nom", utilisateur.IdDoit);
            return View(utilisateur);
        }

        // POST: Utilisateur/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(short id, [Bind("IdUser,IdDoit,Nom,Prenom,Email,Password,Statut,Pseudo")] Utilisateur utilisateur)
        {
            if (id != utilisateur.IdUser)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(utilisateur);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UtilisateurExists(utilisateur.IdUser))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdDoit"] = new SelectList(_context.Droit, "IdDoit", "Nom", utilisateur.IdDoit);
            return View(utilisateur);
        }

        // GET: Utilisateur/Delete/5
        public async Task<IActionResult> Delete(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var utilisateur = await _context.Utilisateur
                .Include(u => u.IdDoitNavigation)
                .FirstOrDefaultAsync(m => m.IdUser == id);
            if (utilisateur == null)
            {
                return NotFound();
            }

            return View(utilisateur);
        }

        // POST: Utilisateur/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(short id)
        {
            var utilisateur = await _context.Utilisateur.FindAsync(id);
            _context.Utilisateur.Remove(utilisateur);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UtilisateurExists(short id)
        {
            return _context.Utilisateur.Any(e => e.IdUser == id);
        }
    }
}
