using Microsoft.EntityFrameworkCore;
using PP_C.Models;

namespace PP_C.DAL
{
    public class Contexto: DbContext
    {
        public Contexto(DbContextOptions<Contexto> options): base(options)
        {
        }
        public DbSet<Productos> Productos { get; set; }
    }
}
