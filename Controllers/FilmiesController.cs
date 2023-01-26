using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Kino.Data;
using Kino.Models;
using Microsoft.Extensions.Primitives;

namespace Kino.Controllers
{
    public class FilmiesController : Controller
    {
        private readonly KinoContext _context;

        public FilmiesController(KinoContext context)
        {
            _context = context;
        }

        // GET: Filmies
        public async Task<IActionResult> Index()
        {
            var filmy = _context.Filmy.Include(g => g.Gatunek).Include(r => r.Rezyser);
              return View(await filmy.ToListAsync());
        }


/*
        public async Task<IActionResult> Index()
        {
            return View(await _context.Filmy.ToListAsync());
        }
*/
        // GET: Filmies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Filmy == null)
            {
                return NotFound();
            }

            var filmy = await _context.Filmy.Include(g => g.Gatunek).Include(r => r.Rezyser)
                .FirstOrDefaultAsync(m => m.Id_filmu == id);
            if (filmy == null)
            {
                return NotFound();
            }

            return View(filmy);
        }

        // GET: Filmies/Create
        public IActionResult Create()
        {
            PopulateGatunki();
            PopulateRezysera();
            return View();
        }

        private void PopulateGatunki()
        {
            var wybraneGatunki = from g in _context.Gatunki orderby g.Gatunek select g;
            var res = wybraneGatunki.AsNoTracking();
            ViewBag.GatunekID = new SelectList(res, "Id_gatunku", "Gatunek");
        }

        private void PopulateRezysera()
        {
            var wybranyRezyser = from g in _context.Rezyserzy orderby g.Nazwisko select g;
            var res = wybranyRezyser.AsNoTracking();
            ViewBag.RezyserID = new SelectList(res, "Id_rezysera", "Nazwisko");
        }

        // POST: Filmies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_filmu,Tytul,Czas_trwania,Rok,Plakat")] Filmy filmy, IFormCollection form)
        {

            string gatunekValue = form["Gatunek"].ToString();
            string rezyserValue = form["Rezyser"].ToString();


            if (ModelState.IsValid)
            {
                Rezyserzy rezyser = null;
                if(rezyserValue != "")
                {
                    var ee = _context.Rezyserzy.Where(e => e.Id_rezysera == int.Parse(rezyserValue));
                    if (ee.Count() > 0) rezyser = ee.First();
                }
                
                Gatunki gatunek = null;
                if (gatunekValue != "")
                {
                    var ee = _context.Gatunki.Where(e => e.Id_gatunku == int.Parse(gatunekValue));
                    if (ee.Count() > 0) gatunek = ee.First();
                }

                


                filmy.Rezyser = rezyser;
                filmy.Gatunek = gatunek;
                


                _context.Add(filmy);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(filmy);
        }

        // GET: Filmies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Filmy == null)
            {
                return NotFound();
            }

            var filmy = await _context.Filmy.FindAsync(id);
            if (filmy == null)
            {
                return NotFound();
            }
            return View(filmy);
        }

        // POST: Filmies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_filmu,Tytul,Czas_trwania,Rok")] Filmy filmy)
        {
            if (id != filmy.Id_filmu)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(filmy);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FilmyExists(filmy.Id_filmu))
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
            return View(filmy);
        }

        // GET: Filmies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Filmy == null)
            {
                return NotFound();
            }

            var filmy = await _context.Filmy
                .FirstOrDefaultAsync(m => m.Id_filmu == id);
            if (filmy == null)
            {
                return NotFound();
            }

            return View(filmy);
        }

        // POST: Filmies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Filmy == null)
            {
                return Problem("Entity set 'KinoContext.Filmy'  is null.");
            }
            var filmy = await _context.Filmy.FindAsync(id);
            if (filmy != null)
            {
                _context.Filmy.Remove(filmy);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        

        private bool FilmyExists(int id)
        {
          return _context.Filmy.Any(e => e.Id_filmu == id);
        }
    }
}
