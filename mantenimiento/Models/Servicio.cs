namespace mantenimiento.Models
{
    public class Servicio
    {
        public int Id { get; set; }
        public string NombreServicio { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public decimal PrecioBase { get; set; }
        public string? DuracionEstimada { get; set; }
    }

}
