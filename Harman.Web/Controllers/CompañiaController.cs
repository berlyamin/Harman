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
    public class CompañiaController : Controller
    {
        private readonly DataContext _context;

        public CompañiaController(DataContext context)
        {
            _context = context;
        }

        // GET: Compañia
        public async Task<IActionResult> Index()
        {
            var dataContext = _context.Compañia.Include(c => c.Ciudad);
            return View(await dataContext.ToListAsync());
        }

        // GET: Compañia/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var compañia = await _context.Compañia
                .Include(c => c.Ciudad)
                .FirstOrDefaultAsync(m => m.CompañiaID == id);
            if (compañia == null)
            {
                return NotFound();
            }

            return View(compañia);
        }

        // GET: Compañia/Create
        public IActionResult Create()
        {
            ViewData["CiudadID"] = new SelectList(_context.Ciudad, "CiudadID", "CityName");
            return View();
        }

        // POST: Compañia/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CompañiaID,NombreCompañia,DescripcionCompañia,DireccionCompañia,TelefonoCompañia,CompanyEmail,CompanyCreateDate,CiudadID")] Compañia compañia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(compañia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CiudadID"] = new SelectList(_context.Ciudad, "CiudadID", "CityName", compañia.CiudadID);
            return View(compañia);
        }

        // GET: Compañia/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var compañia = await _context.Compañia.FindAsync(id);
            if (compañia == null)
            {
                return NotFound();
            }
            ViewData["CiudadID"] = new SelectList(_context.Ciudad, "CiudadID", "CityName", compañia.CiudadID);
            return View(compañia);
        }

        // POST: Compañia/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CompañiaID,NombreCompañia,DescripcionCompañia,DireccionCompañia,TelefonoCompañia,CompanyEmail,CompanyCreateDate,CiudadID")] Compañia compañia)
        {
            if (id != compañia.CompañiaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(compañia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompañiaExists(compañia.CompañiaID))
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
            ViewData["CiudadID"] = new SelectList(_context.Ciudad, "CiudadID", "CityName", compañia.CiudadID);
            return View(compañia);
        }

        // GET: Compañia/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var compañia = await _context.Compañia
                .Include(c => c.Ciudad)
                .FirstOrDefaultAsync(m => m.CompañiaID == id);
            if (compañia == null)
            {
                return NotFound();
            }

            return View(compañia);
        }

        // POST: Compañia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var compañia = await _context.Compañia.FindAsync(id);
            _context.Compañia.Remove(compañia);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompañiaExists(int id)
        {
            return _context.Compañia.Any(e => e.CompañiaID == id);
        }
    }
}
