using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Ucu.Poo.DiscordBot.Domain;

namespace Ucu.Poo.DiscordBot.Commands;

public class MovesCommand : ModuleBase<SocketCommandContext>
{
    [Command("1")]
    [Summary("Muestra las habilidades del Pokémon actual del jugador.")]
    public async Task ExecuteAsync()
    {
        var playerDisplayName = Context.User.Username;
        var player = Facade.Instance.GetOrCreatePlayer(playerDisplayName); 

        if (player == null)
        {
            await ReplyAsync("No estás en una batalla actualmente.");
            return;
        }

        var moves = player.pokemonEnCancha().listaMovimientos.Select(m => $"- {m.Nombre}");
        await ReplyAsync($"Habilidades de {player.pokemonEnCancha().Nombre}:\n{string.Join("\n", moves)}");
    }
}