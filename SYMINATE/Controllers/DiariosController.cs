using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SYMINATE.Models;

namespace SYMINATE.Controllers
{
    public class DiariosController : Controller
    {
        private readonly Contexto _context;

        public DiariosController(Contexto context)
        {
            _context = context;
        }

        // GET: Diarios
        public async Task<IActionResult> Index()
        {
              return View(await _context.Diario.ToListAsync());
        }

        // GET: Diarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Diario == null)
            {
                return NotFound();
            }

            var diario = await _context.Diario
                .FirstOrDefaultAsync(m => m.Id == id);
            if (diario == null)
            {
                return NotFound();
            }

            return View(diario);
        }

        // GET: Diarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Diarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Descricao,Data")] Diario diario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(diario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(diario);
        }

        // GET: Diarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Diario == null)
            {
                return NotFound();
            }

            var diario = await _context.Diario.FindAsync(id);
            if (diario == null)
            {
                return NotFound();
            }
            return View(diario);
        }

        // POST: Diarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Descricao,Data")] Diario diario)
        {
            if (id != diario.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(diario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DiarioExists(diario.Id))
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
            return View(diario);
        }

        // GET: Diarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Diario == null)
            {
                return NotFound();
            }

            var diario = await _context.Diario
                .FirstOrDefaultAsync(m => m.Id == id);
            if (diario == null)
            {
                return NotFound();
            }

            return View(diario);
        }

        // POST: Diarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Diario == null)
            {
                return Problem("Entity set 'Contexto.Diario'  is null.");
            }
            var diario = await _context.Diario.FindAsync(id);
            if (diario != null)
            {
                _context.Diario.Remove(diario);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DiarioExists(int id)
        {
          return _context.Diario.Any(e => e.Id == id);
        }
    }
}
