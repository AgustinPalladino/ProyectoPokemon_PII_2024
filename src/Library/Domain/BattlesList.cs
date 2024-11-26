namespace Ucu.Poo.DiscordBot.Domain;

/// <summary>
/// Esta clase representa la lista de batallas en curso.
/// </summary>
public class BattlesList
{
    private List<Battle> battles = new List<Battle>();

    /// <summary>
    /// Busca una batalla activa en la que participe el jugador especificado.
    /// </summary>
    /// <param name="playerDisplayName">El nombre del jugador.</param>
    /// <returns>La batalla activa si se encuentra, de lo contrario, null.</returns>
    public Battle? GetBattleByPlayer(string playerDisplayName)
    {
        return battles.FirstOrDefault(b => 
            b.Player1 == playerDisplayName || b.Player2 == playerDisplayName);
    }
    
    /// <summary>
    /// Crea una nueva batalla entre dos jugadores.
    /// </summary>
    /// <param name="player1">El primer jugador.</param>
    /// <param name="player2">El oponente.</param>
    /// <returns>La batalla creada.</returns>
    public Battle AddBattle(string player1, string player2)
    {
        var battle = new Battle(player1, player2);
        this.battles.Add(battle);
        return battle;
    }
}
