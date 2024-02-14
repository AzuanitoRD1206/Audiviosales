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
    public class TiposdeequipoesController : Controller
    {
        private readonly AudiovisualesContext _context;

        public TiposdeequipoesController(AudiovisualesContext context)
        {
            _context = context;
        }

        // GET: Tiposdeequipoes
        public async Task<IActionResult> Index()
        {
              return _context.Tiposdeequipos != null ? 
                          View(await _context.Tiposdeequipos.ToListAsync()) :
                          Problem("Entity set 'AudiovisualesContext.Tiposdeequipos'  is null.");
        }

        // GET: Tiposdeequipoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Tiposdeequipos == null)
            {
                return NotFound();
            }

            var tiposdeequipo = await _context.Tiposdeequipos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tiposdeequipo == null)
            {
                return NotFound();
            }

            return View(tiposdeequipo);
        }

        // GET: Tiposdeequipoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tiposdeequipoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descripcion,Estado")] Tiposdeequipo tiposdeequipo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tiposdeequipo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tiposdeequipo);
        }

        // GET: Tiposdeequipoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Tiposdeequipos == null)
            {
                return NotFound();
            }

            var tiposdeequipo = await _context.Tiposdeequipos.FindAsync(id);
            if (tiposdeequipo == null)
            {
                return NotFound();
            }
            return View(tiposdeequipo);
        }

        // POST: Tiposdeequipoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descripcion,Estado")] Tiposdeequipo tiposdeequipo)
        {
            if (id != tiposdeequipo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tiposdeequipo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TiposdeequipoExists(tiposdeequipo.Id))
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
            return View(tiposdeequipo);
        }

        // GET: Tiposdeequipoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Tiposdeequipos == null)
            {
                return NotFound();
            }

            var tiposdeequipo = await _context.Tiposdeequipos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tiposdeequipo == null)
            {
                return NotFound();
            }

            return View(tiposdeequipo);
        }

        // POST: Tiposdeequipoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Tiposdeequipos == null)
            {
                return Problem("Entity set 'AudiovisualesContext.Tiposdeequipos'  is null.");
            }
            var tiposdeequipo = await _context.Tiposdeequipos.FindAsync(id);
            if (tiposdeequipo != null)
            {
                _context.Tiposdeequipos.Remove(tiposdeequipo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TiposdeequipoExists(int id)
        {
          return (_context.Tiposdeequipos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
