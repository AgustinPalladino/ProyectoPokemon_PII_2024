using System.Net;
using System.Net.Http.Headers;
using System.Text.Json.Nodes;
using Microsoft.Extensions.Logging;
using Discord.Commands;
using Ucu.Poo.DiscordBot;
using Ucu.Poo.DiscordBot.Commands;
using Ucu.Poo.DiscordBot.Domain;

namespace Ucu.Poo.DiscordBot.Commands;
    
public class AddPokemonCommand : ModuleBase<SocketCommandContext>
{
    [Command("name")]
    [Summary("Agrega un Pokémon a tu equipo.")]
    public async Task ExecuteAsync([Remainder] string pokemonName)
    {
        var playerName = Context.User.Username;

        // Llama a Facade para agregar el Pokémon al jugador
        var result = Facade.Instance.addPokemonToPlayer(playerName, pokemonName);

        await ReplyAsync(result);
    }
}