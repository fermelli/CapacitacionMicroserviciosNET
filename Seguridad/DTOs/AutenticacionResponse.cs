namespace Seguridad.DTOs
{
    public class AutenticacionResponse
    {
        public AutenticacionResponse(string token, string expiracion)
        {
            Token = token;
            Expiracion = expiracion;
        }

        public string? Token { get; set; }
        public string? Expiracion { get; set; }
    }
}
