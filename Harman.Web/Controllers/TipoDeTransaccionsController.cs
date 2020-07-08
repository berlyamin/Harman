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
    public class TipoDeTransaccionsController : Controller
    {
        private readonly DataContext _context;

        public TipoDeTransaccionsController(DataContext context)
        {
            _context = context;
        }

        // GET: TipoDeTransaccions
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoDeTransaccion.ToListAsync());
        }

        // GET: TipoDeTransaccions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoDeTransaccion = await _context.TipoDeTransaccion
                .FirstOrDefaultAsync(m => m.TipoDeTransaccionID == id);
            if (tipoDeTransaccion == null)
            {
                return NotFound();
            }

            return View(tipoDeTransaccion);
        }

        // GET: TipoDeTransaccions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoDeTransaccions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TipoDeTransaccionID,TransactionTypecode,DescripcionTipoDeTransaccion")] TipoDeTransaccion tipoDeTransaccion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoDeTransaccion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoDeTransaccion);
        }

        // GET: TipoDeTransaccions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoDeTransaccion = await _context.TipoDeTransaccion.FindAsync(id);
            if (tipoDeTransaccion == null)
            {
                return NotFound();
            }
            return View(tipoDeTransaccion);
        }

        // POST: TipoDeTransaccions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TipoDeTransaccionID,TransactionTypecode,DescripcionTipoDeTransaccion")] TipoDeTransaccion tipoDeTransaccion)
        {
            if (id != tipoDeTransaccion.TipoDeTransaccionID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoDeTransaccion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoDeTransaccionExists(tipoDeTransaccion.TipoDeTransaccionID))
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
            return View(tipoDeTransaccion);
        }

        // GET: TipoDeTransaccions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoDeTransaccion = await _context.TipoDeTransaccion
                .FirstOrDefaultAsync(m => m.TipoDeTransaccionID == id);
            if (tipoDeTransaccion == null)
            {
                return NotFound();
            }

            return View(tipoDeTransaccion);
        }

        // POST: TipoDeTransaccions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoDeTransaccion = await _context.TipoDeTransaccion.FindAsync(id);
            _context.TipoDeTransaccion.Remove(tipoDeTransaccion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoDeTransaccionExists(int id)
        {
            return _context.TipoDeTransaccion.Any(e => e.TipoDeTransaccionID == id);
        }
    }
}
