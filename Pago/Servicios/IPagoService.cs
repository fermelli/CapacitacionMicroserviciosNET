using Pago.Modelos;

namespace Pago.Servicios;

public interface IPagoService
{
    IEnumerable<PagoModelo> ObtenerTodos();
    PagoModelo Operacion(PagoModelo pago);
    PagoModelo OperacionReversa(PagoModelo pago);
}
