using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProiectRetele.Data;
using ProiectRetele.Models;

namespace ProiectRetele.Pages.Mecanici
{
    public class IndexModel : PageModel
    {
        private readonly ProiectRetele.Data.ProiectReteleContext _context;

        public IndexModel(ProiectRetele.Data.ProiectReteleContext context)
        {
            _context = context;
        }

        public IList<Mecanic> Mecanic { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Mecanic != null)
            {
                Mecanic = await _context.Mecanic.ToListAsync();
            }
        }
    }
}
