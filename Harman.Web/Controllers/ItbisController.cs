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
    public class ItbisController : Controller
    {
        private readonly DataContext _context;

        public ItbisController(DataContext context)
        {
            _context = context;
        }

        // GET: Itbis
        public async Task<IActionResult> Index()
        {
            return View(await _context.Itbis.ToListAsync());
        }

        // GET: Itbis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itbis = await _context.Itbis
                .FirstOrDefaultAsync(m => m.ItbisID == id);
            if (itbis == null)
            {
                return NotFound();
            }

            return View(itbis);
        }

        // GET: Itbis/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Itbis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ItbisID,PorcientoItbis,DescripcionItbis")] Itbis itbis)
        {
            if (ModelState.IsValid)
            {
                _context.Add(itbis);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(itbis);
        }

        // GET: Itbis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itbis = await _context.Itbis.FindAsync(id);
            if (itbis == null)
            {
                return NotFound();
            }
            return View(itbis);
        }

        // POST: Itbis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ItbisID,PorcientoItbis,DescripcionItbis")] Itbis itbis)
        {
            if (id != itbis.ItbisID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(itbis);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItbisExists(itbis.ItbisID))
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
            return View(itbis);
        }

        // GET: Itbis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itbis = await _context.Itbis
                .FirstOrDefaultAsync(m => m.ItbisID == id);
            if (itbis == null)
            {
                return NotFound();
            }

            return View(itbis);
        }

        // POST: Itbis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var itbis = await _context.Itbis.FindAsync(id);
            _context.Itbis.Remove(itbis);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ItbisExists(int id)
        {
            return _context.Itbis.Any(e => e.ItbisID == id);
        }
    }
}
