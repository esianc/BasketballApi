using System.Data;
using BasketballAPI.Models;
using System.Data.SqlClient;

namespace BasketballAPI.Services;

public class BasketballService
{
    private readonly string _connectionString;

    public BasketballService(IConfiguration config)
    {
        _connectionString = config.GetConnectionString("BasketballDB");
    }

    // 🔹 Obtener marcador de un juego
    public async Task<List<MarcadorDto>> GetMarcadorAsync(int idJuego)
    {
        var lista = new List<MarcadorDto>();

        using var conn = new SqlConnection(_connectionString);
        using var cmd = new SqlCommand("sp_marcador_juego", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@id_juego", idJuego);

        await conn.OpenAsync();
        using var reader = await cmd.ExecuteReaderAsync();

        while (await reader.ReadAsync())
        {
            lista.Add(new MarcadorDto
            {
                Equipo = reader.GetString(0),
                Puntos = reader.GetInt32(1),
                Faltas = reader.GetInt32(2)
            });
        }

        return lista;
    }

    // 🔹 Obtener estadísticas de jugadores
    public async Task<List<EstadisticaJugadorDto>> GetEstadisticasJugadoresAsync(int idJuego)
    {
        var lista = new List<EstadisticaJugadorDto>();

        using var conn = new SqlConnection(_connectionString);
        using var cmd = new SqlCommand("sp_estadisticas_jugadores", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@id_juego", idJuego);

        await conn.OpenAsync();
        using var reader = await cmd.ExecuteReaderAsync();

        while (await reader.ReadAsync())
        {
            lista.Add(new EstadisticaJugadorDto
            {
                Jugador = reader.GetString(0),
                Numero = reader.GetInt32(1),
                Equipo = reader.GetString(2),
                Puntos = reader.GetInt32(3),
                Faltas = reader.GetInt32(4)
            });
        }

        return lista;
    }
}
