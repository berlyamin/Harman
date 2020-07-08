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
    public class DetallesOrdenDeComprasController : Controller
    {
        private readonly DataContext _context;

        public DetallesOrdenDeComprasController(DataContext context)
        {
            _context = context;
        }

        // GET: DetallesOrdenDeCompras
        public async Task<IActionResult> Index()
        {
            var dataContext = _context.DetallesOrdenDeCompra.Include(d => d.Producto);
            return View(await dataContext.ToListAsync());
        }

        // GET: DetallesOrdenDeCompras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detallesOrdenDeCompra = await _context.DetallesOrdenDeCompra
                .Include(d => d.Producto)
                .FirstOrDefaultAsync(m => m.DetallesOrdenDeCompraID == id);
            if (detallesOrdenDeCompra == null)
            {
                return NotFound();
            }

            return View(detallesOrdenDeCompra);
        }

        // GET: DetallesOrdenDeCompras/Create
        public IActionResult Create()
        {
            ViewData["ProductoID"] = new SelectList(_context.Set<Producto>(), "ProductoID", "ArticleCode");
            return View();
        }

        // POST: DetallesOrdenDeCompras/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DetallesOrdenDeCompraID,PurchaseOrderID,ProductoID,Cost,Quantity")] DetallesOrdenDeCompra detallesOrdenDeCompra)
        {
            if (ModelState.IsValid)
            {
                _context.Add(detallesOrdenDeCompra);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductoID"] = new SelectList(_context.Set<Producto>(), "ProductoID", "ArticleCode", detallesOrdenDeCompra.ProductoID);
            return View(detallesOrdenDeCompra);
        }

        // GET: DetallesOrdenDeCompras/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detallesOrdenDeCompra = await _context.DetallesOrdenDeCompra.FindAsync(id);
            if (detallesOrdenDeCompra == null)
            {
                return NotFound();
            }
            ViewData["ProductoID"] = new SelectList(_context.Set<Producto>(), "ProductoID", "ArticleCode", detallesOrdenDeCompra.ProductoID);
            return View(detallesOrdenDeCompra);
        }

        // POST: DetallesOrdenDeCompras/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DetallesOrdenDeCompraID,PurchaseOrderID,ProductoID,Cost,Quantity")] DetallesOrdenDeCompra detallesOrdenDeCompra)
        {
            if (id != detallesOrdenDeCompra.DetallesOrdenDeCompraID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(detallesOrdenDeCompra);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DetallesOrdenDeCompraExists(detallesOrdenDeCompra.DetallesOrdenDeCompraID))
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
            ViewData["ProductoID"] = new SelectList(_context.Set<Producto>(), "ProductoID", "ArticleCode", detallesOrdenDeCompra.ProductoID);
            return View(detallesOrdenDeCompra);
        }

        // GET: DetallesOrdenDeCompras/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detallesOrdenDeCompra = await _context.DetallesOrdenDeCompra
                .Include(d => d.Producto)
                .FirstOrDefaultAsync(m => m.DetallesOrdenDeCompraID == id);
            if (detallesOrdenDeCompra == null)
            {
                return NotFound();
            }

            return View(detallesOrdenDeCompra);
        }

        // POST: DetallesOrdenDeCompras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var detallesOrdenDeCompra = await _context.DetallesOrdenDeCompra.FindAsync(id);
            _context.DetallesOrdenDeCompra.Remove(detallesOrdenDeCompra);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DetallesOrdenDeCompraExists(int id)
        {
            return _context.DetallesOrdenDeCompra.Any(e => e.DetallesOrdenDeCompraID == id);
        }
    }
}
