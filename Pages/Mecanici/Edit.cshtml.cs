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

namespace ProiectRetele.Pages.Mecanici
{
    public class EditModel : PageModel
    {
        private readonly ProiectRetele.Data.ProiectReteleContext _context;

        public EditModel(ProiectRetele.Data.ProiectReteleContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Mecanic Mecanic { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Mecanic == null)
            {
                return NotFound();
            }

            var mecanic =  await _context.Mecanic.FirstOrDefaultAsync(m => m.ID == id);
            if (mecanic == null)
            {
                return NotFound();
            }
            Mecanic = mecanic;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Mecanic).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MecanicExists(Mecanic.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool MecanicExists(int id)
        {
          return (_context.Mecanic?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
