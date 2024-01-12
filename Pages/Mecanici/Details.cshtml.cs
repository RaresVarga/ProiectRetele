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
    public class DetailsModel : PageModel
    {
        private readonly ProiectRetele.Data.ProiectReteleContext _context;

        public DetailsModel(ProiectRetele.Data.ProiectReteleContext context)
        {
            _context = context;
        }

      public Mecanic Mecanic { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Mecanic == null)
            {
                return NotFound();
            }

            var mecanic = await _context.Mecanic.FirstOrDefaultAsync(m => m.ID == id);
            if (mecanic == null)
            {
                return NotFound();
            }
            else 
            {
                Mecanic = mecanic;
            }
            return Page();
        }
    }
}
