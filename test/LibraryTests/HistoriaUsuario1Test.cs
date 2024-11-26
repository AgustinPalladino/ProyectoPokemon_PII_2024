using Ucu.Poo.DiscordBot.Interaccion;
using NSubstitute;

namespace Ucu.Poo.DiscordBot.Domain.Tests;

public class HisotriaUsuario1Test
{
    private Jugador jugador1;
    private Jugador jugador2;
    private IInteraccionConUsuario mockInteraccion;
    private Logica logica;
    
    [Test]
    public void SeleccionarPokemonDeCambio_CambiaPokemonCorrectamente()
    {
        // Arrange
        mockInteraccion = Substitute.For<IInteraccionConUsuario>();
        logica = new Logica(mockInteraccion); // Pasa el mock al constructor

        Jugador jugador = new Jugador("Jugador");
        Pokemon charizard = new Pokemon("Charizard", "Fuego", 120, 80, 100);
        jugador.agregarPokemon(charizard);

        // Simula la entrada del usuario
        mockInteraccion.LeerEntrada().Returns("Charizard");

        // Act
        bool resultado = logica.SeleccionarPokemonDeCambio(jugador);

        // Assert
        Assert.That(resultado, Is.True, "El Pokémon debería haber sido cambiado correctamente.");
        mockInteraccion.Received(1).LeerEntrada(); // Verifica que se llamó al método LeerEntrada
        Assert.That(jugador.pokemonEnCancha().Nombre, Is.EqualTo("Charizard"), "El Pokémon actual no fue cambiado correctamente.");
    }
    
}