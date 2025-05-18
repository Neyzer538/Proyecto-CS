namespace mantenimiento.Models
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string NombreCompleto { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public string? Correo { get; set; }
        public string Direccion { get; set; } = null!;
        public DateTime FechaRegistro { get; set; }

        public List<Vehiculo>? Vehiculos { get; set; }
    }

}
