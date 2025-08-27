namespace BasketballAPI.Models;

public class ActualizarEquipoReq
{
    public int IdJuego { get; set; }
    public int IdEquipo { get; set; }
    public int Periodo { get; set; }
    public int Puntos { get; set; }
    public int Faltas { get; set; }
}
