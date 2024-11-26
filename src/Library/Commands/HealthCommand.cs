using Discord.Commands;
using Ucu.Poo.DiscordBot.Domain;

namespace Ucu.Poo.DiscordBot.Commands;

public class HealthCommand : ModuleBase<SocketCommandContext>
{
    [Command("2")]
    [Summary("Muestra la salud del Pokemon activo del jugador")]
    public async Task ExecuteAsync()
    {
        var playerDisplayName = Context.User.Username;
        var player = Facade.Instance.GetOrCreatePlayer(playerDisplayName);

        var pokemon = player.pokemonEnCancha();
        await ReplyAsync($"{pokemon.Nombre}: {pokemon.VidaActual}/{pokemon.VidaMax} puntos de salud.");
    }
}