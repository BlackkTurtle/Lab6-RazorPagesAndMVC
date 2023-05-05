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

namespace _01_RazorPages.Pages.Table1Pages
{
    public class EditModel : PageModel
    {
        private readonly _01_RazorPages.Data.TablesContext _context;

        public EditModel(_01_RazorPages.Data.TablesContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Table1 Table1 { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.table1s == null)
            {
                return NotFound();
            }

            var table1 =  await _context.table1s.FirstOrDefaultAsync(m => m.Id == id);
            if (table1 == null)
            {
                return NotFound();
            }
            Table1 = table1;
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

            _context.Attach(Table1).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Table1Exists(Table1.Id))
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

        private bool Table1Exists(int id)
        {
          return (_context.table1s?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
