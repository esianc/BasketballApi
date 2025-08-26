using Microsoft.AspNetCore.Mvc;
using BasketballAPI.Services;

namespace BasketballAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BasketballController : ControllerBase
{
    private readonly BasketballService _service;

    public BasketballController(BasketballService service)
    {
        _service = service;
    }

    // GET api/basketball/marcador/1
    [HttpGet("marcador/{idJuego}")]
    public async Task<IActionResult> GetMarcador(int idJuego)
    {
        var data = await _service.GetMarcadorAsync(idJuego);
        return Ok(data);
    }

    // GET api/basketball/estadisticas/1
    [HttpGet("estadisticas/{idJuego}")]
    public async Task<IActionResult> GetEstadisticasJugadores(int idJuego)
    {
        var data = await _service.GetEstadisticasJugadoresAsync(idJuego);
        return Ok(data);
    }
}
