using System.ComponentModel.DataAnnotations;

namespace Seguridad.Modelos;

public class UsuarioModelo
{
    [Key]
    public int? IdUsuario { get; set; }
    public string? Nombre { get; set; }
    public string? Contrasena { get; set; }
}
