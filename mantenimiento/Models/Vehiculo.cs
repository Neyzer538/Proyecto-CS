namespace mantenimiento.Models
{
    public class Vehiculo
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public string Marca { get; set; } = null!;
        public string Modelo { get; set; } = null!;
        public int? Anio { get; set; }
        public string Placa { get; set; } = null!;
        public string Color { get; set; } = null!;
        public string? Tipo { get; set; }

        public Usuario Usuario { get; set; }
    }

}
