using Discord.Commands;
using Ucu.Poo.DiscordBot.Domain;
using Ucu.Poo.DiscordBot.Interaccion;

namespace Ucu.Poo.DiscordBot.Commands;

public class MochilaCommand : ModuleBase<SocketCommandContext>
{
    [Command("3")]
    [Summary("Muestra los items en la mochila del jugador y permite usar uno")]

    public async Task ExecuteAsync(string itemName = null, string pokemonName = null)
    {
        var playerDisplayName = Context.User.Username;
        var player = Facade.Instance.GetOrCreatePlayer(playerDisplayName);

        // Verificar si no hay parámetros
        if (string.IsNullOrEmpty(itemName) && string.IsNullOrEmpty(pokemonName))
        {
            var items = player.Mochila.Select(i => $"- {i.Nombre}");
            await ReplyAsync($"Tu mochila contiene:\n{string.Join("\n", items)}\nUsa `!3 <nombre_del_item>` <nombre_del_pokemon> para usar un ítem.");
            return;
        }

        // Manejo del itemName
        if (!string.IsNullOrEmpty(itemName))
        {
            var item = player.Mochila.FirstOrDefault(i => i.Nombre.Equals(itemName, StringComparison.OrdinalIgnoreCase));
            if (item == null)
            {
                await ReplyAsync("No tienes ese ítem en tu mochila.");
                return;
            }

            if (!string.IsNullOrEmpty(pokemonName))
            {
                item.Usar(player, pokemonName);
                player.Mochila.Remove(item);
                await ReplyAsync($"Usaste {item.Nombre} en {pokemonName}.");
            }
            else
            {
                await ReplyAsync($"Usaste {item.Nombre}.");
            }
            return;
        }
    }
}