using NSubstitute;
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
        Assert.That(jugador2.pokemonEnCancha().VidaActual, Is.LessThan(jugador2.pokemonEnCancha().VidaMax));

        // Simula otra acción para mostrar la vida del Pokémon propio
        var salud = jugador1.verSalud();
        Assert.That(salud, Is.EqualTo($"La vida del {jugador1.pokemonEnCancha().Nombre} es: {jugador1.pokemonEnCancha().VidaActual}/{jugador1.pokemonEnCancha().VidaMax}"));
    }
}