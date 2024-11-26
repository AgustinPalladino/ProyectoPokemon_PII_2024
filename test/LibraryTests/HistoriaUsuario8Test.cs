using NSubstitute;
using Ucu.Poo.DiscordBot.Interaccion;
using Ucu.Poo.DiscordBot.Items;

namespace Ucu.Poo.DiscordBot.Domain.Tests;

public class HistoriaUsuario8Test
{
    private Jugador jugador1;
    private Jugador jugador2;
    private IInteraccionConUsuario mockInteraccion;
    private Logica logica;

    [Test]
    public void SeleccionarPokemonDeCambio_UsaSuperPocionCorrectamente()
    {
        mockInteraccion = Substitute.For<IInteraccionConUsuario>();
        logica = new Logica(mockInteraccion);

        Jugador jugador = new Jugador("Jugador");
        Pokemon pokemon = new Pokemon("Charizard", "Fuego", 120, 80, 100);
        jugador.agregarPokemon(pokemon);
        
        pokemon.VidaActual -= 50; // Vida actual = 70

        // Simula las entradas del usuario
        mockInteraccion.LeerEntrada().Returns("SuperPocion", "Charizard","0");

        // prueba de haber utilizado bien el item
        bool resultado = logica.Mochila(jugador);
        Assert.That(resultado, Is.True, "El ítem debería haber sido usado correctamente.");
        mockInteraccion.Received(2).LeerEntrada(); // Verifica que se realizaron 2 entradas
        Assert.That(pokemon.VidaActual, Is.EqualTo(120));
    }

    [Test]
    public void SeleccionarItemErroneo()
    {
        mockInteraccion = Substitute.For<IInteraccionConUsuario>();
        logica = new Logica(mockInteraccion);

        Jugador jugador = new Jugador("Jugador");
        Pokemon pokemon = new Pokemon("Charizard", "Fuego", 120, 80, 100);
        jugador.agregarPokemon(pokemon);
        
        pokemon.VidaActual -= 50; // Vida actual = 70

        // Simula las entradas del usuario
        mockInteraccion.LeerEntrada().Returns("ItemMal");

        // prueba de haber utilizado bien el item
        bool resultado = logica.Mochila(jugador);
        Assert.That(resultado, Is.False, "El ítem debería no haber sido encontrado");
        mockInteraccion.Received(1).LeerEntrada(); //Verifica
        Assert.That(pokemon.VidaActual, Is.EqualTo(70));
    }
    
    [Test]
    public void SeleccionarItemParaSalir()
    {
        mockInteraccion = Substitute.For<IInteraccionConUsuario>();
        logica = new Logica(mockInteraccion);

        Jugador jugador = new Jugador("Jugador");
        Pokemon pokemon = new Pokemon("Charizard", "Fuego", 120, 80, 100);
        jugador.agregarPokemon(pokemon);
        
        pokemon.VidaActual -= 50; // Vida actual = 70

        // Simula las entradas del usuario
        mockInteraccion.LeerEntrada().Returns("0");

        // prueba de haber utilizado bien el item
        bool resultado = logica.Mochila(jugador);
        Assert.That(resultado, Is.False, "El ítem debería haber sido usado correctamente.");
        mockInteraccion.Received(1).LeerEntrada(); // verifica
        Assert.That(pokemon.VidaActual, Is.EqualTo(70));
    }
    
    [Test]
    public void MochilaVacia()
    {
        mockInteraccion = Substitute.For<IInteraccionConUsuario>();
        logica = new Logica(mockInteraccion);

        Jugador jugador = new Jugador("Jugador");
        Pokemon pokemon = new Pokemon("Charizard", "Fuego", 120, 80, 100);
        jugador.agregarPokemon(pokemon);
        
        for(int i = 0; i <= jugador.Mochila.Count; i++)
        {
            jugador.Mochila.Remove(jugador.Mochila[i]);
        }

        // Simula las entradas del usuario
        mockInteraccion.LeerEntrada().Returns("MochilaVacia");

        // prueba de haber utilizado bien el item
        bool resultado = logica.Mochila(jugador);
        Assert.That(resultado, Is.False, "Mochila deberia estar vacia");
        mockInteraccion.Received(1).LeerEntrada();
        Assert.That(logica.Mochila(jugador), Is.EqualTo(false));
    }
}