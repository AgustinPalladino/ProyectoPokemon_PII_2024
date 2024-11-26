using Discord.Commands;
using Ucu.Poo.DiscordBot.Domain;
using Ucu.Poo.DiscordBot.Interaccion;

namespace Ucu.Poo.DiscordBot.Commands;

public class AttackComand : ModuleBase<SocketCommandContext>
{
    [Command("4")]
    [Summary("Realiza un ataque con el pokemon activo.")]
    public async Task ExecutAsync([Remainder] string moveName)
    {
        var playerDisplayName = Context.User.Username;
        var player = Facade.Instance.GetOrCreatePlayer(playerDisplayName);

        var move = player.pokemonEnCancha().listaMovimientos.FirstOrDefault(m => m.Nombre.Equals(moveName, StringComparison.OrdinalIgnoreCase));
        if (move == null)
        {
            await ReplyAsync("El movimiento no existe o no pertenece al Pokémon actual.");
        }
        else
        {
            player.atacar(Facade.Instance.GetOpponent(playerDisplayName), move, new DiscordInteraction(Context));
            await ReplyAsync($"¡Usaste {move.Nombre}!");
        }
    }
}