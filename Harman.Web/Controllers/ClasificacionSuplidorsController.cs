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
    public class ClasificacionSuplidorsController : Controller
    {
        private readonly DataContext _context;

        public ClasificacionSuplidorsController(DataContext context)
        {
            _context = context;
        }

        // GET: ClasificacionSuplidors
        public async Task<IActionResult> Index()
        {
            return View(await _context.ClasificacionSuplidor.ToListAsync());
        }

        // GET: ClasificacionSuplidors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clasificacionSuplidor = await _context.ClasificacionSuplidor
                .FirstOrDefaultAsync(m => m.ClasificacionSuplidorID == id);
            if (clasificacionSuplidor == null)
            {
                return NotFound();
            }

            return View(clasificacionSuplidor);
        }

        // GET: ClasificacionSuplidors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ClasificacionSuplidors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClasificacionSuplidorID,Code,Name")] ClasificacionSuplidor clasificacionSuplidor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clasificacionSuplidor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(clasificacionSuplidor);
        }

        // GET: ClasificacionSuplidors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clasificacionSuplidor = await _context.ClasificacionSuplidor.FindAsync(id);
            if (clasificacionSuplidor == null)
            {
                return NotFound();
            }
            return View(clasificacionSuplidor);
        }

        // POST: ClasificacionSuplidors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClasificacionSuplidorID,Code,Name")] ClasificacionSuplidor clasificacionSuplidor)
        {
            if (id != clasificacionSuplidor.ClasificacionSuplidorID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clasificacionSuplidor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClasificacionSuplidorExists(clasificacionSuplidor.ClasificacionSuplidorID))
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
            return View(clasificacionSuplidor);
        }

        // GET: ClasificacionSuplidors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clasificacionSuplidor = await _context.ClasificacionSuplidor
                .FirstOrDefaultAsync(m => m.ClasificacionSuplidorID == id);
            if (clasificacionSuplidor == null)
            {
                return NotFound();
            }

            return View(clasificacionSuplidor);
        }

        // POST: ClasificacionSuplidors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clasificacionSuplidor = await _context.ClasificacionSuplidor.FindAsync(id);
            _context.ClasificacionSuplidor.Remove(clasificacionSuplidor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClasificacionSuplidorExists(int id)
        {
            return _context.ClasificacionSuplidor.Any(e => e.ClasificacionSuplidorID == id);
        }
    }
}
