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
    public class ClasificacionDeProductoesController : Controller
    {
        private readonly DataContext _context;

        public ClasificacionDeProductoesController(DataContext context)
        {
            _context = context;
        }

        // GET: ClasificacionDeProductoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.ClasificacionDeProducto.ToListAsync());
        }

        // GET: ClasificacionDeProductoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clasificacionDeProducto = await _context.ClasificacionDeProducto
                .FirstOrDefaultAsync(m => m.ClasificacionDeProductoID == id);
            if (clasificacionDeProducto == null)
            {
                return NotFound();
            }

            return View(clasificacionDeProducto);
        }

        // GET: ClasificacionDeProductoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ClasificacionDeProductoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClasificacionDeProductoID,CodigoClasificacionDeProducto,NombreClasificacionDeProducto")] ClasificacionDeProducto clasificacionDeProducto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clasificacionDeProducto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(clasificacionDeProducto);
        }

        // GET: ClasificacionDeProductoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clasificacionDeProducto = await _context.ClasificacionDeProducto.FindAsync(id);
            if (clasificacionDeProducto == null)
            {
                return NotFound();
            }
            return View(clasificacionDeProducto);
        }

        // POST: ClasificacionDeProductoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClasificacionDeProductoID,CodigoClasificacionDeProducto,NombreClasificacionDeProducto")] ClasificacionDeProducto clasificacionDeProducto)
        {
            if (id != clasificacionDeProducto.ClasificacionDeProductoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clasificacionDeProducto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClasificacionDeProductoExists(clasificacionDeProducto.ClasificacionDeProductoID))
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
            return View(clasificacionDeProducto);
        }

        // GET: ClasificacionDeProductoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clasificacionDeProducto = await _context.ClasificacionDeProducto
                .FirstOrDefaultAsync(m => m.ClasificacionDeProductoID == id);
            if (clasificacionDeProducto == null)
            {
                return NotFound();
            }

            return View(clasificacionDeProducto);
        }

        // POST: ClasificacionDeProductoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clasificacionDeProducto = await _context.ClasificacionDeProducto.FindAsync(id);
            _context.ClasificacionDeProducto.Remove(clasificacionDeProducto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClasificacionDeProductoExists(int id)
        {
            return _context.ClasificacionDeProducto.Any(e => e.ClasificacionDeProductoID == id);
        }
    }
}
