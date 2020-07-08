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
    public class TasaDeCambiosController : Controller
    {
        private readonly DataContext _context;

        public TasaDeCambiosController(DataContext context)
        {
            _context = context;
        }

        // GET: TasaDeCambios
        public async Task<IActionResult> Index()
        {
            var dataContext = _context.TasaDeCambio.Include(t => t.Moneda);
            return View(await dataContext.ToListAsync());
        }

        // GET: TasaDeCambios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tasaDeCambio = await _context.TasaDeCambio
                .Include(t => t.Moneda)
                .FirstOrDefaultAsync(m => m.TasaDeCambioID == id);
            if (tasaDeCambio == null)
            {
                return NotFound();
            }

            return View(tasaDeCambio);
        }

        // GET: TasaDeCambios/Create
        public IActionResult Create()
        {
            ViewData["MonedaID"] = new SelectList(_context.Moneda, "MonedaID", "CodigoMoneda");
            return View();
        }

        // POST: TasaDeCambios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TasaDeCambioID,FechaCreacionTasaDeCambio,ExchangeValue,MonedaID")] TasaDeCambio tasaDeCambio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tasaDeCambio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MonedaID"] = new SelectList(_context.Moneda, "MonedaID", "CodigoMoneda", tasaDeCambio.MonedaID);
            return View(tasaDeCambio);
        }

        // GET: TasaDeCambios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tasaDeCambio = await _context.TasaDeCambio.FindAsync(id);
            if (tasaDeCambio == null)
            {
                return NotFound();
            }
            ViewData["MonedaID"] = new SelectList(_context.Moneda, "MonedaID", "CodigoMoneda", tasaDeCambio.MonedaID);
            return View(tasaDeCambio);
        }

        // POST: TasaDeCambios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TasaDeCambioID,FechaCreacionTasaDeCambio,ExchangeValue,MonedaID")] TasaDeCambio tasaDeCambio)
        {
            if (id != tasaDeCambio.TasaDeCambioID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tasaDeCambio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TasaDeCambioExists(tasaDeCambio.TasaDeCambioID))
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
            ViewData["MonedaID"] = new SelectList(_context.Moneda, "MonedaID", "CodigoMoneda", tasaDeCambio.MonedaID);
            return View(tasaDeCambio);
        }

        // GET: TasaDeCambios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tasaDeCambio = await _context.TasaDeCambio
                .Include(t => t.Moneda)
                .FirstOrDefaultAsync(m => m.TasaDeCambioID == id);
            if (tasaDeCambio == null)
            {
                return NotFound();
            }

            return View(tasaDeCambio);
        }

        // POST: TasaDeCambios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tasaDeCambio = await _context.TasaDeCambio.FindAsync(id);
            _context.TasaDeCambio.Remove(tasaDeCambio);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TasaDeCambioExists(int id)
        {
            return _context.TasaDeCambio.Any(e => e.TasaDeCambioID == id);
        }
    }
}
