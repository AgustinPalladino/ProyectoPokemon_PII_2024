using Ucu.Poo.DiscordBot.Interaccion;
using Ucu.Poo.DiscordBot.Items;

namespace Ucu.Poo.DiscordBot.Domain.Tests;

public class ItemTest
{
    [Test]
    public void itemCuraTotal()
    {
        var jugador = new Jugador("Jugador1");
        var charizard = new Pokemon("Charizard", "Fuego", 100, 60, 40);
        jugador.agregarPokemon(charizard);

        var curaTotal = new CuraTotal();
        charizard.Estado = "Quemado";
        
        curaTotal.Usar(jugador, new InteraccionPorConsola());
        Assert.That(curaTotal.Nombre, Is.EqualTo("CuraTotal"));
        Assert.That(charizard.Estado, Is.EqualTo("Normal"));
    }
    
    //[Test]
    //public void itemRevivir()
    //{
    //  var jugador = new Jugador("Jugador1");
    //  var charizard = new Pokemon("Charizard", "Fuego", 100, 60, 40);
    //  jugador.agregarPokemon(charizard);

    //    var revivir = new Revivir();
    //  charizard.VidaActual = 0;
        
    //  revivir.Usar(jugador); // Se tranca porque el metodo usar usa la consola, esperar a que cambie.
        
    //  Assert.That(charizard.VidaActual, Is.EqualTo(100));
    // }
    
    [Test]
    public void itemSuperpocion()
    {
        var jugador = new Jugador("Jugador1");
        var charizard = new Pokemon("Charizard", "Fuego", 100, 60, 40);
        jugador.agregarPokemon(charizard);

        var sPocion = new SuperPocion();
        charizard.VidaActual = 40;
        
        sPocion.Usar(jugador, new InteraccionPorConsola()); 
        Assert.That(sPocion.Nombre, Is.EqualTo("SuperPocion"));
        Assert.That(charizard.VidaActual, Is.EqualTo(100));
    }
}