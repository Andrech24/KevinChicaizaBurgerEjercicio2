using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using KevinChicaizaBurgerEjercicio2.Models;

namespace KevinChicaizaBurgerEjercicio2.Data
{
    public class KevinChicaizaBurgerEjercicio2Context : DbContext
    {
        public KevinChicaizaBurgerEjercicio2Context (DbContextOptions<KevinChicaizaBurgerEjercicio2Context> options)
            : base(options)
        {
        }

        public DbSet<KevinChicaizaBurgerEjercicio2.Models.Burger> Burger { get; set; } = default!;
        public DbSet<KevinChicaizaBurgerEjercicio2.Models.Promo> Promo { get; set; } = default!;
    }
}
