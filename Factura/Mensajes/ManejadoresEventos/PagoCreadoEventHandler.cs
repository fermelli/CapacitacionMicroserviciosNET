using Aforo255.Cross.Event.Src.Bus;
using Factura.Mensajes.Eventos;
using Factura.Servicios;

namespace Factura.Mensajes.ManejadoresEventos;

public class PagoCreadoEventHandler : IEventHandler<PagoCreadoEvent>
{
    private readonly IFacturaService _facturaService;

    public PagoCreadoEventHandler(IFacturaService facturaService)
    {
        _facturaService = facturaService;
    }

    public Task Handle(PagoCreadoEvent @event)
    {
        _facturaService.CambiarEstado(@event.IdFactura);

        return Task.CompletedTask;
    }
}
