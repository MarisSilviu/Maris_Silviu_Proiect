using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Maris_Silviu_Proiect.Models
{
    public class Sectie
    {
        public int ID { get; set; }
        [Display(Name = "Numele Sectiei")]
        public string SectieName { get; set; }
        public ICollection<SectiePacient> SectiePacienti { get; set; }
    }
}
