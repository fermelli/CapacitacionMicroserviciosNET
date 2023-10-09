using Seguridad.Modelos;
using Seguridad.Persistencia;

namespace Seguridad.Servicios;

public class AutenticacionService : IAutenticacionService
{
    private readonly BaseDatosContexto _baseDatosContexto;

    public AutenticacionService(BaseDatosContexto baseDatosContexto)
    {
        _baseDatosContexto = baseDatosContexto;
    }

    public IEnumerable<UsuarioModelo> ObtenerTodos()
    {
        return _baseDatosContexto.Usuario.ToList();
    }

    public bool Login(string? nombre, string? contrasena)
    {
        var usuarios = _baseDatosContexto.Usuario.ToList();
        var usuario = usuarios.FirstOrDefault(usuario => usuario.Nombre == nombre && usuario.Contrasena == contrasena);

        return (usuario is not null);
    }
}
