using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using _01_RazorPages.Data;
using _01_RazorPages.Data.Models;

namespace _01_RazorPages.Pages.Table2Pages
{
    public class CreateModel : PageModel
    {
        private readonly _01_RazorPages.Data.TablesContext _context;

        public CreateModel(_01_RazorPages.Data.TablesContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["Table1Id"] = new SelectList(_context.table1s, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Table2 Table2 { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.table2s == null || Table2 == null)
            {
                return Page();
            }

            _context.table2s.Add(Table2);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
