using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CrudAudiovisuales.models;
using CrudAudiovisuales.models.DTO;

namespace CrudAudiovisuales.Controllers
{
    public class ModeloesController : Controller
    {
        private readonly AudiovisualesContext _context;

        public ModeloesController(AudiovisualesContext context)
        {
            _context = context;
        }

        // GET: Modeloes
        public async Task<IActionResult> Index()
        {
            var audiovisualesContext = _context.Modelos.Include(m => m.Marca);
            return View(await audiovisualesContext.ToListAsync());
        }

        // GET: Modeloes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Modelos == null)
            {
                return NotFound();
            }

            var modelo = await _context.Modelos
                .Include(m => m.Marca)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (modelo == null)
            {
                return NotFound();
            }

            return View(modelo);
        }

        // GET: Modeloes/Create
        public IActionResult Create()
        {
            ViewData["MarcaId"] = new SelectList(_context.Marcas, "Id", "Id");
            return View();
        }

        // POST: Modeloes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MarcaId,Descripcion,Estado")] ModeloDto modelo)

        {
            Modelo modeloentry = null;
            if (ModelState.IsValid)
            {
                modeloentry = new Modelo{
                    MarcaId = modelo.MarcaId,
                    Descripcion = modelo.Descripcion,
                    Estado = modelo.Estado
                };
                _context.Add(modeloentry);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            /*ViewData["MarcaId"] = new SelectList(_context.Marcas, "Id", "Id", modelo.MarcaId);*/
            return View(modeloentry);
        }

        // GET: Modeloes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Modelos == null)
            {
                return NotFound();
            }

            var modelo = await _context.Modelos.FindAsync(id);
            if (modelo == null)
            {
                return NotFound();
            }
            ViewData["MarcaId"] = new SelectList(_context.Marcas, "Id", "Id", modelo.MarcaId);
            return View(modelo);
        }

        // POST: Modeloes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MarcaId,Descripcion,Estado")] Modelo modelo)
        {
            if (id != modelo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(modelo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ModeloExists(modelo.Id))
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
            ViewData["MarcaId"] = new SelectList(_context.Marcas, "Id", "Id", modelo.MarcaId);
            return View(modelo);
        }

            // GET: Modeloes/Delete/5
            public async Task<IActionResult> Delete(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var modelo = await _context.Modelos
                    .Include(m => m.Marca)
                    .FirstOrDefaultAsync(m => m.Id == id);

                if (modelo == null)
                {
                    return NotFound();
                }

                return View(modelo);
            }

            // POST: Modeloes/Delete/5
            [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> DeleteConfirmed(int id)
            {
                var modelo = await _context.Modelos.FindAsync(id);

                if (modelo != null)
                {
                    _context.Modelos.Remove(modelo);
                    await _context.SaveChangesAsync();
                }

                return RedirectToAction(nameof(Index));
            }


        private bool ModeloExists(int id)
        {
          return (_context.Modelos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
