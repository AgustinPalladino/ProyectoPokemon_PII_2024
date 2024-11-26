using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Ucu.Poo.DiscordBot.Domain;
using Ucu.Poo.DiscordBot.Interaccion;
using Discord.Commands;
using Ucu.Poo.DiscordBot.Interaccion;

namespace Ucu.Poo.DiscordBot.Interaccion
{
    public class DiscordInteraction : IInteraccionConUsuario
    {
        private readonly SocketCommandContext _context;

        public DiscordInteraction(SocketCommandContext context)
        {
            _context = context;
        }

        // Implementación de ImprimirMensaje: Enviar mensaje al canal de Discord
        public void ImprimirMensaje(string mensaje)
        {
            _context.Channel.SendMessageAsync(mensaje).Wait();
        }

        // Implementación de LeerEntrada: No es aplicable en Discord, arroja excepción si se usa
        public string LeerEntrada()
        {
            throw new NotSupportedException("LeerEntrada no es compatible en Discord.");
        }
    }
}
