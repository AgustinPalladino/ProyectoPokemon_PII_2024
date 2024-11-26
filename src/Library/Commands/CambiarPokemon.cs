using Discord.Commands;
using Ucu.Poo.DiscordBot.Domain;

namespace Ucu.Poo.DiscordBot.Commands;

public class CambiarPokemon : ModuleBase<SocketCommandContext>
{
    [Command("5")]
    [Summary("Cambia al Pokémon activo del jugador.")]
    public async Task ExecuteAsync([Remainder] string pokemonName)
    {
        var playerName = Context.User.Username;
        var player = Facade.Instance.GetOrCreatePlayer(playerName);

        var pokemon = player.equipoPokemon.FirstOrDefault(p => p.Nombre.Equals(pokemonName, StringComparison.OrdinalIgnoreCase));
        if (pokemon == null)
        {
            await ReplyAsync("No tienes un Pokémon con ese nombre en tu equipo.");
        }
        else
        {
            player.cambiarPokemon(pokemon);
            await ReplyAsync($"Has cambiado a {pokemon.Nombre}.");
        }
    }
}