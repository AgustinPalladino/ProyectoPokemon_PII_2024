using Library;

namespace Tests;

public class PokemonTests
{
    [Test]
    public void PruebaPosicionPokemonExitosa()
    {  
        List<Pokemon> listaPokemon = new List<Pokemon>();
        CreadorDePokemon creadorDePokemon = new CreadorDePokemon();
        listaPokemon = creadorDePokemon.listaPokemon;
        Assert.That(listaPokemon[0].Nombre == "Venusaur");
    }
    
    
    [Test]
    public void PruebaPosicionPokemonFallida()
    {  
        List<Pokemon> listaPokemon = new List<Pokemon>();
        CreadorDePokemon creadorDePokemon = new CreadorDePokemon();
        listaPokemon = creadorDePokemon.listaPokemon;
        Assert.That(listaPokemon[1].Nombre == "Venusaur");
    }
    
    [Test]
    public void PruebaEstadisticaPokemonExitosa()
    {  
        List<Pokemon> listaPokemon = new List<Pokemon>();
        CreadorDePokemon creadorDePokemon = new CreadorDePokemon();
        listaPokemon = creadorDePokemon.listaPokemon;
        Assert.That(listaPokemon[1].VidaMax == 100);
    }
    
    [Test]
    public void PruebaEstadisticaPokemonFallida()
    {  
        List<Pokemon> listaPokemon = new List<Pokemon>();
        CreadorDePokemon creadorDePokemon = new CreadorDePokemon();
        listaPokemon = creadorDePokemon.listaPokemon;
        Assert.That(listaPokemon[1].VidaMax == 120);
    }
}