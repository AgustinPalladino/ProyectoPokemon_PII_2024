using Library;
using Library.Interaccion;
using NSubstitute;

namespace TestProject;

public class HistoriaUsuario6Test
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
    public void FinalizarBatalla_DeclaraGanadorCuandoTodosLosPokemonsDelOponenteSonDerrotados()
    {
        
        mockInteraccion = Substitute.For<IInteraccionConUsuario>();
        jugador1 = new Jugador("Ash");
        jugador2 = new Jugador("Misty");
        
        // Configuración de los jugadores y sus equipos
        var pokemonJugador = new Pokemon("Pikachu", "Eléctrico", 100, 50, 40);
        var pokemonOponente = new Pokemon("Charizard", "Fuego", 100, 60, 50);
        jugador1.agregarPokemon(pokemonJugador);
        jugador2.agregarPokemon(pokemonOponente);
        Console.WriteLine($"{jugador2.pokemonEnCancha().VidaActual}");

        // Mock del ataque que derrota al Pokémon del oponente
        var ataque = new Movimiento("Rayo", 100, 100, "Eléctrico", false);
        
        jugador1.atacar(jugador2, ataque, mockInteraccion);
        // Verifica que el HP del Pokémon oponente sea 0
        Assert.That(jugador2.pokemonEnCancha().VidaActual,Is.LessThanOrEqualTo(0) );

        // Simula el chequeo de victoria
        var logica = new Logica(mockInteraccion);
        
        bool esVictoria = logica.ChequeoVictoria(jugador2);
        
        
        // Verifica que la batalla termina
        Assert.That(esVictoria, Is.EqualTo(true));
        // Verifica que se muestra el mensaje de victoria
        mockInteraccion.Received(1).ImprimirMensaje($"Felicidades, a {jugador2.Nombre} no le quedan mas pokemones! Has ganado la batalla.");

    }

}