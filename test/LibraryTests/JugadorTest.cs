using Ucu.Poo.DiscordBot.Interaccion;

namespace Ucu.Poo.DiscordBot.Domain.Tests;

public class JugadorTest
{
    [Test]
    public void agregarPokemon()
    {
        Jugador jugador = new Jugador("Jugador");
        Pokemon pokemon = new Pokemon("Charizard", "Fuego", 120, 80, 100);
        Pokemon pokemon1 = new Pokemon("Blastoise", "Agua", 100, 100, 80);
        Pokemon pokemon2 = new Pokemon("Hoopa", "Fantasma", 50, 200, 40);
        Pokemon pokemon3 = new Pokemon("Magmar", "Fuego", 60, 30, 40);
        Pokemon pokemon4 = new Pokemon("Pidgey", "Volador", 70, 20, 10);
        Pokemon pokemon5 = new Pokemon("Vulpix", "Fuego", 30, 40, 30);
        Pokemon pokemonExtra = new Pokemon("Ninetales", "Fuego", 40, 60, 60);
        

        //Prueba de string agregar pokemon
        //prueba agregar pokemon correctamente
        Assert.That(jugador.agregarPokemon(pokemon), Is.EqualTo($"{pokemon.Nombre} agregado al equipo de {jugador.Nombre}."));
        
        
        //prueba de que ya esta agregado
        Assert.That(jugador.agregarPokemon(pokemon), Is.EqualTo($"{pokemon.Nombre} ya está en tu equipo."));
        
        //prueba de que supera mas de 6 pokemon
        jugador.agregarPokemon(pokemon1);
        jugador.agregarPokemon(pokemon2);
        jugador.agregarPokemon(pokemon3);
        jugador.agregarPokemon(pokemon4);
        jugador.agregarPokemon(pokemon5);
        Assert.That(jugador.agregarPokemon(pokemonExtra), Is.EqualTo("No se puede agregar mas de 6 pokemones"));

    }
    
    [Test]
    public void atacarTest()
    {
        Jugador jugador1 = new Jugador("Jugador1");
        Jugador jugador2 = new Jugador("Jugador2");
        Pokemon pokemon1 = new Pokemon("Blastoise", "Agua", 100, 100, 80); // Se pasa el tipo y las estadísticas
        Pokemon pokemon2 = new Pokemon("Charizard", "Fuego", 120, 80, 100); // Se pasa el tipo y las estadísticas
        Movimiento movimiento = new Movimiento("Hidrocañon", 5, 1,"Acuatico",false);

        //Prueba de agregar pokemon y movimiento de manera correcta
        jugador1.agregarPokemon(pokemon1);
        jugador2.agregarPokemon(pokemon2);
        pokemon1.listaMovimientos.Add(movimiento);

        //Prueba de ataque
        jugador1.atacar(jugador2, movimiento, new InteraccionPorConsola());

        Assert.Less(pokemon2.VidaActual, pokemon2.VidaMax); 
    }
    
    [Test]
    public void usarMochilaTest()
    {
        Jugador jugador = new Jugador("Ash");

        Pokemon poke = new Pokemon("chari", "fuego",100,20,20);
        poke.VidaActual = 30;
        jugador.agregarPokemon(poke);
        
        Assert.That(jugador.Mochila.Count, Is.EqualTo(7)); 

        var item = jugador.Mochila[0];
        
        Assert.That(item.Nombre, Is.EqualTo("SuperPocion"));
        
        jugador.UsarMochila(item, "chari");
        
        Assert.That(jugador.Mochila.Count, Is.EqualTo(6)); 
        
    }
[Test]
    public void cambiarPoscionPokeTest()
    {
        Jugador jugador = new Jugador("Ash");

        Pokemon poke = new Pokemon("chari", "fuego",100,20,20);
        
        Pokemon poke2 = new Pokemon("chari2", "fuego",100,20,20);
        
        jugador.agregarPokemon(poke);
        
        jugador.agregarPokemon(poke2);
        
        Assert.That(jugador.equipoPokemon[0], Is.EqualTo(poke));
        
        jugador.cambiarPokemon(poke2);
        
        Assert.That(jugador.equipoPokemon[0], Is.EqualTo(poke2));
        
    }

    [Test]
    public void pokeEnCanchaTest()
    {
        Jugador jugador = new Jugador("Ash");

        Pokemon poke = new Pokemon("chari", "fuego",100,20,20);
        
        Pokemon poke2 = new Pokemon("chari2", "fuego",100,20,20);
        
        jugador.agregarPokemon(poke);
        
        jugador.agregarPokemon(poke2);

        Pokemon pokeEnCancha = jugador.pokemonEnCancha();
        
        Assert.That(pokeEnCancha, Is.EqualTo(jugador.equipoPokemon[0]));
    }


    [Test]
    public void mostrarEquipo()
    {
        Jugador jugador = new Jugador("Jugador");
        Pokemon pokemon = new Pokemon("Charizard", "Fuego", 120, 80, 100);
        string mensaje = $"El equipo del {jugador.Nombre} equipo es: ";
        mensaje += $"\n-{pokemon.Nombre}";
        Assert.That(jugador.MostrarEquipo(), Is.EqualTo(mensaje));
    }
}