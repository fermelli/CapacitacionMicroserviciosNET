using Aforo255.Cross.Event.Src.Bus;
using Microsoft.AspNetCore.Mvc;
using Pago.DTOs;
using Pago.Mensajes.Comandos;
using Pago.Modelos;
using Pago.Servicios;

namespace Pago.Controladores;

[Route("api/[controller]")]
[ApiController]
public class PagoController : ControllerBase
{
    private readonly IPagoService _pagoService;
    private readonly IEventBus _eventBus;

    public PagoController(IPagoService pagoService, IEventBus eventBus)
    {
        _pagoService = pagoService;
        _eventBus = eventBus;
    }

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

        _eventBus.SendCommand(new CrearPagoCommand(pago.IdPago, pago.IdFactura, pago.Monto, pago.Fecha));

        return Ok(pago);
    }
}
