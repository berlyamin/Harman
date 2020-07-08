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
    public class VentasController : Controller
    {
        private readonly DataContext _context;

        public VentasController(DataContext context)
        {
            _context = context;
        }

        // GET: Ventas
        public async Task<IActionResult> Index()
        {
            var dataContext = _context.Venta.Include(v => v.Cliente).Include(v => v.ModoDePago).Include(v => v.TipoDeTransaccion).Include(v => v.Vendedor);
            return View(await dataContext.ToListAsync());
        }

        // GET: Ventas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venta = await _context.Venta
                .Include(v => v.Cliente)
                .Include(v => v.ModoDePago)
                .Include(v => v.TipoDeTransaccion)
                .Include(v => v.Vendedor)
                .FirstOrDefaultAsync(m => m.VentaID == id);
            if (venta == null)
            {
                return NotFound();
            }

            return View(venta);
        }

        // GET: Ventas/Create
        public IActionResult Create()
        {
            ViewData["ClienteID"] = new SelectList(_context.Clientes, "Customerid", "CustomerAddress");
            ViewData["ModoDePagoID"] = new SelectList(_context.Set<ModoDePago>(), "PaymentTermsID", "DescripcionModoDePago");
            ViewData["TipoDeTransaccionID"] = new SelectList(_context.Set<TipoDeTransaccion>(), "TipoDeTransaccionID", "DescripcionTipoDeTransaccion");
            ViewData["VendedorID"] = new SelectList(_context.Vendedor, "VendedorID", "DescripcionVendedor");
            return View();
        }

        // POST: Ventas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VentaID,FechaDeVenta,EstadoDeVenta,ClienteID,VendedorID,ModoDePagoID,TipoDeTransaccionID,NcfId")] Venta venta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(venta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteID"] = new SelectList(_context.Clientes, "Customerid", "CustomerAddress", venta.ClienteID);
            ViewData["ModoDePagoID"] = new SelectList(_context.Set<ModoDePago>(), "PaymentTermsID", "DescripcionModoDePago", venta.ModoDePagoID);
            ViewData["TipoDeTransaccionID"] = new SelectList(_context.Set<TipoDeTransaccion>(), "TipoDeTransaccionID", "DescripcionTipoDeTransaccion", venta.TipoDeTransaccionID);
            ViewData["VendedorID"] = new SelectList(_context.Vendedor, "VendedorID", "DescripcionVendedor", venta.VendedorID);
            return View(venta);
        }

        // GET: Ventas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venta = await _context.Venta.FindAsync(id);
            if (venta == null)
            {
                return NotFound();
            }
            ViewData["ClienteID"] = new SelectList(_context.Clientes, "Customerid", "CustomerAddress", venta.ClienteID);
            ViewData["ModoDePagoID"] = new SelectList(_context.Set<ModoDePago>(), "PaymentTermsID", "DescripcionModoDePago", venta.ModoDePagoID);
            ViewData["TipoDeTransaccionID"] = new SelectList(_context.Set<TipoDeTransaccion>(), "TipoDeTransaccionID", "DescripcionTipoDeTransaccion", venta.TipoDeTransaccionID);
            ViewData["VendedorID"] = new SelectList(_context.Vendedor, "VendedorID", "DescripcionVendedor", venta.VendedorID);
            return View(venta);
        }

        // POST: Ventas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VentaID,FechaDeVenta,EstadoDeVenta,ClienteID,VendedorID,ModoDePagoID,TipoDeTransaccionID,NcfId")] Venta venta)
        {
            if (id != venta.VentaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(venta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VentaExists(venta.VentaID))
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
            ViewData["ClienteID"] = new SelectList(_context.Clientes, "Customerid", "CustomerAddress", venta.ClienteID);
            ViewData["ModoDePagoID"] = new SelectList(_context.Set<ModoDePago>(), "PaymentTermsID", "DescripcionModoDePago", venta.ModoDePagoID);
            ViewData["TipoDeTransaccionID"] = new SelectList(_context.Set<TipoDeTransaccion>(), "TipoDeTransaccionID", "DescripcionTipoDeTransaccion", venta.TipoDeTransaccionID);
            ViewData["VendedorID"] = new SelectList(_context.Vendedor, "VendedorID", "DescripcionVendedor", venta.VendedorID);
            return View(venta);
        }

        // GET: Ventas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venta = await _context.Venta
                .Include(v => v.Cliente)
                .Include(v => v.ModoDePago)
                .Include(v => v.TipoDeTransaccion)
                .Include(v => v.Vendedor)
                .FirstOrDefaultAsync(m => m.VentaID == id);
            if (venta == null)
            {
                return NotFound();
            }

            return View(venta);
        }

        // POST: Ventas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var venta = await _context.Venta.FindAsync(id);
            _context.Venta.Remove(venta);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VentaExists(int id)
        {
            return _context.Venta.Any(e => e.VentaID == id);
        }
    }
}
