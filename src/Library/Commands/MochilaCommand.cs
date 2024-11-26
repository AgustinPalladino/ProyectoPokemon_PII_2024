using Discord.Commands;
using Ucu.Poo.DiscordBot.Domain;
using Ucu.Poo.DiscordBot.Interaccion;

namespace Ucu.Poo.DiscordBot.Commands;

public class MochilaCommand : ModuleBase<SocketCommandContext>
{
    [Command("3")]
    [Summary("Muestra los items en la mochila del jugador y permite usar uno")]

    public async Task ExecuteAsync([Remainder] string? itemName = null)
    {
        var playerDisplayName = Context.User.Username;
        var player = Facade.Instance.GetOrCreatePlayer(playerDisplayName);

        if (string.IsNullOrEmpty(itemName))
        {
            var items = player.Mochila.Select(i => $"- {i.Nombre}");
            await ReplyAsync(
                $"Tu mochila contiene: \n{string.Join("\n", items)}\nUsa `!3 <nombre_del_item>` para usar un ítem.");
        }
        else
        {
            var item = player.Mochila.FirstOrDefault(i =>
                i.Nombre.Equals(itemName, StringComparison.OrdinalIgnoreCase));
            if (item == null)
            {
                await ReplyAsync("No tienes ese ítem en tu mochila.");
            }
            else
            {
                item.Usar(player, new DiscordInteraction(Context));
                player.Mochila.Remove(item);
                await ReplyAsync($"Usaste {item.Nombre}.");
            }
        }
    }
}