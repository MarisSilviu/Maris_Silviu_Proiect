using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Maris_Silviu_Proiect.Models
{
    public class Pacient
    {
        public int ID { get; set; }
        [RegularExpression(@"^[A-Z][a-z]+\s[A-Z][a-z]+$", ErrorMessage = "Numele pacientului trebuie sa fie de forma 'Prenume Nume'"), Required, StringLength(50, MinimumLength = 3)]

        public string Nume { get; set; }
        [Required, Range(1, 100)]

        public int Salon { get; set; }
        public string Diagnostic { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Data Internarii")]
        public DateTime DataInternare { get; set; }
        public int MedicID { get; set; }

        public Medic Medic { get; set; }
        [Display(Name = "Sectie")]
        public ICollection<SectiePacient> SectiePacienti { get; set; }
    }
}
