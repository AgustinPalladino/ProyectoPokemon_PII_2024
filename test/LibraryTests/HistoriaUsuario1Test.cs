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
        Pokemon pokemon = new Pokemon("Charizard", "Fuego", 120, 80, 100);
        Pokemon pokemon2 = new Pokemon("Venusaur", "Planta", 100, 80, 200);
        jugador.agregarPokemon(pokemon);

        // Simula la entrada del usuario
        mockInteraccion.LeerEntrada().Returns("Charizard", "0", "Error", "Venusaur");


        // EL pokemon cambio correctamente
        bool resultado = logica.SeleccionarPokemonDeCambio(jugador);
        Assert.That(resultado, Is.True, "El Pokémon debería haber sido cambiado correctamente.");
        mockInteraccion.Received(1).LeerEntrada(); // Verifica que se llamó al método LeerEntrada
        Assert.That(resultado, Is.EqualTo(true),
            "El Pokémon actual fue cambiado correctamente.");

        
        
        // Volvio hacia atras
        resultado = logica.SeleccionarPokemonDeCambio(jugador);
        Assert.That(resultado, Is.False, "Usted deberia haber vuelto hacia atras");
        mockInteraccion.Received(2).LeerEntrada(); // Verifica que se llamó al método LeerEntrada
        Assert.That(resultado, Is.EqualTo(false), "Usted regreso hacia atras");
        
        // Error mal nombre
        resultado = logica.SeleccionarPokemonDeCambio(jugador);
        Assert.That(resultado, Is.False, "Sale un error");
        mockInteraccion.Received(3).LeerEntrada(); // Verifica que se llamó al método LeerEntrada
        Assert.That(resultado, Is.EqualTo(false), "Error inesperado");

        
        // El pokemon cambio correctamente
        jugador.equipoPokemon[0] = null;
        jugador.equipoPokemon.Add(pokemon);
        jugador.equipoPokemon.Add(pokemon2);
        resultado = logica.SeleccionarPokemonDeCambio(jugador);
        Assert.That(resultado, Is.True, "El Pokémon debería haber sido cambiado correctamente.");
        mockInteraccion.Received(4).LeerEntrada(); // Verifica que se llamó al método LeerEntrada
        Assert.That(resultado, Is.EqualTo(true),
            "El Pokémon actual fue cambiado correctamente.");
    }
}