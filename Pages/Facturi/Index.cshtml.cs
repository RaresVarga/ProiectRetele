using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProiectRetele.Data;
using ProiectRetele.Models;

namespace ProiectRetele.Pages.Facturi
{
    public class IndexModel : PageModel
    {
        private readonly ProiectRetele.Data.ProiectReteleContext _context;

        public IndexModel(ProiectRetele.Data.ProiectReteleContext context)
        {
            _context = context;
        }

        public IList<Factura> Factura { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Factura != null)
            {
                Factura = await _context.Factura
                    .Include(b => b.Programare)
                    .ToListAsync();
            }
        }
    }
}
