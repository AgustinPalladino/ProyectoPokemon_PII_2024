using Discord;
using Discord.Commands;
using Ucu.Poo.DiscordBot.Domain;
using Ucu.Poo.DiscordBot.Interaccion;

namespace Ucu.Poo.DiscordBot.Commands;

public class MenuCommand :  ModuleBase<SocketCommandContext>
{
    [Command("Menu")]
    [Summary("Muestra el menu del jugador")]

    public async Task ExecuteAsync([Remainder] string? itemName = null)
    {
        var playerDisplayName = Context.User.Username;

        // Llama a Facade para agregar el Pokémon al jugador
        var player = Facade.Instance.GetOrCreatePlayer(playerDisplayName); 


        
        await Context.Message.Author.SendMessageAsync($"\nMenu de {playerDisplayName}. ¿Qué deseas hacer? Seleccione un numero porfavor \n 1- Ver las habilidades de tu Pokémon (No consume turno)\n 2- Ver la salud de tu Pokémon (No consume turno)\n 3- Mochila (Solo usar objeto consume un turno)\n 4- Atacar (Consume un turno)\n 5- Cambiar de Pokémon (Consume un turno)");
    }
}