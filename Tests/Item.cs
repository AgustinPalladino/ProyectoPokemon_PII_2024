using NUnit.Framework;
using Library;

namespace LibraryTests;

[TestFixture]
public class Item
{
    [Test]
    public void itemCuraTotal()
    {
        var jugador = new Jugador("Jugador1");
        var charizard = new Pokemon("Charizard", "Fuego", 100, 60, 40);
        jugador.agregarPokemon(charizard);

        var curaTotal = new CuraTotal();
        charizard.Estado = "Quemado";
        
        curaTotal.Usar(jugador);
        
        Assert.That(charizard.Estado, Is.EqualTo("Normal"));
    }
}