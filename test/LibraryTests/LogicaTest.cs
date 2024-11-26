using System.Reflection.PortableExecutable;
using Ucu.Poo.DiscordBot.Interaccion;

namespace Ucu.Poo.DiscordBot.Domain.Tests;

public class LogicaTest
{
    [Test]
    public void calculoAtaqueTest()
    {
        var logica = new Logica(new InteraccionPorConsola());
        var jugador1 = new Jugador("Jugador1");
        var jugador2 = new Jugador("Jugador2");
        var pokemon1 = new Pokemon("Blastoise", "Agua", 100, 100, 80); // Se pasa el tipo y las estadísticas
        var pokemon2 = new Pokemon("Charizard", "Fuego", 120, 80, 100); // Se pasa el tipo y las estadísticas
        var movimiento = new Movimiento("Hidrocañon", 5, 100,"Agua",false);
        
        jugador1.agregarPokemon(pokemon1);
        jugador2.agregarPokemon(pokemon2);
        
        List<Movimiento> movimientos = new List<Movimiento>();
        movimientos.Add(movimiento);
        pokemon1.AgregarMovimientos(movimientos);

        //Prueba de movimiento normal
        logica.CalculoAtaque(jugador1, jugador2, movimiento);
        Assert.Less(pokemon2.VidaActual, pokemon2.VidaMax);

        //Prueba de movimiento especial
        var movimientoEspecial = new Movimiento("dormir", 0, 100, "Psíquico", true);
        logica.CalculoAtaque(jugador1, jugador2, movimientoEspecial);
        Assert.That(pokemon2.Estado, Is.EqualTo("Dormido"));
        
        //Prueba si el pokemon muere
        var movimientoLetal = new Movimiento("Instakill", 9999, 100,"Agua",false);
        logica.CalculoAtaque(jugador1, jugador2, movimientoLetal);
        Assert.That(jugador2.equipoPokemon[0], Is.EqualTo(null));
    }

    [Test]
    public void chequeoVictoriaTest()
    {
        var logica = new Logica(new InteraccionPorConsola());
        var jugador1 = new Jugador("Jugador1");
        var jugador2 = new Jugador("Jugador2");
        var pokemon1 = new Pokemon("Blastoise", "Agua", 100, 100, 80); 
        var pokemon2 = new Pokemon("Charizard", "Fuego", 120, 80, 100);
        var movimiento = new Movimiento("Hidrocañon", 5, 1,"Agua",false);
        
        jugador1.agregarPokemon(pokemon1);
        jugador2.agregarPokemon(pokemon2);
        
        //Prueba de si no gano la persona
        var test = logica.ChequeoVictoria(jugador2);
        Assert.That(test, Is.EqualTo(false));
        
        //Prueba de si gano la persona
        var movimientoLetal = new Movimiento("Instakill", 9999, 100,"Agua",false);
        logica.CalculoAtaque(jugador1, jugador2, movimientoLetal);
        Assert.That(logica.ChequeoVictoria(jugador2), Is.EqualTo(true));
    }

    [Test]
    public void CambiarPokeStringAPokemon()
    {
        Jugador jugador = new Jugador("Jugador");
        //prueba de que el pokemon es correcto
        Assert.That(Logica.CambiarPokeStringAPokemon(jugador, "Charizard"), Is.EqualTo($"Charizard agregado al equipo de {jugador.Nombre}."));
        
        //prueba de que el pokemon no es correcto
        Assert.That(Logica.CambiarPokeStringAPokemon(jugador, "Alberto"), Is.EqualTo($"Alberto, no es correcto"));
    }
}