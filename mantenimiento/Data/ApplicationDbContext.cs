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
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<DetalleOrden>()
                .HasKey(d => d.IdDetalleOrden);

            modelBuilder.Entity<Empleado>()
            .HasKey(e => e.IdEmpleado);

            modelBuilder.Entity<Orden>()
            .HasKey(e => e.IdOrden);
            modelBuilder.Entity<OrdenParte>()
            .HasKey(e => e.IdOrdenParte);

            modelBuilder.Entity<Parte>()
            .HasKey(e => e.IdParte);

            modelBuilder.Entity<Rol>()
            .HasKey(e => e.IdRol);

            modelBuilder.Entity<Servicio>()
            .HasKey(e => e.IdServicio);

            modelBuilder.Entity<Usuario>()
            .HasKey(e => e.IdUsuario);

            modelBuilder.Entity<Vehiculo>()
            .HasOne(v => v.Usuario)
            .WithMany(u => u.Vehiculos)
            .HasForeignKey(v => v.IdUsuario);

            // config de relaciones
            modelBuilder.Entity<Pago>()
            .HasKey(p => p.IdPago);


            modelBuilder.Entity<Pago>()
     .HasOne(p => p.Orden)
     .WithOne(o => o.Pago)
     .HasForeignKey<Pago>(p => p.IdOrden)
     .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Orden>()
    .HasOne(o => o.Vehiculo)
    .WithMany() 
    .HasForeignKey(o => o.IdVehiculo)
    .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Orden>()
    .HasOne(o => o.Empleado)
    .WithMany() 
    .HasForeignKey(o => o.IdEmpleado)
    .OnDelete(DeleteBehavior.Restrict);
            // consistencia con la base de datos
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
