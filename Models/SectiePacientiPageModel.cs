using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Maris_Silviu_Proiect.Data;


namespace Maris_Silviu_Proiect.Models
{
    public class SectiePacientiPageModel : PageModel
    {
        public List<AssignedSectieData> AssignedSectieDataList;
        public void PopulateAssignedSectieData(Maris_Silviu_ProiectContext context, Pacient pacient)
        {
            var allSectii = context.Sectie;
            var sectiePacienti = new HashSet<int>(
            pacient.SectiePacienti.Select(c => c.PacientID));
            AssignedSectieDataList = new List<AssignedSectieData>();
            foreach (var cat in allSectii)
            {
                AssignedSectieDataList.Add(new AssignedSectieData
                {
                    SectieID = cat.ID,
                    Name = cat.SectieName,
                    Assigned = sectiePacienti.Contains(cat.ID)
                });
            }
        }
        public void UpdateSectiePacienti(Maris_Silviu_ProiectContext context, string[] selectedSectii, Pacient pacientToUpdate)
        {
            if (selectedSectii == null)
            {
                pacientToUpdate.SectiePacienti = new List<SectiePacient>();
                return;
            }
            var selectedSectiiHS = new HashSet<string>(selectedSectii);
            var sectiePacienti = new HashSet<int>
            (pacientToUpdate.SectiePacienti.Select(c => c.Sectie.ID));
            foreach (var cat in context.Sectie)
            {
                if (selectedSectiiHS.Contains(cat.ID.ToString()))
                {
                    if (!sectiePacienti.Contains(cat.ID))
                    {
                        pacientToUpdate.SectiePacienti.Add(
                        new SectiePacient
                        {
                            PacientID = pacientToUpdate.ID,
                            SectieID = cat.ID
                        });
                    }
                }
                else
                {
                    if (sectiePacienti.Contains(cat.ID))
                    {
                        SectiePacient courseToRemove
                        = pacientToUpdate
                        .SectiePacienti
                        .SingleOrDefault(i => i.SectieID == cat.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }
    }
}
