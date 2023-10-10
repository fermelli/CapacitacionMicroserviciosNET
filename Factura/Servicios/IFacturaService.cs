using Factura.Modelos;

namespace Factura.Servicios;

public interface IFacturaService
{
    IEnumerable<FacturaModelo> ObtenerTodas();

    void CambiarEstado(int idFactura);
}
