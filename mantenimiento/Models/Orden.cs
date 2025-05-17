namespace mantenimiento.Models
{
    public class Orden
    {
        public int IdOrden { get; set; }
        public int IdVehiculo { get; set; }
        public int IdEmpleado { get; set; }
        public DateTime? FechaIngreso { get; set; }
        public DateTime? FechaSalida { get; set; }
        public string? Estado { get; set; } = "pendiente";
        public string? Observaciones { get; set; }

        public Vehiculo Vehiculo { get; set; }
        public Empleado Empleado { get; set; }
        public List<DetalleOrden> Detalles { get; set; }
        public List<OrdenParte> Partes { get; set; }

        // Clave foránea para la relación con Pago
        public int? IdPago { get; set; }
        public Pago Pago { get; set; }
    }
}
