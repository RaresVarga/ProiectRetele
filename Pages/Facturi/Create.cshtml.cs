using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProiectRetele.Data;
using ProiectRetele.Models;

namespace ProiectRetele.Pages.Facturi
{
    public class CreateModel : PageModel
    {
        private readonly ProiectRetele.Data.ProiectReteleContext _context;

        public CreateModel(ProiectRetele.Data.ProiectReteleContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Factura Factura { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Factura == null || Factura == null)
            {
                return Page();
            }

            _context.Factura.Add(Factura);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
