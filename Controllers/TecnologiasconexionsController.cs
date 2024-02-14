using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CrudAudiovisuales.models;

namespace CrudAudiovisuales.Controllers
{
    public class TecnologiasconexionsController : Controller
    {
        private readonly AudiovisualesContext _context;

        public TecnologiasconexionsController(AudiovisualesContext context)
        {
            _context = context;
        }

        // GET: Tecnologiasconexions
        public async Task<IActionResult> Index()
        {
              return _context.Tecnologiasconexions != null ? 
                          View(await _context.Tecnologiasconexions.ToListAsync()) :
                          Problem("Entity set 'AudiovisualesContext.Tecnologiasconexions'  is null.");
        }

        // GET: Tecnologiasconexions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Tecnologiasconexions == null)
            {
                return NotFound();
            }

            var tecnologiasconexion = await _context.Tecnologiasconexions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tecnologiasconexion == null)
            {
                return NotFound();
            }

            return View(tecnologiasconexion);
        }

        // GET: Tecnologiasconexions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tecnologiasconexions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descripcion,Estado")] Tecnologiasconexion tecnologiasconexion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tecnologiasconexion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tecnologiasconexion);
        }

        // GET: Tecnologiasconexions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Tecnologiasconexions == null)
            {
                return NotFound();
            }

            var tecnologiasconexion = await _context.Tecnologiasconexions.FindAsync(id);
            if (tecnologiasconexion == null)
            {
                return NotFound();
            }
            return View(tecnologiasconexion);
        }

        // POST: Tecnologiasconexions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descripcion,Estado")] Tecnologiasconexion tecnologiasconexion)
        {
            if (id != tecnologiasconexion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tecnologiasconexion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TecnologiasconexionExists(tecnologiasconexion.Id))
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
            return View(tecnologiasconexion);
        }

        // GET: Tecnologiasconexions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Tecnologiasconexions == null)
            {
                return NotFound();
            }

            var tecnologiasconexion = await _context.Tecnologiasconexions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tecnologiasconexion == null)
            {
                return NotFound();
            }

            return View(tecnologiasconexion);
        }

        // POST: Tecnologiasconexions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Tecnologiasconexions == null)
            {
                return Problem("Entity set 'AudiovisualesContext.Tecnologiasconexions'  is null.");
            }
            var tecnologiasconexion = await _context.Tecnologiasconexions.FindAsync(id);
            if (tecnologiasconexion != null)
            {
                _context.Tecnologiasconexions.Remove(tecnologiasconexion);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TecnologiasconexionExists(int id)
        {
          return (_context.Tecnologiasconexions?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
