﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Maris_Silviu_Proiect.Data;
using Maris_Silviu_Proiect.Models;

namespace Maris_Silviu_Proiect.Pages.Medici
{
    public class DetailsModel : PageModel
    {
        private readonly Maris_Silviu_Proiect.Data.Maris_Silviu_ProiectContext _context;

        public DetailsModel(Maris_Silviu_Proiect.Data.Maris_Silviu_ProiectContext context)
        {
            _context = context;
        }

        public Medic Medic { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Medic = await _context.Medic.FirstOrDefaultAsync(m => m.ID == id);

            if (Medic == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
