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
    public class DetallesDeVentasController : Controller
    {
        private readonly DataContext _context;

        public DetallesDeVentasController(DataContext context)
        {
            _context = context;
        }

        // GET: DetallesDeVentas
        public async Task<IActionResult> Index()
        {
            var dataContext = _context.DetallesDeVenta.Include(d => d.Producto).Include(d => d.Venta);
            return View(await dataContext.ToListAsync());
        }

        // GET: DetallesDeVentas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detallesDeVenta = await _context.DetallesDeVenta
                .Include(d => d.Producto)
                .Include(d => d.Venta)
                .FirstOrDefaultAsync(m => m.DetallesDeVentaID == id);
            if (detallesDeVenta == null)
            {
                return NotFound();
            }

            return View(detallesDeVenta);
        }

        // GET: DetallesDeVentas/Create
        public IActionResult Create()
        {
            ViewData["ProductoID"] = new SelectList(_context.Set<Producto>(), "ProductoID", "ArticleCode");
            ViewData["VentaID"] = new SelectList(_context.Set<Venta>(), "VentaID", "VentaID");
            return View();
        }

        // POST: DetallesDeVentas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DetallesDeVentaID,VentaID,ProductoID,Descripcion,price,Quantity,discountamount")] DetallesDeVenta detallesDeVenta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(detallesDeVenta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductoID"] = new SelectList(_context.Set<Producto>(), "ProductoID", "ArticleCode", detallesDeVenta.ProductoID);
            ViewData["VentaID"] = new SelectList(_context.Set<Venta>(), "VentaID", "VentaID", detallesDeVenta.VentaID);
            return View(detallesDeVenta);
        }

        // GET: DetallesDeVentas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detallesDeVenta = await _context.DetallesDeVenta.FindAsync(id);
            if (detallesDeVenta == null)
            {
                return NotFound();
            }
            ViewData["ProductoID"] = new SelectList(_context.Set<Producto>(), "ProductoID", "ArticleCode", detallesDeVenta.ProductoID);
            ViewData["VentaID"] = new SelectList(_context.Set<Venta>(), "VentaID", "VentaID", detallesDeVenta.VentaID);
            return View(detallesDeVenta);
        }

        // POST: DetallesDeVentas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DetallesDeVentaID,VentaID,ProductoID,Descripcion,price,Quantity,discountamount")] DetallesDeVenta detallesDeVenta)
        {
            if (id != detallesDeVenta.DetallesDeVentaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(detallesDeVenta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DetallesDeVentaExists(detallesDeVenta.DetallesDeVentaID))
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
            ViewData["ProductoID"] = new SelectList(_context.Set<Producto>(), "ProductoID", "ArticleCode", detallesDeVenta.ProductoID);
            ViewData["VentaID"] = new SelectList(_context.Set<Venta>(), "VentaID", "VentaID", detallesDeVenta.VentaID);
            return View(detallesDeVenta);
        }

        // GET: DetallesDeVentas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detallesDeVenta = await _context.DetallesDeVenta
                .Include(d => d.Producto)
                .Include(d => d.Venta)
                .FirstOrDefaultAsync(m => m.DetallesDeVentaID == id);
            if (detallesDeVenta == null)
            {
                return NotFound();
            }

            return View(detallesDeVenta);
        }

        // POST: DetallesDeVentas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var detallesDeVenta = await _context.DetallesDeVenta.FindAsync(id);
            _context.DetallesDeVenta.Remove(detallesDeVenta);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DetallesDeVentaExists(int id)
        {
            return _context.DetallesDeVenta.Any(e => e.DetallesDeVentaID == id);
        }
    }
}
