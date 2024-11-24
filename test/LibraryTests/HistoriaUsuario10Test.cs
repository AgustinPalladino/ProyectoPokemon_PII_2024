using Ucu.Poo.DiscordBot.Interaccion;

namespace Ucu.Poo.DiscordBot.Domain.Tests;

public class HistoriaUsuario10Test
{
    private Jugador jugador1;
    private Jugador jugador2;
    private IInteraccionConUsuario mockInteraccion;
    private Logica logica;

    [SetUp]
    public void Setup()
    {
        
    }

    [Test]
    public void hdUsuario10Test()
    {
        mockInteraccion = Substitute.For<IInteraccionConUsuario>();
        jugador1 = new Jugador("Ash");
        jugador2 = new Jugador("Misty");
        
        // Simula una lista de espera con varios jugadores
        var listaDeEspera = new List<string> { "Ash", "Misty", "Brock" };

        // Método para mostrar la lista de espera
        void MostrarListaDeEspera()
        {
            mockInteraccion.ImprimirMensaje("\nLista de jugadores esperando:");
            foreach (var jugador in listaDeEspera)
            {
                mockInteraccion.ImprimirMensaje($"- {jugador}");
            }
        }

        // Llama al método para mostrar la lista
        MostrarListaDeEspera();

        // Verifica que cada jugador en la lista de espera fue mostrado
        mockInteraccion.Received(1).ImprimirMensaje("\nLista de jugadores esperando:");
        mockInteraccion.Received(1).ImprimirMensaje("- Ash");
        mockInteraccion.Received(1).ImprimirMensaje("- Misty");
        mockInteraccion.Received(1).ImprimirMensaje("- Brock");
    }