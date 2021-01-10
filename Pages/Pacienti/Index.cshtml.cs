using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Maris_Silviu_Proiect.Data;
using Maris_Silviu_Proiect.Models;

namespace Maris_Silviu_Proiect.Pages.Pacienti
{
    public class IndexModel : PageModel
    {
        private readonly Maris_Silviu_Proiect.Data.Maris_Silviu_ProiectContext _context;

        public IndexModel(Maris_Silviu_Proiect.Data.Maris_Silviu_ProiectContext context)
        {
            _context = context;
        }

        public IList<Pacient> Pacient { get;set; }
        public PacientData PacientD { get; set; }
        public int PacientID { get; set; }
        public int SectieID { get; set; }

        public async Task OnGetAsync(int? id, int? sectieID)
        {
            PacientD = new PacientData();

            PacientD.Pacienti = await _context.Pacient
            .Include(b => b.Medic)
            .Include(b => b.SectiePacienti)
            .ThenInclude(b => b.Sectie)
            .AsNoTracking()
            .OrderBy(b => b.Nume)
            .ToListAsync();
            if (id != null)
            {
                PacientID = id.Value;
                Pacient pacient = PacientD.Pacienti
                .Where(i => i.ID == id.Value).Single();
                PacientD.Sectii = pacient.SectiePacienti.Select(s => s.Sectie);
            }
        }
    }
}
