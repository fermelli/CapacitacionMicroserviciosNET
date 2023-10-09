using Factura.Persistencia;

namespace Factura.Datos;

public static class BaseDatosInicializada
{
    public static void CrearBaseDatosSinoExiste(IHost host)
    {
        using var scope = host.Services.CreateScope();
        var servicios = scope.ServiceProvider;

        try
        {
            var context = servicios.GetRequiredService<BaseDatosContexto>();

            BaseDatosCreada.Inicializar(context);
        }
        catch (Exception ex)
        {
            var logger = servicios.GetRequiredService<ILogger<Program>>();

            logger.LogError(ex, "Ocurrio un error al crear la Base de Datos (PostgreSQL)");
        }
    }
}
