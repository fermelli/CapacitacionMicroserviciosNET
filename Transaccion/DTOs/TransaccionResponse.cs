namespace Transaccion.DTOs;

public class TransaccionResponse
{
    public int? IdTransaccion { get; set; }
    public int? IdFactura { get; set; }
    public decimal? Monto { get; set; }
    public DateOnly? Fecha { get; set; }
}
