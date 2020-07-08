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
    public class Tipo_De_SuplidorController : Controller
    {
        private readonly DataContext _context;

        public Tipo_De_SuplidorController(DataContext context)
        {
            _context = context;
        }

        // GET: Tipo_De_Suplidor
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tipo_De_Suplidor.ToListAsync());
        }

        // GET: Tipo_De_Suplidor/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipo_De_Suplidor = await _context.Tipo_De_Suplidor
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipo_De_Suplidor == null)
            {
                return NotFound();
            }

            return View(tipo_De_Suplidor);
        }

        // GET: Tipo_De_Suplidor/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tipo_De_Suplidor/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Tipo_De_Suplidor tipo_De_Suplidor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipo_De_Suplidor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipo_De_Suplidor);
        }

        // GET: Tipo_De_Suplidor/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipo_De_Suplidor = await _context.Tipo_De_Suplidor.FindAsync(id);
            if (tipo_De_Suplidor == null)
            {
                return NotFound();
            }
            return View(tipo_De_Suplidor);
        }

        // POST: Tipo_De_Suplidor/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Tipo_De_Suplidor tipo_De_Suplidor)
        {
            if (id != tipo_De_Suplidor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipo_De_Suplidor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Tipo_De_SuplidorExists(tipo_De_Suplidor.Id))
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
            return View(tipo_De_Suplidor);
        }

        // GET: Tipo_De_Suplidor/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipo_De_Suplidor = await _context.Tipo_De_Suplidor
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipo_De_Suplidor == null)
            {
                return NotFound();
            }

            return View(tipo_De_Suplidor);
        }

        // POST: Tipo_De_Suplidor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipo_De_Suplidor = await _context.Tipo_De_Suplidor.FindAsync(id);
            _context.Tipo_De_Suplidor.Remove(tipo_De_Suplidor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Tipo_De_SuplidorExists(int id)
        {
            return _context.Tipo_De_Suplidor.Any(e => e.Id == id);
        }
    }
}
