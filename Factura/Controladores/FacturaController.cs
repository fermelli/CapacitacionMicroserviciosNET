using Factura.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace Factura.Controladores;

[Route("api/[controller]")]
[ApiController]
public class FacturaController : ControllerBase
{
    private readonly IFacturaService _facturaService;

    public FacturaController(IFacturaService facturaService) => _facturaService = facturaService;

    [HttpGet]
    public IActionResult ObtenerTodas()
    {
        var facturas = _facturaService.ObtenerTodas();

        return Ok(facturas);
    }
}
