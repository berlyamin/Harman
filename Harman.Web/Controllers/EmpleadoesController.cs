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
    public class EmpleadoesController : Controller
    {
        private readonly DataContext _context;

        public EmpleadoesController(DataContext context)
        {
            _context = context;
        }

        // GET: Empleadoes
        public async Task<IActionResult> Index()
        {
            var dataContext = _context.Empleado.Include(e => e.Cargo).Include(e => e.Compañia).Include(e => e.Estado).Include(e => e.TipoDocumento).Include(e => e.Vendedor);
            return View(await dataContext.ToListAsync());
        }

        // GET: Empleadoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleado = await _context.Empleado
                .Include(e => e.Cargo)
                .Include(e => e.Compañia)
                .Include(e => e.Estado)
                .Include(e => e.TipoDocumento)
                .Include(e => e.Vendedor)
                .FirstOrDefaultAsync(m => m.EmpleadoID == id);
            if (empleado == null)
            {
                return NotFound();
            }

            return View(empleado);
        }

        // GET: Empleadoes/Create
        public IActionResult Create()
        {
            ViewData["CargoID"] = new SelectList(_context.Cargo, "CargoID", "NombreCargo");
            ViewData["CompañiaID"] = new SelectList(_context.Compañia, "CompañiaID", "CompanyEmail");
            ViewData["EstadoID"] = new SelectList(_context.Set<Estado>(), "EstadoID", "StatusCode");
            ViewData["TipoDocumentoID"] = new SelectList(_context.Set<TipoDocumento>(), "TipoDocumentoID", "DescripcionTipoDocumento");
            ViewData["VendedorID"] = new SelectList(_context.Set<Vendedor>(), "VendedorID", "DescripcionVendedor");
            return View();
        }

        // POST: Empleadoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmpleadoID,EmployeeDateAdd,EmployeeCode,EmployeeName,EmployeeLastName,TipoDocumentoID,EmployeeIDNumber,EmployeePhone,EmployeeCellPhone,EmployeePhoneExtension,EmployeeEmail,EstadoID,CargoID,VendedorID,CompañiaID")] Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(empleado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CargoID"] = new SelectList(_context.Cargo, "CargoID", "NombreCargo", empleado.CargoID);
            ViewData["CompañiaID"] = new SelectList(_context.Compañia, "CompañiaID", "CompanyEmail", empleado.CompañiaID);
            ViewData["EstadoID"] = new SelectList(_context.Set<Estado>(), "EstadoID", "StatusCode", empleado.EstadoID);
            ViewData["TipoDocumentoID"] = new SelectList(_context.Set<TipoDocumento>(), "TipoDocumentoID", "DescripcionTipoDocumento", empleado.TipoDocumentoID);
            ViewData["VendedorID"] = new SelectList(_context.Set<Vendedor>(), "VendedorID", "DescripcionVendedor", empleado.VendedorID);
            return View(empleado);
        }

        // GET: Empleadoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleado = await _context.Empleado.FindAsync(id);
            if (empleado == null)
            {
                return NotFound();
            }
            ViewData["CargoID"] = new SelectList(_context.Cargo, "CargoID", "NombreCargo", empleado.CargoID);
            ViewData["CompañiaID"] = new SelectList(_context.Compañia, "CompañiaID", "CompanyEmail", empleado.CompañiaID);
            ViewData["EstadoID"] = new SelectList(_context.Set<Estado>(), "EstadoID", "StatusCode", empleado.EstadoID);
            ViewData["TipoDocumentoID"] = new SelectList(_context.Set<TipoDocumento>(), "TipoDocumentoID", "DescripcionTipoDocumento", empleado.TipoDocumentoID);
            ViewData["VendedorID"] = new SelectList(_context.Set<Vendedor>(), "VendedorID", "DescripcionVendedor", empleado.VendedorID);
            return View(empleado);
        }

        // POST: Empleadoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmpleadoID,EmployeeDateAdd,EmployeeCode,EmployeeName,EmployeeLastName,TipoDocumentoID,EmployeeIDNumber,EmployeePhone,EmployeeCellPhone,EmployeePhoneExtension,EmployeeEmail,EstadoID,CargoID,VendedorID,CompañiaID")] Empleado empleado)
        {
            if (id != empleado.EmpleadoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(empleado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmpleadoExists(empleado.EmpleadoID))
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
            ViewData["CargoID"] = new SelectList(_context.Cargo, "CargoID", "NombreCargo", empleado.CargoID);
            ViewData["CompañiaID"] = new SelectList(_context.Compañia, "CompañiaID", "CompanyEmail", empleado.CompañiaID);
            ViewData["EstadoID"] = new SelectList(_context.Set<Estado>(), "EstadoID", "StatusCode", empleado.EstadoID);
            ViewData["TipoDocumentoID"] = new SelectList(_context.Set<TipoDocumento>(), "TipoDocumentoID", "DescripcionTipoDocumento", empleado.TipoDocumentoID);
            ViewData["VendedorID"] = new SelectList(_context.Set<Vendedor>(), "VendedorID", "DescripcionVendedor", empleado.VendedorID);
            return View(empleado);
        }

        // GET: Empleadoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleado = await _context.Empleado
                .Include(e => e.Cargo)
                .Include(e => e.Compañia)
                .Include(e => e.Estado)
                .Include(e => e.TipoDocumento)
                .Include(e => e.Vendedor)
                .FirstOrDefaultAsync(m => m.EmpleadoID == id);
            if (empleado == null)
            {
                return NotFound();
            }

            return View(empleado);
        }

        // POST: Empleadoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var empleado = await _context.Empleado.FindAsync(id);
            _context.Empleado.Remove(empleado);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmpleadoExists(int id)
        {
            return _context.Empleado.Any(e => e.EmpleadoID == id);
        }
    }
}
