using Seguridad.Persistencia;

namespace Seguridad.Datos;

public static class BaseDatosCreada
{
    public static void CrearBaseDatosSiNoExiste(IHost host)
    {
        using var scope = host.Services.CreateScope();
        var servicios = scope.ServiceProvider;

        try
        {
            var contexto = servicios.GetRequiredService<BaseDatosContexto>();
            BaseDatosInicializador.Inicializar(contexto);
        }
        catch (Exception ex)
        {
            var logger = servicios.GetRequiredService<ILogger<Program>>();

            logger.LogError(ex, "Ocurrio un error al crear la Base de Datos (SQL Server)");
        }
    }
}
