using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieToGo.Models;
using MovieToGo.ApiFunctions;
using System.Net.Http;
using Microsoft.AspNetCore.Identity;

namespace MovieToGo.Controllers
{
    public class NotesController : Controller
    {
        private readonly MovieToGoDbContext _context;
        static HttpClient client = new HttpClient();
        private readonly UserManager<IdentityUser> _userManager;
        public NotesController(MovieToGoDbContext context, UserManager<IdentityUser> userManager)
        {
            client = ConfigureHttpClient.configureHttpClient(client);
            _userManager = userManager;
            _context = context;
        }

        // GET: Notes
        public async Task<IActionResult> Index(short? id)
        {
            //var movieToGoDbContext = _context.Note.Include(n => n.IdFilmNavigation).Include(n => n.IdUserNavigation);
            var notes = ApiNotes.GetNoteAsync(client, id);

            return View(notes.Result.ToList());
        }

        // GET: Notes/Details/5
        public async Task<IActionResult> Details(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var note = await _context.Note
                .Include(n => n.IdFilmNavigation)
                .Include(n => n.IdUserNavigation)
                .FirstOrDefaultAsync(m => m.IdNote == id);
            if (note == null)
            {
                return NotFound();
            }

            return View(note);
        }

        // GET: Notes/Create
        public IActionResult Create(short? SearchID)
        {
            var idfilm = SearchID;
            if (idfilm == null)
            {
                return NotFound();
            }
            //ViewData["IdFilm"] = new SelectList(_context.Film, "IdFilm", "Nom");
            //ViewData["IdUser"] = new SelectList(_context.Set<Users>(), "Id", "Id");
            var userIDFilm = _userManager.GetUserId(HttpContext.User);
            ViewBag.User = userIDFilm;
            ViewBag.Film = idfilm;
            return View();
        }

        // POST: Notes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdNote,IdUser,IdFilm,Note1")] Note note)
        {
            if (ModelState.IsValid)
            {
                _context.Add(note);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdFilm"] = new SelectList(_context.Film, "IdFilm", "Nom", note.IdFilm);
            ViewData["IdUser"] = new SelectList(_context.Set<Users>(), "Id", "Id", note.IdUser);
            return View(note);
        }

        // GET: Notes/Edit/5
        public async Task<IActionResult> Edit(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var note = await _context.Note.FindAsync(id);
            if (note == null)
            {
                return NotFound();
            }
            ViewData["IdFilm"] = new SelectList(_context.Film, "IdFilm", "Nom", note.IdFilm);
            ViewData["IdUser"] = new SelectList(_context.Set<Users>(), "Id", "Id", note.IdUser);
            return View(note);
        }

        // POST: Notes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(short id, [Bind("IdNote,IdUser,IdFilm,Note1")] Note note)
        {
            if (id != note.IdNote)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(note);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NoteExists(note.IdNote))
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
            ViewData["IdFilm"] = new SelectList(_context.Film, "IdFilm", "Nom", note.IdFilm);
            ViewData["IdUser"] = new SelectList(_context.Set<Users>(), "Id", "Id", note.IdUser);
            return View(note);
        }

        // GET: Notes/Delete/5
        public async Task<IActionResult> Delete(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var note = await _context.Note
                .Include(n => n.IdFilmNavigation)
                .Include(n => n.IdUserNavigation)
                .FirstOrDefaultAsync(m => m.IdNote == id);
            if (note == null)
            {
                return NotFound();
            }

            return View(note);
        }

        // POST: Notes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(short id)
        {
            var note = await _context.Note.FindAsync(id);
            _context.Note.Remove(note);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NoteExists(short id)
        {
            return _context.Note.Any(e => e.IdNote == id);
        }
    }
}
