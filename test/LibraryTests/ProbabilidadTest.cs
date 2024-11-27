using Ucu.Poo.DiscordBot.Interaccion;

namespace Ucu.Poo.DiscordBot.Domain.Tests;

////////////////////////////////////////// DEFENSA PEDRO MOREIRA 27/11/24 ///////////////////////////////////////////////////////

public class ProbabilidadTest
{
    [Test]
    public void puntajePokemonTest()
    {
        var logica = new Logica(new InteraccionPorConsola());
        
        Jugador jugador = new Jugador("Jugador");
        Pokemon pokemon = new Pokemon("Charizard", "Fuego", 120, 8, 1);
        Pokemon pokemon1 = new Pokemon("Blastoise", "Agua", 100, 100, 80);
        Pokemon pokemon2 = new Pokemon("Hoopa", "Fantasma", 50, 200, 40);
        Pokemon pokemon3 = new Pokemon("Magmar", "Fuego", 60, 30, 40);
        Pokemon pokemon4 = new Pokemon("Pidgey", "Volador", 70, 20, 10);
        Pokemon pokemon5 = new Pokemon("Vulpix", "Fuego", 30, 40, 30);

        jugador.agregarPokemon(pokemon);
        jugador.agregarPokemon(pokemon1);
        jugador.agregarPokemon(pokemon2);
        jugador.agregarPokemon(pokemon3);
        jugador.agregarPokemon(pokemon4);
        jugador.agregarPokemon(pokemon5);

        int puntaje = jugador.PuntajePokemon();
        
        Assert.That(puntaje, Is.EqualTo(60));
        
        
        Jugador jugador2 = new Jugador("Jugador2");
        Pokemon pokemon10 = new Pokemon("Blastoise", "Agua", 40, 100, 0); // Se pasa el tipo y las estadísticas

        jugador2.agregarPokemon(pokemon10);
        
        Movimiento movimiento = new Movimiento("Hidrocañon", 5000, 1,"Acuatico",false);
        
        pokemon10.listaMovimientos.Add(movimiento);
        
        logica.CalculoAtaque(jugador2,jugador,movimiento);
        
        puntaje = jugador.PuntajePokemon();
        
        Assert.That(puntaje, Is.EqualTo(50));
        
        
    }
    
    [Test]
    public void puntajeInventarioTest()
    {
        Jugador jugador = new Jugador("Jugador");
        Pokemon pokemon = new Pokemon("Charizard", "Fuego", 120, 80, 100);
        pokemon.VidaActual = 50;

        jugador.agregarPokemon(pokemon);


        int puntaje = jugador.PuntajeInventario();
        
        Assert.That(puntaje, Is.EqualTo(30));
        
        var item = jugador.Mochila[0];
        
        Assert.That(item.Nombre, Is.EqualTo("SuperPocion"));
        
        jugador.UsarMochila(item, "Charizard");
        
        puntaje = jugador.PuntajeInventario();
        
        Assert.That(puntaje, Is.EqualTo(25));
        
    }

    [Test]
    public void puntajeEstadoTest()
    {
        Jugador jugador = new Jugador("Jugador");
        Pokemon pokemon = new Pokemon("Charizard", "Fuego", 120, 80, 100);
        Pokemon pokemon1 = new Pokemon("Blastoise", "Agua", 100, 100, 80);
        Pokemon pokemon2 = new Pokemon("Hoopa", "Fantasma", 50, 200, 40);
        Pokemon pokemon3 = new Pokemon("Magmar", "Fuego", 60, 30, 40);
        Pokemon pokemon4 = new Pokemon("Pidgey", "Volador", 70, 20, 10);
        Pokemon pokemon5 = new Pokemon("Vulpix", "Fuego", 30, 40, 30);

        jugador.agregarPokemon(pokemon);
        jugador.agregarPokemon(pokemon1);
        jugador.agregarPokemon(pokemon2);
        jugador.agregarPokemon(pokemon3);
        jugador.agregarPokemon(pokemon4);
        jugador.agregarPokemon(pokemon5);

        int puntaje = jugador.PuntajeEstado();
        Assert.That(puntaje, Is.EqualTo(10));

        pokemon1.Estado = "Dormido";
        puntaje = jugador.PuntajeEstado();
        Assert.That(puntaje, Is.EqualTo(0));
    }

    [Test]
    public void puntajeTotalTest()
    {
        Jugador jugador = new Jugador("Jugador");
        Pokemon pokemon = new Pokemon("Charizard", "Fuego", 120, 80, 100);
        Pokemon pokemon1 = new Pokemon("Blastoise", "Agua", 100, 100, 80);
        Pokemon pokemon2 = new Pokemon("Hoopa", "Fantasma", 50, 200, 40);
        Pokemon pokemon3 = new Pokemon("Magmar", "Fuego", 60, 30, 40);
        Pokemon pokemon4 = new Pokemon("Pidgey", "Volador", 70, 20, 10);
        Pokemon pokemon5 = new Pokemon("Vulpix", "Fuego", 30, 40, 30);

        jugador.agregarPokemon(pokemon);
        jugador.agregarPokemon(pokemon1);
        jugador.agregarPokemon(pokemon2);
        jugador.agregarPokemon(pokemon3);
        jugador.agregarPokemon(pokemon4);
        jugador.agregarPokemon(pokemon5);

        pokemon.VidaActual = 50;
        
        int puntaje = jugador.PuntajeTotal();
        Assert.That(puntaje, Is.EqualTo(100));
        
        var item = jugador.Mochila[0];
        
        jugador.UsarMochila(item, "Charizard");
        
        pokemon1.Estado = "Dormido";

        puntaje = jugador.PuntajeTotal();
        
        Assert.That(puntaje, Is.EqualTo(85));

    }

    [Test]
    public void probabilidadTest()
    {
        var logica = new Logica(new InteraccionPorConsola());
        var jugador1 = new Jugador("Jugador1");
        var jugador2 = new Jugador("Jugador2");
        var pokemon1 = new Pokemon("Blastoise", "Agua", 100, 100, 80); // Se pasa el tipo y las estadísticas
        var pokemon2 = new Pokemon("Charizard", "Fuego", 120, 80, 100); // Se pasa el tipo y las estadísticas
        
        
        Assert.That(logica.Probabilidad(jugador1,jugador2), Is.EqualTo("Ambos tienen la misma probabilidad"));
        
        jugador1.agregarPokemon(pokemon1);
        
        Assert.That(logica.Probabilidad(jugador1,jugador2), Is.EqualTo($"{jugador1.Nombre} tiene mas probabilidad de ganar.\n{jugador1.Nombre} tiene: {jugador1.PuntajeTotal()} puntos, mientras que {jugador2.Nombre} tiene: {jugador2.PuntajeTotal()} puntos."));
        
        jugador2.agregarPokemon(pokemon2);
        
        Assert.That(logica.Probabilidad(jugador1,jugador2), Is.EqualTo("Ambos tienen la misma probabilidad"));
        
        jugador2.agregarPokemon(pokemon1);
        
        Assert.That(logica.Probabilidad(jugador1,jugador2), Is.EqualTo($"{jugador2.Nombre} tiene mas probabilidad de ganar.\n{jugador2.Nombre} tiene: {jugador2.PuntajeTotal()} puntos, mientras que {jugador1.Nombre} tiene: {jugador1.PuntajeTotal()} puntos."));
    }
}
