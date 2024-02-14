using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CrudAudiovisuales.models;
using Microsoft.AspNetCore.Authorization;
using CrudAudiovisuales.models.DTO;
using ClosedXML.Excel;
using System.Data;
using OfficeOpenXml;

namespace CrudAudiovisuales.Controllers
{
    public class RentadevolucionsController : Controller
    {
        private readonly AudiovisualesContext _context;

        public RentadevolucionsController(AudiovisualesContext context)
        {
            _context = context;
        }

        // GET: Rentadevolucions
        public async Task<IActionResult> Index()
        {
            var audiovisualesContext = _context.Rentadevolucions.Include(r => r.Empleado).Include(r => r.Equipo).Include(r => r.Usuario);
            return View(await audiovisualesContext.ToListAsync());
        }

        // GET: Rentadevolucions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Rentadevolucions == null)
            {
                return NotFound();
            }

            var rentadevolucion = await _context.Rentadevolucions
                .Include(r => r.Empleado)
                .Include(r => r.Equipo)
                .Include(r => r.Usuario)
                .FirstOrDefaultAsync(m => m.NoPrestamo == id);
            if (rentadevolucion == null)
            {
                return NotFound();
            }

            return View(rentadevolucion);
        }

       // GET: Rentadevolucions/Create
        public IActionResult Create()
        {
            ViewData["EmpleadoId"] = new SelectList(_context.Empleados, "Id", "Id");
            ViewData["EquipoId"] = new SelectList(_context.Equipos, "Id", "Id");
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Id");
            return View();
        }

        // POST: Rentadevolucions/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NoPrestamo,EmpleadoId,EquipoId,UsuarioId,FechaPrestamo,FechaDevolucion,Comentario,Estado")] RentadevolucionDto rentadevolucionDto)
        {
            if (ModelState.IsValid)
            {
                var rentadevolucion = new Rentadevolucion
                {
                    NoPrestamo = rentadevolucionDto.NoPrestamo,
                    EmpleadoId = rentadevolucionDto.EmpleadoId,
                    EquipoId = rentadevolucionDto.EquipoId,
                    UsuarioId = rentadevolucionDto.UsuarioId,
                    FechaPrestamo = rentadevolucionDto.FechaPrestamo,
                    FechaDevolucion = rentadevolucionDto.FechaDevolucion,
                    Comentario = rentadevolucionDto.Comentario,
                    Estado = rentadevolucionDto.Estado
                };

                _context.Add(rentadevolucion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["EmpleadoId"] = new SelectList(_context.Empleados, "Id", "Id", rentadevolucionDto.EmpleadoId);
            ViewData["EquipoId"] = new SelectList(_context.Equipos, "Id", "Id", rentadevolucionDto.EquipoId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Id", rentadevolucionDto.UsuarioId);
            return View(rentadevolucionDto);
        }

        // GET: Rentadevolucions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Rentadevolucions == null)
            {
                return NotFound();
            }

            var rentadevolucion = await _context.Rentadevolucions.FindAsync(id);
            if (rentadevolucion == null)
            {
                return NotFound();
            }
            ViewData["EmpleadoId"] = new SelectList(_context.Empleados, "Id", "Id", rentadevolucion.EmpleadoId);
            ViewData["EquipoId"] = new SelectList(_context.Equipos, "Id", "Id", rentadevolucion.EquipoId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Id", rentadevolucion.UsuarioId);
            return View(rentadevolucion);
        }

        // POST: Rentadevolucions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NoPrestamo,EmpleadoId,EquipoId,UsuarioId,FechaPrestamo,FechaDevolucion,Comentario,Estado")] Rentadevolucion rentadevolucion)
        {
            if (id != rentadevolucion.NoPrestamo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rentadevolucion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RentadevolucionExists(rentadevolucion.NoPrestamo))
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
            ViewData["EmpleadoId"] = new SelectList(_context.Empleados, "Id", "Id", rentadevolucion.EmpleadoId);
            ViewData["EquipoId"] = new SelectList(_context.Equipos, "Id", "Id", rentadevolucion.EquipoId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Id", rentadevolucion.UsuarioId);
            return View(rentadevolucion);
        }

        // GET: Rentadevolucions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Rentadevolucions == null)
            {
                return NotFound();
            }

            var rentadevolucion = await _context.Rentadevolucions
                .Include(r => r.Empleado)
                .Include(r => r.Equipo)
                .Include(r => r.Usuario)
                .FirstOrDefaultAsync(m => m.NoPrestamo == id);
            if (rentadevolucion == null)
            {
                return NotFound();
            }

            return View(rentadevolucion);
        }

        // POST: Rentadevolucions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Rentadevolucions == null)
            {
                return Problem("Entity set 'AudiovisualesContext.Rentadevolucions'  is null.");
            }
            var rentadevolucion = await _context.Rentadevolucions.FindAsync(id);
            if (rentadevolucion != null)
            {
                _context.Rentadevolucions.Remove(rentadevolucion);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<ActionResult> ExportToExcelAsync()
    {
        // Get your list of models
        List<Rentadevolucion> models = _context.Rentadevolucions.Include(r => r.Empleado).Include(r => r.Equipo).Include(r => r.Usuario).ToList();

        // Create a new Excel package
        ExcelPackage package = new ExcelPackage();
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

        // Add a new worksheet to the Excel package
        ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Sheet1");

                // Set the column names in the first row
        worksheet.Cells[1, 1].Value = "NoPrestamo";
        worksheet.Cells[1, 2].Value = "EmpleadoId";
        worksheet.Cells[1, 3].Value = "EquipoId";
        worksheet.Cells[1, 4].Value = "UsuarioId";
        worksheet.Cells[1, 5].Value = "FechaPrestamo";
        worksheet.Cells[1, 6].Value = "FechaDevolucion";
        worksheet.Cells[1, 7].Value = "Comentario";
        worksheet.Cells[1, 8].Value = "Estado";

        // Populate the Excel sheet with data
        int row = 2; // Start from the second row (first row is for headers)
        foreach (var model in models)
        {
            worksheet.Cells[row, 1].Value = model.NoPrestamo;
            worksheet.Cells[row, 2].Value = model.EmpleadoId;
            worksheet.Cells[row, 3].Value = model.EquipoId;
            worksheet.Cells[row, 4].Value = model.UsuarioId;
            worksheet.Cells[row, 5].Value = model.FechaPrestamo;
            worksheet.Cells[row, 6].Value = model.FechaDevolucion;
            worksheet.Cells[row, 7].Value = model.Comentario;
            worksheet.Cells[row, 8].Value = model.Estado;

            row++;
        }

        // Generate a unique filename for the Excel file
        string fileName = "Export_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx";

        // Set the content type and headers
        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        Response.Headers.Append("content-disposition", "attachment;  filename=" + fileName);

        // Write the Excel package to the response stream
        await Response.Body.WriteAsync(package.GetAsByteArray());

        return new EmptyResult();
    }
        private bool RentadevolucionExists(int id)
        {
          return (_context.Rentadevolucions?.Any(e => e.NoPrestamo == id)).GetValueOrDefault();
        }
    }
}
