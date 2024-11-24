using Ucu.Poo.DiscordBot.Interaccion;

namespace Ucu.Poo.DiscordBot.Domain.Tests;

public class HistoriaUsuario3Test
{
    private Jugador jugador1;
    private Jugador jugador2;
    private IInteraccionConUsuario mockInteraccion;
    private Logica logica;

    [Test]
    public void hdUsuario3Test()
    {
        mockInteraccion = Substitute.For<IInteraccionConUsuario>();
        jugador1 = new Jugador("Ash");
        jugador2 = new Jugador("Misty");

        // Configuración de los Pokémons
        var pokemonJugador = new Pokemon("Charizard", "Fuego", 100, 50, 40);
        var pokemonOponente = new Pokemon("Blastoise", "Agua", 120, 40, 50);
        jugador1.agregarPokemon(pokemonJugador);
        jugador2.agregarPokemon(pokemonOponente);

        // Mock del ataque
        var ataque = new Movimiento("Lanzallamas", 20, 80, "Fuego", false);

        // Simula un ataque
        jugador1.atacar(jugador2, ataque, mockInteraccion);

        // Verifica que la vida del Pokémon del oponente se actualiza tras el ataque
        Assert.That(jugador2.pokemonEnCancha().VidaActual, Is.EqualTo(pokemonOponente.VidaActual));

        // Simula otra acción para mostrar la vida del Pokémon propio
        jugador1.verSalud(mockInteraccion);
        mockInteraccion.Received(1)
            .ImprimirMensaje(
                $"La vida del {pokemonJugador.Nombre} es: {pokemonJugador.VidaActual}/{pokemonJugador.VidaMax}");
    }
}