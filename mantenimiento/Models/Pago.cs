using mantenimiento.Models;

public class Pago
{
    public int IdPago { get; set; } 
    public int IdOrden { get; set; }
    public DateTime? FechaPago { get; set; }
    public decimal? Monto { get; set; }
    public string? MetodoPago { get; set; }
    public string? EstadoPago { get; set; } = "pendiente";

    public Orden? Orden { get; set; }
}
