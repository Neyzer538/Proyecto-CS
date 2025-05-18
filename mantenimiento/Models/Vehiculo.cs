using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mantenimiento.Models
{
    public class Vehiculo
    {
        [Key]
        public int IdVehiculo { get; set; }
        public string Marca { get; set; } = null!;
        public string Modelo { get; set; } = null!;
        public int? Anio { get; set; }
        public string Placa { get; set; } = null!;
        public string Color { get; set; } = null!;
        public string? Tipo { get; set; }

        public int IdUsuario { get; set; }
        public Usuario? Usuario { get; set; }
    }

}
