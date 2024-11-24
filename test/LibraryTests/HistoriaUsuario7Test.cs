using Ucu.Poo.DiscordBot.Interaccion;

namespace Ucu.Poo.DiscordBot.Domain.Tests;

public class HistoriaUsuario7Test
{
    private Jugador jugador1;
    private Jugador jugador2;
    private IInteraccionConUsuario mockInteraccion;
    private Logica logica;

    [Test]
    public void hdUsuario7Test()
    {
        mockInteraccion = Substitute.For<IInteraccionConUsuario>();
        jugador1 = new Jugador("Ash");
        jugador2 = new Jugador("Misty");
        
        // Configuración del jugador y su equipo
        var pokemonInicial = new Pokemon("Pikachu", "Eléctrico", 100, 50, 40);
        var pokemonNuevo = new Pokemon("Blastoise", "Agua", 120, 40, 50);
        jugador1.agregarPokemon(pokemonInicial);
        jugador1.agregarPokemon(pokemonNuevo);

        // Mock de la interacción para seleccionar el nuevo Pokémon
        mockInteraccion.LeerEntrada().Returns("Blastoise");

        // Simula el cambio de Pokémon
        var logica = new Logica(mockInteraccion);
        bool turnoConsumido = logica.CambiarPokemon(jugador1);

        // Verifica que el Pokémon en cancha ahora sea "Blastoise"
        Assert.That(jugador1.pokemonEnCancha().Nombre, Is.EqualTo("Blastoise"));

        // Verifica que el cambio consumió el turno
        Assert.IsTrue(turnoConsumido);
    }
}