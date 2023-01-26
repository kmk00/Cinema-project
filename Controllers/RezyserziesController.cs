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
    public class RezyserziesController : Controller
    {
        private readonly KinoContext _context;

        public RezyserziesController(KinoContext context)
        {
            _context = context;
        }

        // GET: Rezyserzies
        public async Task<IActionResult> Index()
        {
              return View(await _context.Rezyserzy.ToListAsync());
        }

        // GET: Rezyserzies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Rezyserzy == null)
            {
                return NotFound();
            }

            var rezyserzy = await _context.Rezyserzy
                .FirstOrDefaultAsync(m => m.Id_rezysera == id);
            if (rezyserzy == null)
            {
                return NotFound();
            }

            return View(rezyserzy);
        }

        // GET: Rezyserzies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Rezyserzies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_rezysera,Imie,Nazwisko")] Rezyserzy rezyserzy)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rezyserzy);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rezyserzy);
        }

        // GET: Rezyserzies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Rezyserzy == null)
            {
                return NotFound();
            }

            var rezyserzy = await _context.Rezyserzy.FindAsync(id);
            if (rezyserzy == null)
            {
                return NotFound();
            }
            return View(rezyserzy);
        }

        // POST: Rezyserzies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_rezysera,Imie,Nazwisko")] Rezyserzy rezyserzy)
        {
            if (id != rezyserzy.Id_rezysera)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rezyserzy);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RezyserzyExists(rezyserzy.Id_rezysera))
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
            return View(rezyserzy);
        }

        // GET: Rezyserzies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Rezyserzy == null)
            {
                return NotFound();
            }

            var rezyserzy = await _context.Rezyserzy
                .FirstOrDefaultAsync(m => m.Id_rezysera == id);
            if (rezyserzy == null)
            {
                return NotFound();
            }

            return View(rezyserzy);
        }

        // POST: Rezyserzies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Rezyserzy == null)
            {
                return Problem("Entity set 'KinoContext.Rezyserzy'  is null.");
            }
            var rezyserzy = await _context.Rezyserzy.FindAsync(id);
            if (rezyserzy != null)
            {
                _context.Rezyserzy.Remove(rezyserzy);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RezyserzyExists(int id)
        {
          return _context.Rezyserzy.Any(e => e.Id_rezysera == id);
        }
    }
}
