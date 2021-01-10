using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Maris_Silviu_Proiect.Data;
using Maris_Silviu_Proiect.Models;

namespace Maris_Silviu_Proiect.Pages.Sectii
{
    public class EditModel : PageModel
    {
        private readonly Maris_Silviu_Proiect.Data.Maris_Silviu_ProiectContext _context;

        public EditModel(Maris_Silviu_Proiect.Data.Maris_Silviu_ProiectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Sectie Sectie { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Sectie = await _context.Sectie.FirstOrDefaultAsync(m => m.ID == id);

            if (Sectie == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Sectie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SectieExists(Sectie.ID))
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

        private bool SectieExists(int id)
        {
            return _context.Sectie.Any(e => e.ID == id);
        }
    }
}
