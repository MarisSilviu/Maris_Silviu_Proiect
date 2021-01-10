using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Maris_Silviu_Proiect.Models
{
    public class Medic
    {
        public int ID { get; set; }
        [Display(Name = "Numele Medicului")]
        [RegularExpression(@"^[A-Z][a-z]+\s[A-Z][a-z]+$", ErrorMessage = "Numele medicului trebuie sa fie de forma 'Prenume Nume'"), Required, StringLength(50, MinimumLength = 3)]
        public string MedicName { get; set; }
        [Display(Name = "Specializarea medicului")]
        public string MedicSpecializare { get; set; }
        public ICollection<Pacient> Pacienti { get; set; }
    }
}
