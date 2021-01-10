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

namespace Maris_Silviu_Proiect.Pages.Pacienti
{
    public class EditModel : SectiePacientiPageModel
    {
        private readonly Maris_Silviu_Proiect.Data.Maris_Silviu_ProiectContext _context;

        public EditModel(Maris_Silviu_Proiect.Data.Maris_Silviu_ProiectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Pacient Pacient { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Pacient = await _context.Pacient.Include(b => b.Medic).Include(b => b.SectiePacienti).ThenInclude(b => b.Sectie).AsNoTracking().FirstOrDefaultAsync(m => m.ID == id);

            if (Pacient == null)
            {
                return NotFound();
            }

            PopulateAssignedSectieData(_context, Pacient);

            ViewData["MedicID"] = new SelectList(_context.Set<Medic>(), "ID", "MedicName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedSectii)
        {
            if (id == null)
            {
                return NotFound();
            }
            var pacientToUpdate = await _context.Pacient
            .Include(i => i.Medic)
            .Include(i => i.SectiePacienti)
            .ThenInclude(i => i.Sectie)
            .FirstOrDefaultAsync(s => s.ID == id);
            if (pacientToUpdate == null)
            {
                return NotFound();
            }
            if (await TryUpdateModelAsync<Pacient>(
            pacientToUpdate,
            "Pacient",
            i => i.Nume, i => i.Salon,
            i => i.Diagnostic, i => i.DataInternare, i => i.Medic))
            {
                UpdateSectiePacienti(_context, selectedSectii, pacientToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            
            UpdateSectiePacienti(_context, selectedSectii, pacientToUpdate);
            PopulateAssignedSectieData(_context, pacientToUpdate);
            return Page();
        }

        private bool PacientExists(int id)
        {
            return _context.Pacient.Any(e => e.ID == id);
        }
    }
}
