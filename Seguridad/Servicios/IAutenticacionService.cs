using Seguridad.Modelos;

namespace Seguridad.Servicios;

public interface IAutenticacionService
{
    IEnumerable<UsuarioModelo> ObtenerTodos();
    bool Login(string? nombre, string? contrasena);
}