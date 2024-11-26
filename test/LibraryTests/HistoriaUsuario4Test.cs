using NSubstitute;
using Ucu.Poo.DiscordBot.Interaccion;

namespace Ucu.Poo.DiscordBot.Domain.Tests;

public class HistoriaUsuario4Test
{
    private IInteraccionConUsuario mockInteraccion;
    private Logica logica;

    
    [Test]
    public void SeleccionarAtaque()
    {
        mockInteraccion = Substitute.For<IInteraccionConUsuario>();
        logica = new Logica(mockInteraccion);

        Jugador jugador1 = new Jugador("Jugador1");
        Jugador jugador2 = new Jugador("Jugador2");
        Pokemon pokemon = new Pokemon("Charizard", "Fuego", 120, 80, 100);
        Pokemon pokemon2 = new Pokemon("Magmar", "Fuego", 200, 80, 100);
        Dictionary<string, Movimiento> DiccionarioMovimientos = new Dictionary<string, Movimiento>
        {
            { "Lanzallamas", new Movimiento("Lanzallamas", 40, 40, "Fuego", false) },
            { "Hidrobomba", new Movimiento("Hidrobomba", 50, 35, "Agua", false) },
            { "Rayo", new Movimiento("Rayo", 40, 40, "Eléctrico", false) },
            { "Terremoto", new Movimiento("Terremoto", 50, 30, "Tierra", false) }
        };
        pokemon.AgregarMovimientos(new List<Movimiento>
        {
            DiccionarioMovimientos["Lanzallamas"],
            DiccionarioMovimientos["Hidrobomba"],
            DiccionarioMovimientos["Rayo"],
            DiccionarioMovimientos["Terremoto"]
        });
        jugador1.agregarPokemon(pokemon);
        jugador2.agregarPokemon(pokemon2);
        

        // Simula las entradas del usuario
        mockInteraccion.LeerEntrada().Returns("Lanzallamas");

        // prueba de haber utilizado bien el item
        bool resultado = logica.SeleccionarAtaque(jugador1, jugador2);
        Assert.That(resultado, Is.True, "El ataque deberia haber sido escogido correctamente");
        mockInteraccion.Received(1).LeerEntrada(); // Verifica que se realizaron 2 entradas
        Assert.That(resultado, Is.EqualTo(true));
    }

    
    [Test]
    public void SeleccionarAtaqueErroneo()
    {
        mockInteraccion = Substitute.For<IInteraccionConUsuario>();
        logica = new Logica(mockInteraccion);

        Jugador jugador = new Jugador("Jugador");
        Pokemon pokemon = new Pokemon("Charizard", "Fuego", 120, 80, 100);
        Dictionary<string, Movimiento> DiccionarioMovimientos = new Dictionary<string, Movimiento>
        {
            { "Lanzallamas", new Movimiento("Lanzallamas", 40, 40, "Fuego", false) },
            { "Hidrobomba", new Movimiento("Hidrobomba", 50, 35, "Agua", false) },
            { "Rayo", new Movimiento("Rayo", 40, 40, "Eléctrico", false) },
            { "Terremoto", new Movimiento("Terremoto", 50, 30, "Tierra", false) }
        };
        pokemon.AgregarMovimientos(new List<Movimiento>
        {
            DiccionarioMovimientos["Lanzallamas"],
            DiccionarioMovimientos["Hidrobomba"],
            DiccionarioMovimientos["Rayo"],
            DiccionarioMovimientos["Terremoto"]
        });
        jugador.agregarPokemon(pokemon);

        // Simula las entradas del usuario
        mockInteraccion.LeerEntrada().Returns("MovimientoMal");

        // prueba de haber utilizado bien el item
        bool resultado = logica.Mochila(jugador);
        Assert.That(resultado, Is.False, "El movimiento debería no haber sido encontrado");
        mockInteraccion.Received(1).LeerEntrada(); //Verifica
        Assert.That(logica.Mochila(jugador), Is.EqualTo(false));
    }
    
    
    [Test]
    public void SeleccionarAtaqueVolverAtras()
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
        Assert.That(resultado, Is.False, "El deberia haber vuelto hacia atras.");
        mockInteraccion.Received(1).LeerEntrada(); // verifica
        Assert.That(logica.Mochila(jugador), Is.EqualTo(false));
    }
}