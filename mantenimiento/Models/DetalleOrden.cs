namespace mantenimiento.Models
{
    public class DetalleOrden
    {
        public int IdDetalleOrden { get; set; }
        public int IdOrden { get; set; }
        public int IdServicio { get; set; }
        public decimal? Precios { get; set; }
        public string? Observaciones { get; set; }

        public Orden Orden { get; set; }
        public Servicio Servicio { get; set; }
    }
}
