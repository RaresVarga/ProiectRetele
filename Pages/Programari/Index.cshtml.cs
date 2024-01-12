using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProiectRetele.Data;
using ProiectRetele.Models;

namespace ProiectRetele.Pages.Programari
{
    public class IndexModel : PageModel
    {
        private readonly ProiectRetele.Data.ProiectReteleContext _context;

        public IndexModel(ProiectRetele.Data.ProiectReteleContext context)
        {
            _context = context;
        }

        public IList<Programare> Programare { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Programare != null)
            {
                Programare = await _context.Programare
                    .Include(b => b.Masina)
                    .Include(f => f.Mecanic)
                    .ToListAsync();
            }

        }
    }
}
