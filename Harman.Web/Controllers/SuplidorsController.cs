using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Harman.Web.Data;
using Harman.Web.Data.Entities;

namespace Harman.Web.Controllers
{
    public class SuplidorsController : Controller
    {
        private readonly DataContext _context;

        public SuplidorsController(DataContext context)
        {
            _context = context;
        }

        // GET: Suplidors
        public async Task<IActionResult> Index()
        {
            var dataContext = _context.Suplidor.Include(s => s.Ciudad).Include(s => s.ClasificacionSuplidor).Include(s => s.TipoDocumento);
            return View(await dataContext.ToListAsync());
        }

        // GET: Suplidors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var suplidor = await _context.Suplidor
                .Include(s => s.Ciudad)
                .Include(s => s.ClasificacionSuplidor)
                .Include(s => s.TipoDocumento)
                .FirstOrDefaultAsync(m => m.SupplidorID == id);
            if (suplidor == null)
            {
                return NotFound();
            }

            return View(suplidor);
        }

        // GET: Suplidors/Create
        public IActionResult Create()
        {
            ViewData["CiudadID"] = new SelectList(_context.Ciudad, "CiudadID", "CityName");
            ViewData["ClasificacionSuplidorID"] = new SelectList(_context.ClasificacionSuplidor, "ClasificacionSuplidorID", "Name");
            ViewData["TipoDocumentoID"] = new SelectList(_context.Set<TipoDocumento>(), "TipoDocumentoID", "DescripcionTipoDocumento");
            return View();
        }

        // POST: Suplidors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SupplidorID,SupplierCode,SupplierFirstName,SupplierLastName,SupplierDocumentNumber,SupplierPhone,SupplierCellPhone,SupplierStartDate,SupplierAddress,SupplierEmail,SupplierRemarks,ClasificacionSuplidorID,TipoDocumentoID,CiudadID")] Suplidor suplidor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(suplidor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CiudadID"] = new SelectList(_context.Ciudad, "CiudadID", "CityName", suplidor.CiudadID);
            ViewData["ClasificacionSuplidorID"] = new SelectList(_context.ClasificacionSuplidor, "ClasificacionSuplidorID", "Name", suplidor.ClasificacionSuplidorID);
            ViewData["TipoDocumentoID"] = new SelectList(_context.Set<TipoDocumento>(), "TipoDocumentoID", "DescripcionTipoDocumento", suplidor.TipoDocumentoID);
            return View(suplidor);
        }

        // GET: Suplidors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var suplidor = await _context.Suplidor.FindAsync(id);
            if (suplidor == null)
            {
                return NotFound();
            }
            ViewData["CiudadID"] = new SelectList(_context.Ciudad, "CiudadID", "CityName", suplidor.CiudadID);
            ViewData["ClasificacionSuplidorID"] = new SelectList(_context.ClasificacionSuplidor, "ClasificacionSuplidorID", "Name", suplidor.ClasificacionSuplidorID);
            ViewData["TipoDocumentoID"] = new SelectList(_context.Set<TipoDocumento>(), "TipoDocumentoID", "DescripcionTipoDocumento", suplidor.TipoDocumentoID);
            return View(suplidor);
        }

        // POST: Suplidors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SupplidorID,SupplierCode,SupplierFirstName,SupplierLastName,SupplierDocumentNumber,SupplierPhone,SupplierCellPhone,SupplierStartDate,SupplierAddress,SupplierEmail,SupplierRemarks,ClasificacionSuplidorID,TipoDocumentoID,CiudadID")] Suplidor suplidor)
        {
            if (id != suplidor.SupplidorID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(suplidor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SuplidorExists(suplidor.SupplidorID))
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
            ViewData["CiudadID"] = new SelectList(_context.Ciudad, "CiudadID", "CityName", suplidor.CiudadID);
            ViewData["ClasificacionSuplidorID"] = new SelectList(_context.ClasificacionSuplidor, "ClasificacionSuplidorID", "Name", suplidor.ClasificacionSuplidorID);
            ViewData["TipoDocumentoID"] = new SelectList(_context.Set<TipoDocumento>(), "TipoDocumentoID", "DescripcionTipoDocumento", suplidor.TipoDocumentoID);
            return View(suplidor);
        }

        // GET: Suplidors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var suplidor = await _context.Suplidor
                .Include(s => s.Ciudad)
                .Include(s => s.ClasificacionSuplidor)
                .Include(s => s.TipoDocumento)
                .FirstOrDefaultAsync(m => m.SupplidorID == id);
            if (suplidor == null)
            {
                return NotFound();
            }

            return View(suplidor);
        }

        // POST: Suplidors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var suplidor = await _context.Suplidor.FindAsync(id);
            _context.Suplidor.Remove(suplidor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SuplidorExists(int id)
        {
            return _context.Suplidor.Any(e => e.SupplidorID == id);
        }
    }
}
