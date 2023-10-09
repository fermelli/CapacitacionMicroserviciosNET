using Transaccion.DTOs;
using Transaccion.Modelos;

namespace Transaccion.Servicios;

public interface ITransaccionService
{
    Task<IEnumerable<TransaccionResponse>> ObtenerFacturaPorId(int idFactura);

    Task<bool> Agregar(TransaccionModelo transaccionModelo);
}
