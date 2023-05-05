using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using _01_RazorPages.Data;
using _01_RazorPages.Data.Models;

namespace _01_RazorPages.Pages.Table2Pages
{
    public class DeleteModel : PageModel
    {
        private readonly _01_RazorPages.Data.TablesContext _context;

        public DeleteModel(_01_RazorPages.Data.TablesContext context)
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

            var table2 = await _context.table2s.FirstOrDefaultAsync(m => m.Id == id);

            if (table2 == null)
            {
                return NotFound();
            }
            else 
            {
                Table2 = table2;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.table2s == null)
            {
                return NotFound();
            }
            var table2 = await _context.table2s.FindAsync(id);

            if (table2 != null)
            {
                Table2 = table2;
                _context.table2s.Remove(Table2);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
