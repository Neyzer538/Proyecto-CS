using Microsoft.EntityFrameworkCore;

namespace Mantenimiento_Vehiculos.Models
{
    public class AutomovilesContext:DbContext
    {
        public AutomovilesContext(DbContextOptions<AutomovilesContext> options) 
            :base(options) 
        { 

        }

        public DbSet<Automoviles> Automoviles { get; set; } = null!;
    }
}
