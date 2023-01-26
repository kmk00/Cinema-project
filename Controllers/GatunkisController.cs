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
    public class GatunkisController : Controller
    {
        private readonly KinoContext _context;

        public GatunkisController(KinoContext context)
        {
            _context = context;
        }

        // GET: Gatunkis
        public async Task<IActionResult> Index()
        {
              return View(await _context.Gatunki.ToListAsync());
        }

        // GET: Gatunkis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Gatunki == null)
            {
                return NotFound();
            }

            var gatunki = await _context.Gatunki
                .FirstOrDefaultAsync(m => m.Id_gatunku == id);
            if (gatunki == null)
            {
                return NotFound();
            }

            return View(gatunki);
        }

        // GET: Gatunkis/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Gatunkis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_gatunku,Gatunek")] Gatunki gatunki)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gatunki);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(gatunki);
        }

        // GET: Gatunkis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Gatunki == null)
            {
                return NotFound();
            }

            var gatunki = await _context.Gatunki.FindAsync(id);
            if (gatunki == null)
            {
                return NotFound();
            }
            return View(gatunki);
        }

        // POST: Gatunkis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_gatunku,Gatunek")] Gatunki gatunki)
        {
            if (id != gatunki.Id_gatunku)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gatunki);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GatunkiExists(gatunki.Id_gatunku))
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
            return View(gatunki);
        }

        // GET: Gatunkis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Gatunki == null)
            {
                return NotFound();
            }

            var gatunki = await _context.Gatunki
                .FirstOrDefaultAsync(m => m.Id_gatunku == id);
            if (gatunki == null)
            {
                return NotFound();
            }

            return View(gatunki);
        }

        // POST: Gatunkis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Gatunki == null)
            {
                return Problem("Entity set 'KinoContext.Gatunki'  is null.");
            }
            var gatunki = await _context.Gatunki.FindAsync(id);
            if (gatunki != null)
            {
                _context.Gatunki.Remove(gatunki);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GatunkiExists(int id)
        {
          return _context.Gatunki.Any(e => e.Id_gatunku == id);
        }
    }
}
