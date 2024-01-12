using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProiectRetele.Data;
using ProiectRetele.Models;

namespace ProiectRetele.Pages.Masini
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
            ViewData["ID_Client"] = new SelectList(_context.Set<Client>(), "ID", "Nume");
            return Page();
        }

        [BindProperty]
        public Masina Masina { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Masina == null || Masina == null)
            {
                return Page();
            }

            Masina.Client = await _context.Client.FindAsync(Masina.ID_Client);
            _context.Masina.Add(Masina);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
