using Pago.Persistencia;

namespace Pago.Datos;

public static class BaseDatosCreada
{
    public static void CrearBaseDatosSinoExiste(IHost host)
    {
        using var scope = host.Services.CreateScope();
        var servicios = scope.ServiceProvider;

        try
        {
            var contexto = servicios.GetRequiredService<BaseDatosContexto>();

            BaseDatosInicializada.Inicializar(contexto);
        }
        catch (Exception ex)
        {
            var logger = servicios.GetRequiredService<ILogger<Program>>();

            logger.LogError(ex, "Ocurrio un error al crear la Base de Datos (MySQL).");
        }
    }
}
