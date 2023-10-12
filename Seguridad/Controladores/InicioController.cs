using Microsoft.AspNetCore.Mvc;

namespace Seguridad.Controladores;

[Route("")]
[ApiController]
public class InicioController : ControllerBase
{
    private readonly ILogger<InicioController> _logger;

    public InicioController(ILogger<InicioController> logger)
    {
        _logger = logger;
    }

    [HttpGet("ping")]
    public IActionResult Ping()
    {
        _logger.LogDebug("Ping...");
        return Ok();
    }
}
