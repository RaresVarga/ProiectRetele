﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProiectRetele.Data;
using ProiectRetele.Models;

namespace ProiectRetele.Pages.Masini
{
    public class DeleteModel : PageModel
    {
        private readonly ProiectRetele.Data.ProiectReteleContext _context;

        public DeleteModel(ProiectRetele.Data.ProiectReteleContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Masina Masina { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Masina == null)
            {
                return NotFound();
            }

            var masina = await _context.Masina.FirstOrDefaultAsync(m => m.ID == id);

            if (masina == null)
            {
                return NotFound();
            }
            else 
            {
                Masina = masina;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Masina == null)
            {
                return NotFound();
            }
            var masina = await _context.Masina.FindAsync(id);

            if (masina != null)
            {
                Masina = masina;
                _context.Masina.Remove(Masina);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
