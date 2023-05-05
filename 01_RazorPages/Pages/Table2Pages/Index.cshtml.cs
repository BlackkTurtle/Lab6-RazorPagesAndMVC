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
    public class IndexModel : PageModel
    {
        private readonly _01_RazorPages.Data.TablesContext _context;

        public IndexModel(_01_RazorPages.Data.TablesContext context)
        {
            _context = context;
        }

        public IList<Table2> Table2 { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.table2s != null)
            {
                Table2 = await _context.table2s.ToListAsync();
            }
        }
    }
}
