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
    public class TransportistasController : Controller
    {
        private readonly DataContext _context;

        public TransportistasController(DataContext context)
        {
            _context = context;
        }

        // GET: Transportistas
        public async Task<IActionResult> Index()
        {
            var dataContext = _context.Transportista.Include(t => t.Ciudad);
            return View(await dataContext.ToListAsync());
        }

        // GET: Transportistas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transportista = await _context.Transportista
                .Include(t => t.Ciudad)
                .FirstOrDefaultAsync(m => m.CourierID == id);
            if (transportista == null)
            {
                return NotFound();
            }

            return View(transportista);
        }

        // GET: Transportistas/Create
        public IActionResult Create()
        {
            ViewData["CiudadID"] = new SelectList(_context.Ciudad, "CiudadID", "CityName");
            return View();
        }

        // POST: Transportistas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CourierID,CourierCode,CourierName,CourierAccount,CourierAddress,CourierContactName,CourierPhone,CourierCellPhone,CourierStartDate,CourierRemarks,CiudadID")] Transportista transportista)
        {
            if (ModelState.IsValid)
            {
                _context.Add(transportista);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CiudadID"] = new SelectList(_context.Ciudad, "CiudadID", "CityName", transportista.CiudadID);
            return View(transportista);
        }

        // GET: Transportistas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transportista = await _context.Transportista.FindAsync(id);
            if (transportista == null)
            {
                return NotFound();
            }
            ViewData["CiudadID"] = new SelectList(_context.Ciudad, "CiudadID", "CityName", transportista.CiudadID);
            return View(transportista);
        }

        // POST: Transportistas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CourierID,CourierCode,CourierName,CourierAccount,CourierAddress,CourierContactName,CourierPhone,CourierCellPhone,CourierStartDate,CourierRemarks,CiudadID")] Transportista transportista)
        {
            if (id != transportista.CourierID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(transportista);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransportistaExists(transportista.CourierID))
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
            ViewData["CiudadID"] = new SelectList(_context.Ciudad, "CiudadID", "CityName", transportista.CiudadID);
            return View(transportista);
        }

        // GET: Transportistas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transportista = await _context.Transportista
                .Include(t => t.Ciudad)
                .FirstOrDefaultAsync(m => m.CourierID == id);
            if (transportista == null)
            {
                return NotFound();
            }

            return View(transportista);
        }

        // POST: Transportistas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var transportista = await _context.Transportista.FindAsync(id);
            _context.Transportista.Remove(transportista);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TransportistaExists(int id)
        {
            return _context.Transportista.Any(e => e.CourierID == id);
        }
    }
}
