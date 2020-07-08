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
    public class ModoEnviosController : Controller
    {
        private readonly DataContext _context;

        public ModoEnviosController(DataContext context)
        {
            _context = context;
        }

        // GET: ModoEnvios
        public async Task<IActionResult> Index()
        {
            var dataContext = _context.ModoEnvio.Include(m => m.Estado);
            return View(await dataContext.ToListAsync());
        }

        // GET: ModoEnvios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modoEnvio = await _context.ModoEnvio
                .Include(m => m.Estado)
                .FirstOrDefaultAsync(m => m.ModoEnvioID == id);
            if (modoEnvio == null)
            {
                return NotFound();
            }

            return View(modoEnvio);
        }

        // GET: ModoEnvios/Create
        public IActionResult Create()
        {
            ViewData["EstadoID"] = new SelectList(_context.Estado, "EstadoID", "StatusCode");
            return View();
        }

        // POST: ModoEnvios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ModoEnvioID,DescripcionModoEnvio,EstadoID")] ModoEnvio modoEnvio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(modoEnvio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EstadoID"] = new SelectList(_context.Estado, "EstadoID", "StatusCode", modoEnvio.EstadoID);
            return View(modoEnvio);
        }

        // GET: ModoEnvios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modoEnvio = await _context.ModoEnvio.FindAsync(id);
            if (modoEnvio == null)
            {
                return NotFound();
            }
            ViewData["EstadoID"] = new SelectList(_context.Estado, "EstadoID", "StatusCode", modoEnvio.EstadoID);
            return View(modoEnvio);
        }

        // POST: ModoEnvios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ModoEnvioID,DescripcionModoEnvio,EstadoID")] ModoEnvio modoEnvio)
        {
            if (id != modoEnvio.ModoEnvioID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(modoEnvio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ModoEnvioExists(modoEnvio.ModoEnvioID))
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
            ViewData["EstadoID"] = new SelectList(_context.Estado, "EstadoID", "StatusCode", modoEnvio.EstadoID);
            return View(modoEnvio);
        }

        // GET: ModoEnvios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modoEnvio = await _context.ModoEnvio
                .Include(m => m.Estado)
                .FirstOrDefaultAsync(m => m.ModoEnvioID == id);
            if (modoEnvio == null)
            {
                return NotFound();
            }

            return View(modoEnvio);
        }

        // POST: ModoEnvios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var modoEnvio = await _context.ModoEnvio.FindAsync(id);
            _context.ModoEnvio.Remove(modoEnvio);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ModoEnvioExists(int id)
        {
            return _context.ModoEnvio.Any(e => e.ModoEnvioID == id);
        }
    }
}
