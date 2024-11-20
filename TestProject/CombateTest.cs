using Library;

namespace TestProject;

public class CombateTest
{
    [SetUp]
    public void Setup()
    {
        
    }

    [Test]
    public void mostrarCatalogo()
    {
        var expectedPokemonNames = new List<string> { "Blastoise", "Charizard", "Venusaur" };
        var listaPokemon = new List<Pokemon>
        {
            new Pokemon("Blastoise", "Agua", 100, 100, 80),
            new Pokemon("Charizard", "Fuego", 120, 80, 100),
            new Pokemon("Venusaur", "Planta", 90, 85, 80)
        };
        foreach (var pokemon in listaPokemon)
        {
            Assert.Contains(pokemon.Nombre, expectedPokemonNames);
        }
        
        Assert.That(listaPokemon[0].Nombre, Is.EqualTo("Blastoise"));
        Assert.That(listaPokemon[1].Nombre, Is.EqualTo("Charizard"));
    }

}