using Seguridad.Modelos;
using Seguridad.Persistencia;

namespace Seguridad.Datos;

public class BaseDatosInicializador
{
    public static void Inicializar(BaseDatosContexto contexto)
    {
        contexto.Database.EnsureCreated();

        if (contexto.Usuario.Any()) return;

        var usuarios = new UsuarioModelo[]
        {
                new UsuarioModelo{Nombre="admin", Contrasena="123456"},
                new UsuarioModelo{Nombre="fermelli", Contrasena="654321"},
                new UsuarioModelo{Nombre="evecita", Contrasena="111111"},
        };

        foreach (UsuarioModelo usuario in usuarios)
        {
            contexto.Usuario.Add(usuario);
        }

        contexto.SaveChanges();
    }
}
