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
    public class IndexModel : PageModel
    {
        private readonly _01_RazorPages.Data.TablesContext _context;

        public IndexModel(_01_RazorPages.Data.TablesContext context)
        {
            _context = context;
        }

        public IList<Table1> Table1 { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.table1s != null)
            {
                Table1 = await _context.table1s.ToListAsync();
            }
        }
    }
}
