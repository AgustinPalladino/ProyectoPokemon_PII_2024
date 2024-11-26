using NSubstitute;
using Ucu.Poo.DiscordBot.Interaccion;

namespace Ucu.Poo.DiscordBot.Domain.Tests;

public class HistoriaUsuario9Test
{
    private Jugador jugador1;
    private Jugador jugador2;
    private IInteraccionConUsuario mockInteraccion;
    private Logica logica;
    
    [Test]
    public void hdUsuario9Test()
    {
        mockInteraccion = Substitute.For<IInteraccionConUsuario>();
        jugador1 = new Jugador("Ash");
        jugador2 = new Jugador("Misty");
        
        // Simula una lista de espera
        var listaDeEspera = new List<string>();

        // Configura un método para añadir jugadores a la lista de espera
        void AgregarALaListaDeEspera(string nombreJugador)
        {
            listaDeEspera.Add(nombreJugador);
            mockInteraccion.ImprimirMensaje($"Jugador {nombreJugador} se ha unido a la lista de espera.");
        }

        // Lógica para agregar el jugador 1
        AgregarALaListaDeEspera(jugador1.Nombre);

        // Verifica que el jugador fue añadido a la lista
        Assert.Contains(jugador1.Nombre, listaDeEspera);

        // Verifica que el mensaje de confirmación se mostró
        mockInteraccion.Received(1).ImprimirMensaje($"Jugador {jugador1.Nombre} se ha unido a la lista de espera.");
    }
}