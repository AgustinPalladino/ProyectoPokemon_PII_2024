namespace Ucu.Poo.DiscordBot.Interaccion;

public class InteraccionPorConsola : IInteraccionConUsuario
{
    public void ImprimirMensaje(string mensaje)
    {
        Console.WriteLine(mensaje);
    }

    public string LeerEntrada()
    {
        return Console.ReadLine();
    }
}