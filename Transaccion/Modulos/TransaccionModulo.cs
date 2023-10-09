using Carter;
using Transaccion.DTOs;
using Transaccion.Servicios;

namespace Transaccion.Modulos;

public class TransaccionModulo: ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("api/transaccion/{idFactura}", ObtenerFacturaPorId)
           .Produces<TransaccionResponse>()
           .Produces(StatusCodes.Status404NotFound);
    }

    private static async Task<IResult> ObtenerFacturaPorId(int idFactura, ITransaccionService servicio)
    {
        var transacciones = await servicio.ObtenerFacturaPorId(idFactura);

        if (transacciones is null) return Results.NotFound();

        return Results.Ok(transacciones);
    }
}
