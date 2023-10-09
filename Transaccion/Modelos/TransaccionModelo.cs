using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Transaccion.Modelos;

public class TransaccionModelo
{
    [BsonId]
    public ObjectId Id { get; set; }
    public int? IdTransaccion { get; set; }
    public int? IdFactura { get; set; }
    public decimal? Monto { get; set; }
    public DateOnly? Fecha { get; set; }
}
