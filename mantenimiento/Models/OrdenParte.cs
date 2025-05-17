namespace mantenimiento.Models
{
    public class OrdenParte
    {
        public int IdOrdenParte { get; set; }
        public int IdOrden { get; set; }
        public int IdParte { get; set; }
        public int? Cantidad { get; set; }
        public decimal? PrecioTotal { get; set; }

        public Orden Orden { get; set; }
        public Parte Parte { get; set; }
    }

}
