using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProiectRetele.Data;
using ProiectRetele.Models;

namespace ProiectRetele.Pages.Programari
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
            ViewData["ID_Masina"] = new SelectList(_context.Set<Masina>(), "ID", "NumarInmatriculare");
            ViewData["ID_Mecanic"] = new SelectList(_context.Set<Mecanic>(), "ID", "Nume");

            return Page();
        }

        [BindProperty]
        public Programare Programare { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Programare == null || Programare == null)
            {
                return Page();
            }

            var masina = await _context.Masina.FirstOrDefaultAsync(m => m.ID == Programare.ID_Masina);
            if (masina == null)
            {
                ModelState.AddModelError("Programare.ID_Masina", "Numărul de înmatriculare al mașinii nu este valid.");
                ViewData["ID_Masina"] = new SelectList(_context.Set<Masina>(), "ID", "NumarInmatriculare");
                return Page();
            }
            Programare.Masina = masina;

            var mecanic = await _context.Mecanic.FirstOrDefaultAsync(m => m.ID == Programare.ID_Mecanic);
            if (mecanic == null)
            {
                ModelState.AddModelError("Programare.ID_Mecanic", "Mecanicul nu este valid.");
                ViewData["ID_Masina"] = new SelectList(_context.Set<Masina>(), "ID", "NumarInmatriculare");
                ViewData["ID_Mecanic"] = new SelectList(_context.Set<Mecanic>(), "ID", "Nume");
                return Page();
            }
            Programare.Mecanic = mecanic;

            _context.Programare.Add(Programare);
            await _context.SaveChangesAsync();


            return RedirectToPage("./Index");
        }
    }
}
