using Microsoft.EntityFrameworkCore;

namespace SYMINATE.Models
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {

        }

        public DbSet<Exercicios> Exercicios {get; set;}

        public DbSet<Diario> Diario { get; set; }
    }
}
