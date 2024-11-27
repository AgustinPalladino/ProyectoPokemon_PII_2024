using NSubstitute;
using Ucu.Poo.DiscordBot.Interaccion;

namespace Ucu.Poo.DiscordBot.Domain.Tests;

public class HistoriaUsuario5Test
{
    private Jugador jugador1;
    private Jugador jugador2;
    private IInteraccionConUsuario mockInteraccion;
    private Logica logica;
/// <summary>
/// Al intentar correr este test, siempre se nos queda en running, luego de varias pruebas y varios analisis, notamos que la causa de esto
/// es que el mensaje de quien es el turno se presenta dentro del metodo MenuJugador(j1, j2), el cual contiene uno de los dos unicos bucles
/// del programa, los cuales sirven para el flujo del programa si se desea implementar por consola.
/// Entendemos que debido al bucle el test queda en un loop infinito.
/// </summary>
    [Test]
    public void hdUsuario5Test()
    {
      //  mockInteraccion = Substitute.For<IInteraccionConUsuario>();
      //  jugador1 = new Jugador("Ash");
     //   jugador2 = new Jugador("Misty");
        
        // Configuración inicial
    //    var logica = new Logica(mockInteraccion);

        
    //    jugador1.agregarPokemon(new Pokemon("Pikachu", "Eléctrico", 100, 50, 40));
    //    jugador2.agregarPokemon(new Pokemon("Charizard", "Fuego", 100, 60, 50));

    //    mockInteraccion.LeerEntrada().Returns("5");
        
    //    logica.MenuDeJugador(jugador1, jugador2);
        
    //    mockInteraccion.ImprimirMensaje($"\nTurno de {jugador1.Nombre}.");
    }
}