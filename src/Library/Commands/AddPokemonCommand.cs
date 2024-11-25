using Discord.Commands;
using Ucu.Poo.DiscordBot.Domain;

namespace Ucu.Poo.DiscordBot.Commands;

public class AddPokemonCommand : ModuleBase<SocketCommandContext>
{
    [Command("addpokemon")]
    [Summary("Agrega un Pokémon a tu equipo.")]
    public async Task ExecuteAsync([Remainder] string pokemonName)
    {
        string displayName = CommandHelper.GetDisplayName(Context);
        var jugador = Facade.Instance.GetJugador(displayName); // Asegúrate de tener un método para obtener el jugador

        // Verifica si el Pokémon existe en el diccionario
        if (DiccionariosYOperacionesStatic.DiccionarioPokemon.TryGetValue(pokemonName, out Pokemon pokemon))
        {
            // Agrega el Pokémon al equipo del jugador
            jugador.agregarPokemon(pokemon.Clonar()); // Asegúrate de clonar el Pokémon para evitar referencias compartidas
            await ReplyAsync($"{pokemon.Nombre} ha sido agregado a tu equipo.");
        }
        else
        {
            await ReplyAsync($"No se encontró el Pokémon: {pokemonName}");
        }
    }
}