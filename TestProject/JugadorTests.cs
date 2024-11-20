using Library;

namespace TestProject;

public class JugadorTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]

    public void atacarTest()
    {
        var jugador1 = new Jugador("Jugador1");
        var jugador2 = new Jugador("Jugador2");
        var pokemon1 = new Pokemon("Blastoise", "Agua", 100, 100, 80); // Se pasa el tipo y las estadísticas
        var pokemon2 = new Pokemon("Charizard", "Fuego", 120, 80, 100); // Se pasa el tipo y las estadísticas
        var movimiento = new Movimiento("Hidrocañon", 5, 1,"Acuatico",false);

        jugador1.agregarPokemon(pokemon1);
        jugador2.agregarPokemon(pokemon2);
        pokemon1.listaMovimientos.Add(movimiento);

        jugador1.atacar(jugador2, movimiento);

        Assert.Less(pokemon2.VidaActual, pokemon2.VidaMax); 
    }

[Test]
    public void usarMochilaTest()
    {
        var jugador = new Jugador("Ash");

        var poke = new Pokemon("chari", "fuego",100,20,20);
        poke.VidaActual = 30;
        jugador.agregarPokemon(poke);
        
        Assert.That(jugador.Mochila.Count, Is.EqualTo(7)); 

        var item = jugador.Mochila[0];
        
        Assert.That(item.Nombre, Is.EqualTo("SuperPocion"));
        
        jugador.UsarMochila(item);
        
        Assert.That(jugador.Mochila.Count, Is.EqualTo(6)); 
        
    }
[Test]
    public void cambiarPoscionPokeTest()
    {
        var jugador = new Jugador("Ash");

        var poke = new Pokemon("chari", "fuego",100,20,20);
        
        var poke2 = new Pokemon("chari2", "fuego",100,20,20);
        
        jugador.agregarPokemon(poke);
        
        jugador.agregarPokemon(poke2);
        
        Assert.That(jugador.equipoPokemon[0], Is.EqualTo(poke));
        
        jugador.cambiarPokemon(poke2);
        
        Assert.That(jugador.equipoPokemon[0], Is.EqualTo(poke2));
        
    }

    [Test]
    public void pokeEnCanchaTest()
    {
        var jugador = new Jugador("Ash");

        var poke = new Pokemon("chari", "fuego",100,20,20);
        
        var poke2 = new Pokemon("chari2", "fuego",100,20,20);
        
        jugador.agregarPokemon(poke);
        
        jugador.agregarPokemon(poke2);

        var pokeEnCancha = jugador.pokemonEnCancha();
        
        Assert.That(pokeEnCancha, Is.EqualTo(jugador.equipoPokemon[0]));
    }
    
    
}
