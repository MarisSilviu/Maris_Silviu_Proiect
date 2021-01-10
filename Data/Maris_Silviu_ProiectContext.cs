using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Maris_Silviu_Proiect.Models;

namespace Maris_Silviu_Proiect.Data
{
    public class Maris_Silviu_ProiectContext : DbContext
    {
        public Maris_Silviu_ProiectContext (DbContextOptions<Maris_Silviu_ProiectContext> options)
            : base(options)
        {
        }

        public DbSet<Maris_Silviu_Proiect.Models.Pacient> Pacient { get; set; }

        public DbSet<Maris_Silviu_Proiect.Models.Medic> Medic { get; set; }

        public DbSet<Maris_Silviu_Proiect.Models.Sectie> Sectie { get; set; }
    }
}
