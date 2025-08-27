namespace BasketballAPI.Models;

public class ActualizarJugadorReq
{
    public int IdJuego { get; set; }
    public int IdJugador { get; set; }
    public int Puntos { get; set; }
    public int Faltas { get; set; }
}
