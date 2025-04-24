namespace mantenimiento.Models
{
    public class Parte
    {
        public int Id { get; set; }
        public string NombreParte { get; set; } = null!;
        public string? Descripcion { get; set; }
        public int? Stock { get; set; } = 0;
        public decimal? PrecioUnitario { get; set; }
    }

}
