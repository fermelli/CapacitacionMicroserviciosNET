using Aforo255.Cross.Token.Src;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Seguridad.DTOs;
using Seguridad.Servicios;

namespace Seguridad.Controladores;

[Route("api/[controller]")]
[ApiController]
public class AutenticacionController : ControllerBase
{
    private readonly IAutenticacionService _autenticacionService;
    private readonly JwtOptions _jwtOptions;

    public AutenticacionController(IAutenticacionService autenticacionService, IOptionsSnapshot<JwtOptions> jwtOptions)
    {
        _autenticacionService = autenticacionService;
        _jwtOptions = jwtOptions.Value;
    }

    [HttpGet]
    public IActionResult ObtenerTodos()
    {
        return Ok(_autenticacionService.ObtenerTodos());
    }

    [HttpPost]
    public IActionResult Login([FromBody] AutenticacionRequest request)
    {
        if (!_autenticacionService.Login(request.Nombre, request.Contrasena))
        {
            return Unauthorized();
        }

        string token = JwtToken.Create(_jwtOptions);

        Response.Headers.Add("access-control-expose-headers", "Authorization");
        Response.Headers.Add("Authorization", token);

        return Ok(new AutenticacionResponse(token, "5h"));
    }
}
