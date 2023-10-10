using MongoDB.Driver;
using Transaccion.DTOs;
using Transaccion.Modelos;
using Transaccion.Persistencia;

namespace Transaccion.Servicios;

public class TransaccionService: ITransaccionService
{
    private readonly IBaseDatosMongoContexto _contexto;
    protected IMongoCollection<TransaccionModelo> _baseDatosColeccion;
    public TransaccionService(IBaseDatosMongoContexto contexto)
    {
        _contexto = contexto;
        _baseDatosColeccion = _contexto.ObtenerColeccion<TransaccionModelo>(typeof(TransaccionModelo).Name);
    }

    public async Task<bool> Agregar(TransaccionModelo historialModelo)
    {
        await _baseDatosColeccion.InsertOneAsync(historialModelo);

        return true;
    }

    public async Task<IEnumerable<TransaccionResponse>> ObtenerFacturaPorId(int idFactura)
    {
        var resultado = await _baseDatosColeccion.Find(transaccion => transaccion.IdFactura == idFactura).ToListAsync();
        var respuesta = new List<TransaccionResponse>();

        foreach (var item in resultado)
        {
            respuesta.Add(new TransaccionResponse()
            {
                IdTransaccion = item.IdTransaccion,
                IdFactura = item.IdFactura,
                Monto = item.Monto,
                Fecha = item.Fecha,
            });
        }

        return respuesta;
    }
}
