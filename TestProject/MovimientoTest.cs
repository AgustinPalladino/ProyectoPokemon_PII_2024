using Library;
using Library.Interaccion;

namespace TestProject;

public class MovimientoTest
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void constructorTest()
    {
        var movimiento = new Movimiento("Hidrocañon", 5, 1,"Acuatico",false);
        
        Assert.That(movimiento.Nombre, Is.EqualTo("Hidrocañon"));
        Assert.That(movimiento.Ataque, Is.EqualTo(5));
        Assert.That(movimiento.Precision, Is.EqualTo(1));
        Assert.That(movimiento.Tipo, Is.EqualTo("Acuatico"));
        Assert.That(movimiento.EsEspecial, Is.EqualTo(false));
    }

    [Test]

    public void clonarTest()
    {
        var movimiento = new Movimiento("Hidrocañon", 5, 1,"Acuatico",false);

        var movimientoClonado = movimiento.Clonar();
        
        Assert.That(movimientoClonado.Nombre, Is.EqualTo(movimiento.Nombre));
        Assert.That(movimientoClonado.Ataque, Is.EqualTo(movimiento.Ataque));
        Assert.That(movimientoClonado.Precision, Is.EqualTo(movimiento.Precision));
        Assert.That(movimientoClonado.Tipo, Is.EqualTo(movimiento.Tipo));
        Assert.That(movimientoClonado.EsEspecial, Is.EqualTo(movimiento.EsEspecial));
    }

    [Test]
    public void movEspecialesTest()
    {
        var logica = new Logica(new InteraccionPorConsola());
        var jugador1 = new Jugador("Jugador1");
        var jugador2 = new Jugador("Jugador2");
        var pokemon1 = new Pokemon("Blastoise", "Agua", 100, 100, 80); // Se pasa el tipo y las estadísticas
        var pokemon2 = new Pokemon("Charizard", "Fuego", 120, 80, 100); // Se pasa el tipo y las estadísticas

        jugador1.agregarPokemon(pokemon1);
        jugador2.agregarPokemon(pokemon2);
        
        var Dormir = new Movimiento("dormir", 0, 100, "Psíquico", true);
        var Quemar = new Movimiento("Quemar", 0, 100, "Psíquico", true);
        var paralizar = new Movimiento("Paralizar", 0, 100, "Psíquico", true);
        var envenenar = new Movimiento("envenenar", 0, 100, "Psíquico", true);

        logica.CalculoAtaque(jugador1, jugador2, Dormir);
        Assert.That(pokemon2.Estado, Is.EqualTo("Dormido"));
        
        pokemon2.Estado = "Normal";
        
        logica.CalculoAtaque(jugador1, jugador2, Quemar);
        Assert.That(pokemon2.Estado, Is.EqualTo("Quemado"));

        pokemon2.Estado = "Normal";
        
        logica.CalculoAtaque(jugador1, jugador2, paralizar);
        Assert.That(pokemon2.Estado, Is.EqualTo("Paralizado"));

        pokemon2.Estado = "Normal";
        
        logica.CalculoAtaque(jugador1, jugador2, envenenar);
        Assert.That(pokemon2.Estado, Is.EqualTo("Envenenado"));

        pokemon2.Estado = "Normal";
        
        
        
    }
}