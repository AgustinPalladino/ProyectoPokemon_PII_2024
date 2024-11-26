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

        CuraTotal curaTotal = new CuraTotal();
        charizard.Estado = "Quemado";
        
        curaTotal.SacarEstadoPokemon(charizard);
        
        //Prueba si cura su estado
        Assert.That(curaTotal.Nombre, Is.EqualTo("CuraTotal"));
        Assert.That(curaTotal.Descripcion, Is.EqualTo("Cura cualquier estado"));
        Assert.That(charizard.Estado, Is.EqualTo("Normal"));
        
        //Prueba que string retorna Usar
        //prueba si el pokemon utiliza el curar
        charizard.Estado = "Quemado";
        Assert.That(curaTotal.Usar(jugador, "Charizard"), Is.EqualTo("Se ha utilizado el objeto correctamente"));
        
        //prueba si ya esta en estado Normal
        Assert.That(curaTotal.Usar(jugador, "Charizard"),
            Is.EqualTo("No puedes usar el ítem ya que el Pokémon está en estado normal."));
        
        //prueba si el nombre del pokemon es incorrecto
        Assert.That(curaTotal.Usar(jugador, "Alberto"), Is.EqualTo("Pokemon incorrecto"));
        
        //prueba si volvio hacia atras
        Assert.That(curaTotal.Usar(jugador, "0"), Is.EqualTo("Usted volvio hacia atras"));
    }
    
    
    
    [Test]
    public void itemRevivir()
    {
    Jugador jugador = new Jugador("Jugador1");
    Pokemon charizard = new Pokemon("Charizard", "Fuego", 100, 60, 40);
    jugador.agregarPokemon(charizard);

    var revivir = new Revivir();
    charizard.VidaActual = 0;
        
    //Prueba de si revive el pokemon con la mitad de su vida
    revivir.RevivirPokemon(jugador, charizard);
    Assert.That(revivir.Nombre, Is.EqualTo("Revivir"));
    Assert.That(revivir.Descripcion, Is.EqualTo("Revive a un pokemon con la mitad de su vida"));
    Assert.That(charizard.VidaActual, Is.EqualTo(50));
    
    
    //Prueba que string retorna Usar
    //prueba de que no tiene ningun pokemon muerto
    Assert.That(revivir.Usar(jugador, "Charizard"), Is.EqualTo("No tiene ningun pokemon derrotado"));
        
    //prueba de si revivio algun pokemon
    charizard.VidaActual = 0;
    jugador.equipoPokemonDerrotados.Add(charizard);
    Assert.That(revivir.Usar(jugador, "Charizard"),
        Is.EqualTo("Se ha utilizado el objeto correctamente"));
        
    
    jugador.equipoPokemonDerrotados.Add(charizard);
    //prueba si el nombre del pokemon es incorrecto
    Assert.That(revivir.Usar(jugador, "Alberto"), Is.EqualTo("Pokemon incorrecto"));
        
    //prueba si volvio hacia atras
    Assert.That(revivir.Usar(jugador, "0"), Is.EqualTo("Usted volvio hacia atras"));
    }
    
    
    
    [Test]
    public void itemSuperpocion()
    {
        var jugador = new Jugador("Jugador1");
        var charizard = new Pokemon("Charizard", "Fuego", 100, 60, 40);
        jugador.agregarPokemon(charizard);

        var sPocion = new SuperPocion();
        
        
        //prueba si no supera la cantidad max de vida
        charizard.VidaActual = 30;
        sPocion.CurarPokemon(charizard); 
        Assert.That(sPocion.Nombre, Is.EqualTo("SuperPocion"));
        Assert.That(sPocion.Descripcion, Is.EqualTo("Recupera 70 puntos de vida"));
        Assert.That(charizard.VidaActual, Is.EqualTo(100));
        
        //prueba si supera la cantidad max de vida
        charizard.VidaActual = 50;
        sPocion.CurarPokemon(charizard); 
        Assert.That(charizard.VidaActual, Is.EqualTo(100));
        
        
        //Prueba que string retorna Usar
        //prueba si el pokemon utiliza el curar
        charizard.VidaActual = 50;
        Assert.That(sPocion.Usar(jugador, "Charizard"), Is.EqualTo("Se ha utilizado el objeto correctamente"));
        
        //prueba si la vida ya esta al maximo
        charizard.VidaActual = charizard.VidaMax;
        Assert.That(sPocion.Usar(jugador, "Charizard"),
            Is.EqualTo($"{charizard.Nombre} No puedes restaurar mas vida ya que ya esta al maximo."));
        
        //prueba si el nombre del pokemon es incorrecto
        Assert.That(sPocion.Usar(jugador, "Alberto"), Is.EqualTo("Pokemon incorrecto"));
        
        //prueba si volvio hacia atras
        Assert.That(sPocion.Usar(jugador, "0"), Is.EqualTo("Usted volvio hacia atras"));
        
        
    }
}