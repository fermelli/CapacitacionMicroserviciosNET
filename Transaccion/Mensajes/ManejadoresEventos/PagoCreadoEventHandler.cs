using Aforo255.Cross.Event.Src.Bus;
using Factura.Mensajes.Eventos;
using Transaccion.Modelos;
using Transaccion.Servicios;

namespace AFORO255.MS.TEST.Transactiones.EventHandlers;

public class PagoCreadoEventHandler : IEventHandler<PagoCreadoEvent>
{
    private readonly ITransaccionService _transaccionService;

    public PagoCreadoEventHandler(ITransaccionService transaccionService)
    {
        _transaccionService = transaccionService;
    }

    public Task Handle(PagoCreadoEvent @event)
    {
        _transaccionService.Agregar(new TransaccionModelo()
        {
            IdTransaccion = @event.IdPago,
            IdFactura = @event.IdFactura,
            Monto = @event.Monto,
            Fecha = DateOnly.FromDateTime(@event.Fecha ?? DateTime.Now)
        });

        return Task.CompletedTask;
    }
}