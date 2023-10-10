using Aforo255.Cross.Event.Src.Bus;
using MediatR;
using Pago.Mensajes.Comandos;
using Pago.Mensajes.Eventos;

namespace Pago.Mensajes.ManejadoresComandos;

public class PagoCommandHandler : IRequestHandler<CrearPagoCommand, bool>
{
    private readonly IEventBus _bus;

    public PagoCommandHandler(IEventBus bus) => _bus = bus;

    public Task<bool> Handle(CrearPagoCommand request, CancellationToken cancellationToken)
    {
        _bus.Publish(new PagoCreadoEvent(request.IdPago, request.IdFactura, request.Monto, request.Fecha));

        return Task.FromResult(true);
    }
}