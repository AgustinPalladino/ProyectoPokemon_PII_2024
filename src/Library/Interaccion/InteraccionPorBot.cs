using Discord.WebSocket;

namespace Ucu.Poo.DiscordBot.Interaccion;

public class InteraccionPorBot : IInteraccionConUsuario
{
    private readonly DiscordSocketClient client;
    private readonly SocketTextChannel channel;
    private IInteraccionConUsuario _interaccionConUsuarioImplementation;

    public InteraccionPorBot(DiscordSocketClient client, SocketTextChannel channel)
    {
        this.client = client;
        this.channel = channel;
    }

    public void ImprimirMensaje(string mensaje)
    {
        this.channel.SendMessageAsync(mensaje).Wait();
    }

    public string LeerEntrada()
    {
        return EsperarRespuestaAsync().Result;
    }

    private async Task<string> EsperarRespuestaAsync()
    {
        var tcs = new TaskCompletionSource<string>();
        
        Task MessageHandler(SocketMessage message)
        {
            if (message.Channel.Id == this.channel.Id && !message.Author.IsBot)
            {
                tcs.SetResult(message.Content);
            }
            return Task.CompletedTask;
        }
        
        this.client.MessageReceived += MessageHandler;
        
        var result = await tcs.Task;
        
        this.client.MessageReceived -= MessageHandler;

        return result;
    }
}