using Discord.WebSocket;
using Ucu.Poo.DiscordBot.Commands;

namespace Ucu.Poo.DiscordBot.Interaccion;

public class InteraccionPorBot : IInteraccionConUsuario
{

    public void ImprimirMensaje(string mensaje)
    {
        ImprimirBot imprimirBot = new ImprimirBot();
        imprimirBot.ExecuteAsync(mensaje);
    }

    public string LeerEntrada()
    {
        return "";
    }
}