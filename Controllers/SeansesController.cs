using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Kino.Data;
using Kino.Models;

namespace Kino.Controllers
{
    public class SeansesController : Controller
    {
        private readonly KinoContext _context;

        public SeansesController(KinoContext context)
        {
            _context = context;
        }

        // GET: Seanses
        public async Task<IActionResult> Index()
        {

            var seanse = _context.Seanse.Include(f => f.Film).Include(k => k.kino);
              return View(await seanse.ToListAsync());
        }

        // GET: Seanses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Seanse == null)
            {
                return NotFound();
            }

            var seanse = await _context.Seanse
                .FirstOrDefaultAsync(m => m.Id_seansu == id);
            if (seanse == null)
            {
                return NotFound();
            }

            return View(seanse);
        }

        // GET: Seanses/Create
        public IActionResult Create()
        {
            PopulateFilmy();
            PopulateKina();
            return View();
        }

        private void PopulateFilmy()
        {
            var wybraneFilmy = from f in _context.Filmy orderby f.Tytul select f;
            var res = wybraneFilmy.AsNoTracking();
            ViewBag.FilmyID = new SelectList(res, "Id_filmu", "Tytul");
        }

        private void PopulateKina()
        {
            var wybraneKina = from k in _context.Kina orderby k.Nazwa_Kina select k;
            var res = wybraneKina.AsNoTracking();
            ViewBag.KinaID = new SelectList(res, "Id_kina", "Nazwa_Kina");
        }

        // POST: Seanses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_seansu,Start,Cena")] Seanse seanse, IFormCollection form)
        {

            string kinoValue = form["kino"].ToString();
            string filmValue = form["Film"].ToString();

            if (ModelState.IsValid)
            {

                Kina kino = null;
                if (kinoValue != "")
                {
                    var ee = _context.Kina.Where(e => e.Id_kina == int.Parse(kinoValue));
                    if (ee.Count() > 0) kino = ee.First();
                }

                Filmy film = null;
                if (filmValue != "")
                {
                    var ee = _context.Filmy.Where(e => e.Id_filmu == int.Parse(filmValue));
                    if (ee.Count() > 0) film = ee.First();
                }

                seanse.Film = film;
                seanse.kino = kino;

                _context.Add(seanse);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(seanse);
        }

        // GET: Seanses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Seanse == null)
            {
                return NotFound();
            }

            var seanse = await _context.Seanse.FindAsync(id);
            if (seanse == null)
            {
                return NotFound();
            }
            return View(seanse);
        }

        // POST: Seanses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_seansu,Start,Cena")] Seanse seanse)
        {
            if (id != seanse.Id_seansu)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(seanse);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SeanseExists(seanse.Id_seansu))
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
            return View(seanse);
        }

        // GET: Seanses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Seanse == null)
            {
                return NotFound();
            }

            var seanse = await _context.Seanse
                .FirstOrDefaultAsync(m => m.Id_seansu == id);
            if (seanse == null)
            {
                return NotFound();
            }

            return View(seanse);
        }

        // POST: Seanses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Seanse == null)
            {
                return Problem("Entity set 'KinoContext.Seanse'  is null.");
            }
            var seanse = await _context.Seanse.FindAsync(id);
            if (seanse != null)
            {
                _context.Seanse.Remove(seanse);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SeanseExists(int id)
        {
          return _context.Seanse.Any(e => e.Id_seansu == id);
        }
    }
}
