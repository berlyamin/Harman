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
    public class UnidadsController : Controller
    {
        private readonly DataContext _context;

        public UnidadsController(DataContext context)
        {
            _context = context;
        }

        // GET: Unidads
        public async Task<IActionResult> Index()
        {
            return View(await _context.Unidad.ToListAsync());
        }

        // GET: Unidads/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unidad = await _context.Unidad
                .FirstOrDefaultAsync(m => m.UnidadID == id);
            if (unidad == null)
            {
                return NotFound();
            }

            return View(unidad);
        }

        // GET: Unidads/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Unidads/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UnidadID,CodigoUnidad,NombreUnidad")] Unidad unidad)
        {
            if (ModelState.IsValid)
            {
                _context.Add(unidad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(unidad);
        }

        // GET: Unidads/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unidad = await _context.Unidad.FindAsync(id);
            if (unidad == null)
            {
                return NotFound();
            }
            return View(unidad);
        }

        // POST: Unidads/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UnidadID,CodigoUnidad,NombreUnidad")] Unidad unidad)
        {
            if (id != unidad.UnidadID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(unidad);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UnidadExists(unidad.UnidadID))
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
            return View(unidad);
        }

        // GET: Unidads/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unidad = await _context.Unidad
                .FirstOrDefaultAsync(m => m.UnidadID == id);
            if (unidad == null)
            {
                return NotFound();
            }

            return View(unidad);
        }

        // POST: Unidads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var unidad = await _context.Unidad.FindAsync(id);
            _context.Unidad.Remove(unidad);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UnidadExists(int id)
        {
            return _context.Unidad.Any(e => e.UnidadID == id);
        }
    }
}
