using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Ucu.Poo.DiscordBot.Domain;

namespace Ucu.Poo.DiscordBot.Commands;

/// <summary>
/// Esta clase implementa el comando 'battle' del bot. Este comando une al
/// jugador que envía el mensaje con el oponente que se recibe como parámetro,
/// si lo hubiera, en una batalla; si no se recibe un oponente, lo une con
/// cualquiera que esté esperando para jugar.
/// </summary>
// ReSharper disable once UnusedType.Global
public class ImprimirBot : ModuleBase<SocketCommandContext>
{
    /// <summary>
    /// Implementa el comando 'battle'. Este comando une al jugador que envía el
    /// mensaje a la lista de jugadores esperando para jugar.
    /// </summary>
    // ReSharper disable once UnusedMember.Global
    public async Task ExecuteAsync(string mensaje,
        [Remainder]
        [Summary("Display name del oponente, opcional")]
        string? opponentDisplayName = null)
    {
        string displayName = CommandHelper.GetDisplayName(Context);
        
        SocketGuildUser? opponentUser = CommandHelper.GetUser(
            Context, opponentDisplayName);


        if (opponentUser != null)
        {
            await Context.Message.Author.SendMessageAsync(mensaje);
        }
        else
        {
            mensaje = $"No hay un usuario {opponentDisplayName}";
        }

        await ReplyAsync(mensaje);
    }
}