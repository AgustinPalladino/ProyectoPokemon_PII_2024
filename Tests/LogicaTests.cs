using Library;

namespace Tests;

public class LogicaTests
{
    [Test]
    public void PruebaPosicionPokemon()
    {
        CreadorDePokemonYMovimiento creadorDePokemonYMovimiento = new CreadorDePokemonYMovimiento();
        Logica logica = new Logica();
        Assert.That(logica.listaPokemon[0].Nombre == "Venusaur");
    }
    
    [Test]
    public void PruebaEstadisticaPokemon()
    {
        CreadorDePokemonYMovimiento creadorDePokemonYMovimiento = new CreadorDePokemonYMovimiento();
        Logica logica = new Logica();
        Assert.That(logica.listaPokemon[1].VidaMax == 100);
    }
}