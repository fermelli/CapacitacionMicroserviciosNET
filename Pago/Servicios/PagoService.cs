using Pago.Modelos;
using Pago.Persistencia;

namespace Pago.Servicios;

public class PagoService: IPagoService
{
    private readonly BaseDatosContexto _baseDatosContexto;

    public PagoService(BaseDatosContexto baseDatosContexto) => _baseDatosContexto = baseDatosContexto;

    public IEnumerable<PagoModelo> ObtenerTodos()
    {
        return _baseDatosContexto.Pago.ToList();
    }

    public PagoModelo Operacion(PagoModelo pago)
    {
        _baseDatosContexto.Pago.Add(pago);
        _baseDatosContexto.SaveChanges();

        return pago;
    }

    public PagoModelo OperacionReversa(PagoModelo pago)
    {
        _baseDatosContexto.Pago.Add(pago);
        _baseDatosContexto.SaveChanges();

        return pago;
    }
}
