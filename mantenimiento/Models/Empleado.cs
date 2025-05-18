using System.Text.Json.Serialization;

namespace mantenimiento.Models
{
    public class Empleado
    {
        public int IdEmpleado { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string Contrasenia { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public string Correo { get; set; } = null!;
        public DateTime FechaContratacion { get; set; }
        public decimal Salario { get; set; }
        public int IdRol { get; set; }

        public int? RolIdRol { get; set; }
        [JsonIgnore]
        public Rol? Rol { get; set; }
    }

}
