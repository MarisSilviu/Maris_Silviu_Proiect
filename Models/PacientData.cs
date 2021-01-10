using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Maris_Silviu_Proiect.Models
{
    public class PacientData
    {
        public IEnumerable<Pacient> Pacienti { get; set; }
        public IEnumerable<Sectie> Sectii { get; set; }
        public IEnumerable<SectiePacient> SectiePacienti { get; set; }
    }
}
