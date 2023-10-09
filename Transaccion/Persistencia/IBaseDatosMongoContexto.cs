using MongoDB.Driver;

namespace Transaccion.Persistencia;

public interface IBaseDatosMongoContexto
{
    IMongoCollection<T> ObtenerColeccion<T>(string nombre);
}
