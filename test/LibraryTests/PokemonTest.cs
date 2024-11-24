using Ucu.Poo.DiscordBot.Interaccion;

namespace Ucu.Poo.DiscordBot.Domain.Tests;

public class PokemonTest
{
    [Test]
    public void constructorTest()
    {
        var poke = new Pokemon("Pedrito", "Fuego", 100, 50, 10);
        
        Assert.That(poke.Nombre, Is.EqualTo("Pedrito"));
        Assert.That(poke.Tipo, Is.EqualTo("Fuego"));
        Assert.That(poke.VidaMax, Is.EqualTo(100));
        Assert.That(poke.Ataque, Is.EqualTo(50));
        Assert.That(poke.Defensa, Is.EqualTo(10));
    }

    [Test]
    public void variosTest()
    {
        var poke = new Pokemon("Pedrito", "Fuego", 100, 50, 10);
        poke.VidaActual = 66;
        poke.TurnosDormido = 4;
        poke.PorcentajeDañoPorTurno = 0.3;
        
        Assert.That(poke.VidaActual, Is.EqualTo(66));
        Assert.That(poke.TurnosDormido, Is.EqualTo(4));
        Assert.That(poke.PorcentajeDañoPorTurno, Is.EqualTo(0.3));
    }

    [Test]
    public void dañoRecurrenteTest()
    {
        var jugador1 = new Jugador("Jugador1");
        var jugador2 = new Jugador("Jugador2");
        var pokemon1 = new Pokemon("Blastoise", "Agua", 100, 100, 80); // Se pasa el tipo y las estadísticas
        var pokemon2 = new Pokemon("Charizard", "Fuego", 120, 80, 100); // Se pasa el tipo y las estadísticas

        jugador1.agregarPokemon(pokemon1);
        jugador2.agregarPokemon(pokemon2);
        

        pokemon2.Estado = "Envenenado";

        pokemon2.PorcentajeDañoPorTurno = 0.1;
        
        jugador2.pokemonEnCancha().aplicarDañoRecurrente(new InteraccionPorConsola());
        
        Assert.That(pokemon2.VidaActual,Is.EqualTo(108));

        pokemon2.VidaActual = 100;
        
        pokemon2.Estado = "Quemado";
        
        pokemon2.PorcentajeDañoPorTurno = 0.1;
        
        jugador2.pokemonEnCancha().aplicarDañoRecurrente(new InteraccionPorConsola());
        
        Assert.That(pokemon2.VidaActual,Is.EqualTo(88));
        
    }

    [Test]
    public void puedeAtacarTest()
    {
        var jugador1 = new Jugador("Jugador1");
        var jugador2 = new Jugador("Jugador2");
        var pokemon1 = new Pokemon("Blastoise", "Agua", 100, 100, 80); // Se pasa el tipo y las estadísticas
        var pokemon2 = new Pokemon("Charizard", "Fuego", 120, 80, 100); // Se pasa el tipo y las estadísticas

        jugador1.agregarPokemon(pokemon1);
        jugador2.agregarPokemon(pokemon2);

        pokemon2.Estado = "Dormido";

        pokemon2.TurnosDormido = 3;
        
        Assert.That(pokemon2.puedeAtacar(new InteraccionPorConsola()),Is.EqualTo(false));
        
        pokemon1.Estado = "Paralizado";
        
        Assert.That(pokemon1.puedeAtacar(new InteraccionPorConsola()),Is.EqualTo(true));    
    }
}