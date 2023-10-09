using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Transaccion.Persistencia.Configuraciones;

namespace Transaccion.Persistencia;

public class BaseDatosMongoContexto : IBaseDatosMongoContexto
{
    private IMongoDatabase _baseDatos { get; set; }
    private MongoClient _clienteMongo { get; set; }
    public IClientSessionHandle? Sesion { get; set; }

    public BaseDatosMongoContexto(IOptions<BaseDatosMongoConfiguraciones> configuracion)
    {
        _clienteMongo = new MongoClient(configuracion.Value.Conexion);
        _baseDatos = _clienteMongo.GetDatabase(configuracion.Value.NombreBaseDatos);
    }

    public IMongoCollection<T> ObtenerColeccion<T>(string nombre)
    {
        return _baseDatos.GetCollection<T>(nombre);
    }
}
