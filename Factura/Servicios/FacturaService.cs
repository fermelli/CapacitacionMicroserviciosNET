using Factura.Modelos;
using Factura.Persistencia;

namespace Factura.Servicios;

public class FacturaService: IFacturaService
{
    private readonly BaseDatosContexto _baseDatosContexto;

    public FacturaService(BaseDatosContexto contextDatabase) => _baseDatosContexto = contextDatabase;

    public IEnumerable<FacturaModelo> ObtenerTodas()
    {
        return _baseDatosContexto.Factura.ToList();
    }

    public void CambiarEstado(int idFactura)
    {
        var factura = _baseDatosContexto.Factura.FirstOrDefault(i => i.IdFactura == idFactura);

        if (factura != null)
        {
            factura.Estado += 1;

            _baseDatosContexto.SaveChanges();
        }
    }
}
