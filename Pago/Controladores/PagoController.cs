using Microsoft.AspNetCore.Mvc;
using Pago.DTOs;
using Pago.Modelos;
using Pago.Servicios;

namespace Pago.Controladores;

[Route("api/[controller]")]
[ApiController]
public class PagoController : ControllerBase
{
    private readonly IPagoService _pagoService;

    public PagoController(IPagoService pagoService) => _pagoService = pagoService;

    [HttpGet]
    public IActionResult ObtenerTodos()
    {
        var pagos = _pagoService.ObtenerTodos();

        return Ok(pagos);
    }

    [HttpPost]
    public IActionResult Depositar([FromBody] PagoRequest request)
    {
        PagoModelo pago = new(request.IdFactura, request.Monto);
        pago = _pagoService.Operacion(pago);

        return Ok(pago);
    }
}
