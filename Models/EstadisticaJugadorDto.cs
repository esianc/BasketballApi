namespace BasketballAPI.Models;

public class EstadisticaJugadorDto
{
    public string Jugador { get; set; } = string.Empty;
    public int Numero { get; set; }
    public string Equipo { get; set; } = string.Empty;
    public int Puntos { get; set; }
    public int Faltas { get; set; }
}
