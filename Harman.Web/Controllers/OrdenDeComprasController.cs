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
    public class OrdenDeComprasController : Controller
    {
        private readonly DataContext _context;

        public OrdenDeComprasController(DataContext context)
        {
            _context = context;
        }

        // GET: OrdenDeCompras
        public async Task<IActionResult> Index()
        {
            var dataContext = _context.OrdenDeCompra.Include(o => o.ModoDePago).Include(o => o.Suplidor);
            return View(await dataContext.ToListAsync());
        }

        // GET: OrdenDeCompras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ordenDeCompra = await _context.OrdenDeCompra
                .Include(o => o.ModoDePago)
                .Include(o => o.Suplidor)
                .FirstOrDefaultAsync(m => m.OrdenDeCompraID == id);
            if (ordenDeCompra == null)
            {
                return NotFound();
            }

            return View(ordenDeCompra);
        }

        // GET: OrdenDeCompras/Create
        public IActionResult Create()
        {
            ViewData["PaymentTermsID"] = new SelectList(_context.Set<ModoDePago>(), "PaymentTermsID", "DescripcionModoDePago");
            ViewData["SuplidorID"] = new SelectList(_context.Suplidor, "SupplidorID", "SupplierAddress");
            return View();
        }

        // POST: OrdenDeCompras/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrdenDeCompraID,SuplidorID,PaymentTermsID,ShipmentTermsID,PurchaseOrderDate,EstadoOrdenDeCompra,Remarks")] OrdenDeCompra ordenDeCompra)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ordenDeCompra);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PaymentTermsID"] = new SelectList(_context.Set<ModoDePago>(), "PaymentTermsID", "DescripcionModoDePago", ordenDeCompra.PaymentTermsID);
            ViewData["SuplidorID"] = new SelectList(_context.Suplidor, "SupplidorID", "SupplierAddress", ordenDeCompra.SuplidorID);
            return View(ordenDeCompra);
        }

        // GET: OrdenDeCompras/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ordenDeCompra = await _context.OrdenDeCompra.FindAsync(id);
            if (ordenDeCompra == null)
            {
                return NotFound();
            }
            ViewData["PaymentTermsID"] = new SelectList(_context.Set<ModoDePago>(), "PaymentTermsID", "DescripcionModoDePago", ordenDeCompra.PaymentTermsID);
            ViewData["SuplidorID"] = new SelectList(_context.Suplidor, "SupplidorID", "SupplierAddress", ordenDeCompra.SuplidorID);
            return View(ordenDeCompra);
        }

        // POST: OrdenDeCompras/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrdenDeCompraID,SuplidorID,PaymentTermsID,ShipmentTermsID,PurchaseOrderDate,EstadoOrdenDeCompra,Remarks")] OrdenDeCompra ordenDeCompra)
        {
            if (id != ordenDeCompra.OrdenDeCompraID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ordenDeCompra);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrdenDeCompraExists(ordenDeCompra.OrdenDeCompraID))
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
            ViewData["PaymentTermsID"] = new SelectList(_context.Set<ModoDePago>(), "PaymentTermsID", "DescripcionModoDePago", ordenDeCompra.PaymentTermsID);
            ViewData["SuplidorID"] = new SelectList(_context.Suplidor, "SupplidorID", "SupplierAddress", ordenDeCompra.SuplidorID);
            return View(ordenDeCompra);
        }

        // GET: OrdenDeCompras/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ordenDeCompra = await _context.OrdenDeCompra
                .Include(o => o.ModoDePago)
                .Include(o => o.Suplidor)
                .FirstOrDefaultAsync(m => m.OrdenDeCompraID == id);
            if (ordenDeCompra == null)
            {
                return NotFound();
            }

            return View(ordenDeCompra);
        }

        // POST: OrdenDeCompras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ordenDeCompra = await _context.OrdenDeCompra.FindAsync(id);
            _context.OrdenDeCompra.Remove(ordenDeCompra);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrdenDeCompraExists(int id)
        {
            return _context.OrdenDeCompra.Any(e => e.OrdenDeCompraID == id);
        }
    }
}
