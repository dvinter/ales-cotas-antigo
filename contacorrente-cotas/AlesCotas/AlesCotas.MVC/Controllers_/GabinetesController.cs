using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AlesCotas.Domain.Entities;
using AlesCotas.Infra.Data.Context;
using Microsoft.AspNetCore.Authorization;

namespace AlesCotas.MVC.Controllers
{
    [Authorize]
    public class GabinetesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GabinetesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Gabinetes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Gabinetes.ToListAsync());
        }

        // GET: Gabinetes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Gabinetes == null)
            {
                return NotFound();
            }

            var gabinete = await _context.Gabinetes
                .FirstOrDefaultAsync(m => m.IDGabinete == id);
            if (gabinete == null)
            {
                return NotFound();
            }

            return View(gabinete);
        }

        // GET: Gabinetes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Gabinetes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IDGabinete,Nome,IsAtivo")] Gabinete gabinete)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gabinete);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(gabinete);
        }

        // GET: Gabinetes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Gabinetes == null)
            {
                return NotFound();
            }

            var gabinete = await _context.Gabinetes.FindAsync(id);
            if (gabinete == null)
            {
                return NotFound();
            }
            return View(gabinete);
        }

        // POST: Gabinetes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IDGabinete,Nome,IsAtivo,CreatedAt,UpdatedAt")] Gabinete gabinete)
        {
            if (id != gabinete.IDGabinete)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gabinete);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GabineteExists(gabinete.IDGabinete))
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
            return View(gabinete);
        }

        // GET: Gabinetes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Gabinetes == null)
            {
                return NotFound();
            }

            var gabinete = await _context.Gabinetes
                .FirstOrDefaultAsync(m => m.IDGabinete == id);
            if (gabinete == null)
            {
                return NotFound();
            }

            return View(gabinete);
        }

        // POST: Gabinetes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Gabinetes == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Gabinetes'  is null.");
            }
            var gabinete = await _context.Gabinetes.FindAsync(id);
            if (gabinete != null)
            {
                _context.Gabinetes.Remove(gabinete);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GabineteExists(int id)
        {
            return _context.Gabinetes.Any(e => e.IDGabinete == id);
        }
    }
}
