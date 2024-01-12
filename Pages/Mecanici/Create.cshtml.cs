using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProiectRetele.Data;
using ProiectRetele.Models;

namespace ProiectRetele.Pages.Mecanici
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
        public Mecanic Mecanic { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Mecanic == null || Mecanic == null)
            {
                return Page();
            }

            _context.Mecanic.Add(Mecanic);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
