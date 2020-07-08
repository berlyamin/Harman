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
    public class ModoDePagoesController : Controller
    {
        private readonly DataContext _context;

        public ModoDePagoesController(DataContext context)
        {
            _context = context;
        }

        // GET: ModoDePagoes
        public async Task<IActionResult> Index()
        {
            var dataContext = _context.ModoDePago.Include(m => m.Estado);
            return View(await dataContext.ToListAsync());
        }

        // GET: ModoDePagoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modoDePago = await _context.ModoDePago
                .Include(m => m.Estado)
                .FirstOrDefaultAsync(m => m.PaymentTermsID == id);
            if (modoDePago == null)
            {
                return NotFound();
            }

            return View(modoDePago);
        }

        // GET: ModoDePagoes/Create
        public IActionResult Create()
        {
            ViewData["EstadoID"] = new SelectList(_context.Estado, "EstadoID", "StatusCode");
            return View();
        }

        // POST: ModoDePagoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PaymentTermsID,DescripcionModoDePago,EstadoID")] ModoDePago modoDePago)
        {
            if (ModelState.IsValid)
            {
                _context.Add(modoDePago);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EstadoID"] = new SelectList(_context.Estado, "EstadoID", "StatusCode", modoDePago.EstadoID);
            return View(modoDePago);
        }

        // GET: ModoDePagoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modoDePago = await _context.ModoDePago.FindAsync(id);
            if (modoDePago == null)
            {
                return NotFound();
            }
            ViewData["EstadoID"] = new SelectList(_context.Estado, "EstadoID", "StatusCode", modoDePago.EstadoID);
            return View(modoDePago);
        }

        // POST: ModoDePagoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PaymentTermsID,DescripcionModoDePago,EstadoID")] ModoDePago modoDePago)
        {
            if (id != modoDePago.PaymentTermsID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(modoDePago);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ModoDePagoExists(modoDePago.PaymentTermsID))
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
            ViewData["EstadoID"] = new SelectList(_context.Estado, "EstadoID", "StatusCode", modoDePago.EstadoID);
            return View(modoDePago);
        }

        // GET: ModoDePagoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modoDePago = await _context.ModoDePago
                .Include(m => m.Estado)
                .FirstOrDefaultAsync(m => m.PaymentTermsID == id);
            if (modoDePago == null)
            {
                return NotFound();
            }

            return View(modoDePago);
        }

        // POST: ModoDePagoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var modoDePago = await _context.ModoDePago.FindAsync(id);
            _context.ModoDePago.Remove(modoDePago);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ModoDePagoExists(int id)
        {
            return _context.ModoDePago.Any(e => e.PaymentTermsID == id);
        }
    }
}
