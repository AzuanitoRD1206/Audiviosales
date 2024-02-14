using CrudAudiovisuales.models;
using CrudAudiovisuales.models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CrudAudiovisuales.Controllers
{
    public class EquipoesController : Controller
    {
        private readonly AudiovisualesContext _context;

        public EquipoesController(AudiovisualesContext context)
        {
            _context = context;
        }

        // GET: Equipoes
        public async Task<IActionResult> Index()
        {
            var audiovisualesContext = _context.Equipos.Include(e => e.Marca).Include(e => e.Modelo).Include(e => e.TipoEquipo).Include(e => e.TipoTecnologiaConexion);
            return View(await audiovisualesContext.ToListAsync());
        }

        // GET: Equipoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Equipos == null)
            {
                return NotFound();
            }

            var equipo = await _context.Equipos
                .Include(e => e.Marca)
                .Include(e => e.Modelo)
                .Include(e => e.TipoEquipo)
                .Include(e => e.TipoTecnologiaConexion)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (equipo == null)
            {
                return NotFound();
            }

            return View(equipo);
        }

       // GET: Equipoes/Create
        public IActionResult Create()
        {
            ViewData["MarcaId"] = new SelectList(_context.Marcas, "Id", "Id");
            ViewData["ModeloId"] = new SelectList(_context.Modelos, "Id", "Id");
            ViewData["TipoEquipoId"] = new SelectList(_context.Tiposdeequipos, "Id", "Id");
            ViewData["TipoTecnologiaConexionId"] = new SelectList(_context.Tecnologiasconexions, "Id", "Id");
            return View();
        }

        // POST: Equipoes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Descripcion,NoSerial,ServiceTag,TipoEquipoId,MarcaId,ModeloId,TipoTecnologiaConexionId,Estado")] EquipoDto equipoDto)
        {
            if (ModelState.IsValid)
            {
                var equipo = new Equipo
                {
                    Descripcion = equipoDto.Descripcion,
                    NoSerial = equipoDto.NoSerial,
                    ServiceTag = equipoDto.ServiceTag,
                    TipoEquipoId = equipoDto.TipoEquipoId,
                    MarcaId = equipoDto.MarcaId,
                    ModeloId = equipoDto.ModeloId,
                    TipoTecnologiaConexionId = equipoDto.TipoTecnologiaConexionId,
                    Estado = equipoDto.Estado
                };

                _context.Add(equipo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["MarcaId"] = new SelectList(_context.Marcas, "Id", "Id", equipoDto.MarcaId);
            ViewData["ModeloId"] = new SelectList(_context.Modelos, "Id", "Id", equipoDto.ModeloId);
            ViewData["TipoEquipoId"] = new SelectList(_context.Tiposdeequipos, "Id", "Id", equipoDto.TipoEquipoId);
            ViewData["TipoTecnologiaConexionId"] = new SelectList(_context.Tecnologiasconexions, "Id", "Id", equipoDto.TipoTecnologiaConexionId);
            return View(equipoDto);
        }

        // GET: Equipoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Equipos == null)
            {
                return NotFound();
            }

            var equipo = await _context.Equipos.FindAsync(id);
            if (equipo == null)
            {
                return NotFound();
            }
            ViewData["MarcaId"] = new SelectList(_context.Marcas, "Id", "Id", equipo.MarcaId);
            ViewData["ModeloId"] = new SelectList(_context.Modelos, "Id", "Id", equipo.ModeloId);
            ViewData["TipoEquipoId"] = new SelectList(_context.Tiposdeequipos, "Id", "Id", equipo.TipoEquipoId);
            ViewData["TipoTecnologiaConexionId"] = new SelectList(_context.Tecnologiasconexions, "Id", "Id", equipo.TipoTecnologiaConexionId);
            return View(equipo);
        }

        // POST: Equipoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descripcion,NoSerial,ServiceTag,TipoEquipoId,MarcaId,ModeloId,TipoTecnologiaConexionId,Estado")] Equipo equipo)
        {
            if (id != equipo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(equipo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EquipoExists(equipo.Id))
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
            ViewData["MarcaId"] = new SelectList(_context.Marcas, "Id", "Id", equipo.MarcaId);
            ViewData["ModeloId"] = new SelectList(_context.Modelos, "Id", "Id", equipo.ModeloId);
            ViewData["TipoEquipoId"] = new SelectList(_context.Tiposdeequipos, "Id", "Id", equipo.TipoEquipoId);
            ViewData["TipoTecnologiaConexionId"] = new SelectList(_context.Tecnologiasconexions, "Id", "Id", equipo.TipoTecnologiaConexionId);
            return View(equipo);
        }

        // GET: Equipoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Equipos == null)
            {
                return NotFound();
            }

            var equipo = await _context.Equipos
                .Include(e => e.Marca)
                .Include(e => e.Modelo)
                .Include(e => e.TipoEquipo)
                .Include(e => e.TipoTecnologiaConexion)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (equipo == null)
            {
                return NotFound();
            }

            return View(equipo);
        }

        // POST: Equipoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Equipos == null)
            {
                return Problem("Entity set 'AudiovisualesContext.Equipos'  is null.");
            }
            var equipo = await _context.Equipos.FindAsync(id);
            if (equipo != null)
            {
                _context.Equipos.Remove(equipo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EquipoExists(int id)
        {
            return (_context.Equipos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
