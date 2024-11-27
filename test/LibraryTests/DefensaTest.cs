using Ucu.Poo.DiscordBot.Interaccion;
using Ucu.Poo.DiscordBot.Items;

namespace Ucu.Poo.DiscordBot.Domain.Tests;

public class DefensaTest
{
    [Test]
    public void probabilidadDeGanarTest()
    {
        Logica logica = new Logica(new InteraccionPorConsola());
        Jugador jugador = new Jugador("Jugador");
        Pokemon pokemon = new Pokemon("Charizard", "Fuego", 120, 80, 100);
        Pokemon pokemon1 = new Pokemon("Blastoise", "Agua", 100, 100, 80);
        Pokemon pokemon2 = new Pokemon("Hoopa", "Fantasma", 50, 200, 40);
        Pokemon pokemon3 = new Pokemon("Magmar", "Fuego", 60, 30, 40);
        Pokemon pokemon4 = new Pokemon("Pidgey", "Volador", 70, 20, 10);
        Pokemon pokemon5 = new Pokemon("Vulpix", "Fuego", 30, 40, 30);
        
        jugador.equipoPokemon.Add(pokemon);
        jugador.equipoPokemon.Add(pokemon1);
        jugador.equipoPokemon.Add(pokemon2);
        jugador.equipoPokemon.Add(pokemon3);
        jugador.equipoPokemon.Add(pokemon4);
        jugador.equipoPokemon.Add(pokemon5);
        
        //Devuelve 100 puntos porque tiene todos los pokemon sin ningun problema de estado y no gasto ningun objeto
        Assert.That(logica.probabilidadDeGanar(jugador), Is.EqualTo(100));
    }
    
    
    [Test]
    public void probabilidadDeGanarQuemadoTest()
    {
        Logica logica = new Logica(new InteraccionPorConsola());
        Jugador jugador = new Jugador("Jugador");
        Pokemon pokemon = new Pokemon("Charizard", "Fuego", 120, 80, 100);
        Pokemon pokemon1 = new Pokemon("Blastoise", "Agua", 100, 100, 80);
        Pokemon pokemon2 = new Pokemon("Hoopa", "Fantasma", 50, 200, 40);
        Pokemon pokemon3 = new Pokemon("Magmar", "Fuego", 60, 30, 40);
        Pokemon pokemon4 = new Pokemon("Pidgey", "Volador", 70, 20, 10);
        Pokemon pokemon5 = new Pokemon("Vulpix", "Fuego", 30, 40, 30);
        
        jugador.equipoPokemon.Add(pokemon);
        jugador.equipoPokemon.Add(pokemon1);
        jugador.equipoPokemon.Add(pokemon2);
        jugador.equipoPokemon.Add(pokemon3);
        jugador.equipoPokemon.Add(pokemon4);
        jugador.equipoPokemon.Add(pokemon5);
        pokemon1.Estado = "Quemado";
        
        //Devuelve 90 puntos porque no gasto objetos, tiene todos su pokemon vivo, pero tiene un pokemon bajo un problema de estado
        Assert.That(logica.probabilidadDeGanar(jugador), Is.EqualTo(90));
    }
    
    [Test]
    public void probabilidadDeGanarSin2PokesTest()
    {
        Logica logica = new Logica(new InteraccionPorConsola());
        Jugador jugador = new Jugador("Jugador");
        Pokemon pokemon = new Pokemon("Charizard", "Fuego", 120, 80, 100);
        Pokemon pokemon1 = new Pokemon("Blastoise", "Agua", 100, 100, 80);
        Pokemon pokemon2 = new Pokemon("Hoopa", "Fantasma", 50, 200, 40);
        Pokemon pokemon3 = new Pokemon("Magmar", "Fuego", 60, 30, 40);
        
        jugador.equipoPokemon.Add(pokemon);
        jugador.equipoPokemon.Add(pokemon1);
        jugador.equipoPokemon.Add(pokemon2);
        jugador.equipoPokemon.Add(pokemon3);
        
        //Devuelve 80 porque tiene 2 pokemon muertos
        Assert.That(logica.probabilidadDeGanar(jugador), Is.EqualTo(80));
    }
    
    [Test]
    public void probabilidadDeGanarSin2ItemTest()
    {
        Logica logica = new Logica(new InteraccionPorConsola());
        Jugador jugador = new Jugador("Jugador");
        Pokemon pokemon = new Pokemon("Charizard", "Fuego", 120, 80, 100);
        Pokemon pokemon1 = new Pokemon("Blastoise", "Agua", 100, 100, 80);
        Pokemon pokemon2 = new Pokemon("Hoopa", "Fantasma", 50, 200, 40);
        Pokemon pokemon3 = new Pokemon("Magmar", "Fuego", 60, 30, 40);
        Pokemon pokemon4 = new Pokemon("Pidgey", "Volador", 70, 20, 10);
        Pokemon pokemon5 = new Pokemon("Vulpix", "Fuego", 30, 40, 30);
        
        jugador.equipoPokemon.Add(pokemon);
        jugador.equipoPokemon.Add(pokemon1);
        jugador.equipoPokemon.Add(pokemon2);
        jugador.equipoPokemon.Add(pokemon3);
        jugador.equipoPokemon.Add(pokemon4);
        jugador.equipoPokemon.Add(pokemon5);
        jugador.Mochila.Remove(jugador.Mochila[1]);
        jugador.Mochila.Remove(jugador.Mochila[0]);
        
        //Devuelve 90 porque gasto 2 objetos
        Assert.That(logica.probabilidadDeGanar(jugador), Is.EqualTo(90));
    }
}