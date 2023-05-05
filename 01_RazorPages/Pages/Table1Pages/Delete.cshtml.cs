using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using _01_RazorPages.Data;
using _01_RazorPages.Data.Models;

namespace _01_RazorPages.Pages.Table1Pages
{
    public class DeleteModel : PageModel
    {
        private readonly _01_RazorPages.Data.TablesContext _context;

        public DeleteModel(_01_RazorPages.Data.TablesContext context)
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

            var table1 = await _context.table1s.FirstOrDefaultAsync(m => m.Id == id);

            if (table1 == null)
            {
                return NotFound();
            }
            else 
            {
                Table1 = table1;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.table1s == null)
            {
                return NotFound();
            }
            var table1 = await _context.table1s.FindAsync(id);

            if (table1 != null)
            {
                Table1 = table1;
                _context.table1s.Remove(Table1);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
