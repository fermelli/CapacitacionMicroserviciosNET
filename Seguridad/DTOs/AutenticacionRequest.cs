namespace Seguridad.DTOs;

public class AutenticacionRequest
{
    public AutenticacionRequest(string nombre, string contrasena)
    {
        Nombre = nombre;
        Contrasena = contrasena;
    }

    public string? Nombre { get; set; }
    public string? Contrasena { get; set; }
}
