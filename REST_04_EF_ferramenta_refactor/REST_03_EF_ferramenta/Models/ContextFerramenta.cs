using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace REST_03_EF_ferramenta.Models
{
    public class ContextFerramenta : DbContext
    {
       public ContextFerramenta (DbContextOptions<ContextFerramenta> options) : base(options)
        {

        }
        public DbSet<Prodotto> Prodotti { get; set; }
        public DbSet<Reparto> Reparti { get; set; }


    }
}
