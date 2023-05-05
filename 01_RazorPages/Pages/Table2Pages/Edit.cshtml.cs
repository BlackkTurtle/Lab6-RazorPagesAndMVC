using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using _01_RazorPages.Data;
using _01_RazorPages.Data.Models;

namespace _01_RazorPages.Pages.Table2Pages
{
    public class EditModel : PageModel
    {
        private readonly _01_RazorPages.Data.TablesContext _context;

        public EditModel(_01_RazorPages.Data.TablesContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Table2 Table2 { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.table2s == null)
            {
                return NotFound();
            }

            var table2 =  await _context.table2s.FirstOrDefaultAsync(m => m.Id == id);
            if (table2 == null)
            {
                return NotFound();
            }
            Table2 = table2;
           ViewData["Table1Id"] = new SelectList(_context.table1s, "Id", "Id");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Table2).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Table2Exists(Table2.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool Table2Exists(int id)
        {
          return (_context.table2s?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
