using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Maris_Silviu_Proiect.Models
{
    public class SectiePacient
    {
        public int ID { get; set; }
        public int PacientID { get; set; }
        public Pacient Pacient { get; set; }
        public int SectieID { get; set; }
        public Sectie Sectie { get; set; }
    }
}
