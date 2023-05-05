using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using _02_MVC.Data;
using _02_MVC.Data.Models;

namespace _02_MVC.Controllers
{
    public class Table2Controller : Controller
    {
        private readonly TablesContext _context;

        public Table2Controller(TablesContext context)
        {
            _context = context;
        }

        // GET: Table2
        public async Task<IActionResult> Index()
        {
            var tablesContext = _context.table2s.Include(t => t.Table1);
            return View(await tablesContext.ToListAsync());
        }

        // GET: Table2/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.table2s == null)
            {
                return NotFound();
            }

            var table2 = await _context.table2s
                .Include(t => t.Table1)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (table2 == null)
            {
                return NotFound();
            }

            return View(table2);
        }

        // GET: Table2/Create
        public IActionResult Create()
        {
            ViewData["Table1Id"] = new SelectList(_context.table1s, "Id", "Id");
            return View();
        }

        // POST: Table2/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Table1Id")] Table2 table2)
        {
            if (ModelState.IsValid)
            {
                _context.Add(table2);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Table1Id"] = new SelectList(_context.table1s, "Id", "Id", table2.Table1Id);
            return View(table2);
        }

        // GET: Table2/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.table2s == null)
            {
                return NotFound();
            }

            var table2 = await _context.table2s.FindAsync(id);
            if (table2 == null)
            {
                return NotFound();
            }
            ViewData["Table1Id"] = new SelectList(_context.table1s, "Id", "Id", table2.Table1Id);
            return View(table2);
        }

        // POST: Table2/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Table1Id")] Table2 table2)
        {
            if (id != table2.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(table2);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Table2Exists(table2.Id))
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
            ViewData["Table1Id"] = new SelectList(_context.table1s, "Id", "Id", table2.Table1Id);
            return View(table2);
        }

        // GET: Table2/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.table2s == null)
            {
                return NotFound();
            }

            var table2 = await _context.table2s
                .Include(t => t.Table1)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (table2 == null)
            {
                return NotFound();
            }

            return View(table2);
        }

        // POST: Table2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.table2s == null)
            {
                return Problem("Entity set 'TablesContext.table2s'  is null.");
            }
            var table2 = await _context.table2s.FindAsync(id);
            if (table2 != null)
            {
                _context.table2s.Remove(table2);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Table2Exists(int id)
        {
          return (_context.table2s?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
