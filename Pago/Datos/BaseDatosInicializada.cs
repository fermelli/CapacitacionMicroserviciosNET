using Pago.Persistencia;

namespace Pago.Datos;

public class BaseDatosInicializada
{
    public static void Inicializar(BaseDatosContexto contexto)
    {
        contexto.Database.EnsureCreated();
        contexto.SaveChanges();
    }
}
