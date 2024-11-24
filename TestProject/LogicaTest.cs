using Library;
using Library.Interaccion;

namespace TestProject;

public class LogicaTest
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void calculoAtaqueTest()
    {
        var logica = new Logica(new InteraccionPorConsola());
        var jugador1 = new Jugador("Jugador1");
        var jugador2 = new Jugador("Jugador2");
        var pokemon1 = new Pokemon("Blastoise", "Agua", 100, 100, 80); // Se pasa el tipo y las estadísticas
        var pokemon2 = new Pokemon("Charizard", "Fuego", 120, 80, 100); // Se pasa el tipo y las estadísticas
        var movimiento = new Movimiento("Hidrocañon", 5, 1,"Acuatico",false);
        
        jugador1.agregarPokemon(pokemon1);
        jugador2.agregarPokemon(pokemon2);
        
        List<Movimiento> movimientos = new List<Movimiento>();
        movimientos.Add(movimiento);
        pokemon1.AgregarMovimientos(movimientos);

        logica.CalculoAtaque(jugador1, jugador2, movimiento);
        
        Assert.That(pokemon2.VidaActual, Is.LessThan(pokemon2.VidaMax));

        var movimientoEspecial = new Movimiento("dormir", 0, 100, "Psíquico", true);
        
        logica.CalculoAtaque(jugador1, jugador2, movimientoEspecial);
        
        Assert.That(pokemon2.Estado, Is.EqualTo("Dormido"));

        pokemon2.VidaActual = 0;

        logica.CalculoAtaque(jugador1, jugador2, movimiento);
        
        Assert.That(logica.ChequeoVictoria(jugador2), Is.EqualTo(true));
        
    }

    [Test]
    public void chequeoNoVictoriaTest()
    {
        var logica = new Logica(new InteraccionPorConsola());
        var jugador1 = new Jugador("Jugador1");
        var jugador2 = new Jugador("Jugador2");
        var pokemon1 = new Pokemon("Blastoise", "Agua", 100, 100, 80); // Se pasa el tipo y las estadísticas
        var pokemon2 = new Pokemon("Charizard", "Fuego", 120, 80, 100); // Se pasa el tipo y las estadísticas
        var movimiento = new Movimiento("Hidrocañon", 5, 1,"Acuatico",false);
        
        jugador1.agregarPokemon(pokemon1);
        jugador2.agregarPokemon(pokemon2);
        
        logica.CalculoAtaque(jugador1, jugador2, movimiento);

        var test = logica.ChequeoVictoria(jugador2);
        
        Assert.That(test, Is.EqualTo(false));


    }

}