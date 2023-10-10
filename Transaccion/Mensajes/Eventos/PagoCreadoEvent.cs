using Aforo255.Cross.Event.Src.Events;

namespace Factura.Mensajes.Eventos;

public class PagoCreadoEvent : Event
{
    public PagoCreadoEvent(int idPago, int idFactura, decimal monto, DateTime? fecha)
    {
        IdPago = idPago;
        IdFactura = idFactura;
        Monto = monto;
        Fecha = fecha;
    }

    public int IdPago { get; set; }
    public int IdFactura { get; set; }
    public decimal Monto { get; set; }
    public DateTime? Fecha { get; set; }
}
