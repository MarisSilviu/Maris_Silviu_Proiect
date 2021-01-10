using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Maris_Silviu_Proiect.Data;
using Maris_Silviu_Proiect.Models;

namespace Maris_Silviu_Proiect.Pages.Pacienti
{
    public class CreateModel : SectiePacientiPageModel
    {
        private readonly Maris_Silviu_Proiect.Data.Maris_Silviu_ProiectContext _context;

        public CreateModel(Maris_Silviu_Proiect.Data.Maris_Silviu_ProiectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["MedicID"] = new SelectList(_context.Set<Medic>(), "ID", "MedicName");
            var pacient = new Pacient();
            pacient.SectiePacienti = new List<SectiePacient>();
            PopulateAssignedSectieData(_context, pacient);
            return Page();
        }

        [BindProperty]
        public Pacient Pacient { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(string[] selectedSectii)
        {
            var newPacient = new Pacient();
            if (selectedSectii != null)
            {
                newPacient.SectiePacienti = new List<SectiePacient>();
                foreach (var cat in selectedSectii)
                {
                    var catToAdd = new SectiePacient
                    {
                        SectieID = int.Parse(cat)
                    };
                    newPacient.SectiePacienti.Add(catToAdd);
                }
            }
            if (await TryUpdateModelAsync<Pacient>(
            newPacient,
            "Pacient",
            i => i.Nume, i => i.Salon,
            i => i.Diagnostic, i => i.DataInternare, i => i.MedicID))
            {
                _context.Pacient.Add(newPacient);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateAssignedSectieData(_context, newPacient);
            return Page();
        }
    }
}
