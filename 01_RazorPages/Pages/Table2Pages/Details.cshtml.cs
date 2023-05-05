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
    public class DetailsModel : PageModel
    {
        private readonly _01_RazorPages.Data.TablesContext _context;

        public DetailsModel(_01_RazorPages.Data.TablesContext context)
        {
            _context = context;
        }

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
    }
}
