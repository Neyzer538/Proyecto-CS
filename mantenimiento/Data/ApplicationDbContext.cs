using mantenimiento.Models;
using Microsoft.EntityFrameworkCore;

namespace mantenimiento.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Vehiculo> Vehiculos { get; set; }
        public DbSet<Orden> Ordenes { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Servicio> Servicios { get; set; }
        public DbSet<DetalleOrden> DetallesOrdenes { get; set; }
        public DbSet<OrdenParte> OrdenesPartes { get; set; }
        public DbSet<Parte> Partes { get; set; }
        public DbSet<Pago> Pagos { get; set; }
        public DbSet<Rol> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);  // Para no perder la configuración que ya has hecho

            // Configuración de relaciones
            modelBuilder.Entity<Pago>()
    .HasKey(p => p.IdPago);

            // Relación uno a uno entre Orden y Pago
            modelBuilder.Entity<Orden>()
                .HasOne(o => o.Pago)  // Una Orden tiene un Pago
                .WithOne(p => p.Orden) // Un Pago está relacionado con una Orden
                .HasForeignKey<Orden>(o => o.IdPago)  // La clave foránea está en la tabla Orden
                .OnDelete(DeleteBehavior.Restrict);  // Restricción de eliminación (puedes ajustar esto)

            modelBuilder.Entity<Pago>()
                .HasOne(p => p.Orden)
                .WithOne(o => o.Pago)
                .HasForeignKey<Pago>(p => p.IdOrden)  // La clave foránea está en la tabla Pago
                .OnDelete(DeleteBehavior.Cascade);
            // Opcional: Si los nombres de tabla en SQL no coinciden con los nombres de las clases
            modelBuilder.Entity<Usuario>().ToTable("usuarios");
            modelBuilder.Entity<Vehiculo>().ToTable("vehiculos");
            modelBuilder.Entity<Orden>().ToTable("ordenes");
            modelBuilder.Entity<Empleado>().ToTable("empleados");
            modelBuilder.Entity<Servicio>().ToTable("servicios");
            modelBuilder.Entity<DetalleOrden>().ToTable("detalle_ordenes");
            modelBuilder.Entity<OrdenParte>().ToTable("ordenes_partes");
            modelBuilder.Entity<Parte>().ToTable("partes");
            modelBuilder.Entity<Pago>().ToTable("pagos");
            modelBuilder.Entity<Rol>().ToTable("roles");
        }
    }
}
