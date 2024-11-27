using NSubstitute;
using Ucu.Poo.DiscordBot.Interaccion;

namespace Ucu.Poo.DiscordBot.Domain.Tests;

public class HistoriaUsuario6Test
{
    private Jugador jugador1;
    private Jugador jugador2;
    private IInteraccionConUsuario mockInteraccion;
    private Logica logica;
    
    [Test]
    public void hdUsuario6Test()
    {
        
        mockInteraccion = Substitute.For<IInteraccionConUsuario>();
        var logica = new Logica(new InteraccionPorConsola());
        var jugador1 = new Jugador("Jugador1");
        var jugador2 = new Jugador("Jugador2");
        var pokemon1 = new Pokemon("Blastoise", "Agua", 100, 100, 80); 
        var pokemon2 = new Pokemon("Charizard", "Fuego", 120, 80, 100);
        
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
}