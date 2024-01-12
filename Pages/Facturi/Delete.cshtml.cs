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
    public class DeleteModel : PageModel
    {
        private readonly ProiectRetele.Data.ProiectReteleContext _context;

        public DeleteModel(ProiectRetele.Data.ProiectReteleContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Factura Factura { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Factura == null)
            {
                return NotFound();
            }

            var factura = await _context.Factura
                .Include(f => f.Programare)
                .FirstOrDefaultAsync(m => m.ID == id);

            if (factura == null)
            {
                return NotFound();
            }
            else 
            {
                Factura = factura;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Factura == null)
            {
                return NotFound();
            }
            var factura = await _context.Factura.FindAsync(id);

            if (factura != null)
            {
                Factura = factura;
                _context.Factura.Remove(Factura);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
