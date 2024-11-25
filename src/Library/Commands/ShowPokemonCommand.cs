using Discord.Commands;

namespace Ucu.Poo.DiscordBot.Commands
{
    public class ShowPokemonCommand : ModuleBase<SocketCommandContext>
    {
        [Command("showpokemon")]
        [Summary("Muestra los Pokémon disponibles para agregar a tu equipo.")]
        public async Task ExecuteAsync()
        {
            var availablePokemon = DiccionariosYOperacionesStatic.DiccionarioPokemon.Values;
            var pokemonList = string.Join(", ", availablePokemon.Select(p => p.Nombre));

            await ReplyAsync($"Pokémon disponibles: {pokemonList}");
        }
    }
}