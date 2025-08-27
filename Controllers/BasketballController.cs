using Microsoft.AspNetCore.Mvc;
using BasketballAPI.Services;
using BasketballAPI.Models;

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

    // POST api/basketball/equipo
    [HttpPost("equipo")]
    public async Task<IActionResult> ActualizarEquipo([FromBody] ActualizarEquipoReq req)
    {
        await _service.ActualizarEstadisticaEquipoAsync(req);
        return Ok(new { message = "Estadística de equipo registrada correctamente" });
    }

    // POST api/basketball/jugador
    [HttpPost("jugador")]
    public async Task<IActionResult> ActualizarJugador([FromBody] ActualizarJugadorReq req)
    {
        await _service.ActualizarEstadisticaJugadorAsync(req);
        return Ok(new { message = "Estadística de jugador registrada correctamente" });
    }


}
