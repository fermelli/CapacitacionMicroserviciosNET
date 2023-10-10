using Aforo255.Cross.Event.Src.Commands;

namespace Pago.Mensajes.Comandos;

public class CrearPagoCommand : Command
{
    public CrearPagoCommand(int idPago, int idFactura, decimal monto, DateTime? fecha)
    {
        IdPago = idPago;
        IdFactura = idFactura;
        Monto = monto;
        Fecha = fecha;
    }

    public int IdPago { get; protected set; }
    public int IdFactura { get; protected set; }
    public decimal Monto { get; protected set; }
    public DateTime? Fecha { get; protected set; }

}