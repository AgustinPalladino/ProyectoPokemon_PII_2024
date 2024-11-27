namespace Ucu.Poo.DiscordBot.Domain.Tests;

public class CombateTest
{
    [Test]
    public void mostrarCatalogo()
    {
        string mostrarCatalogo = "\n Catálogo de Pokémon disponibles:";
        foreach (var pokemon in DiccionariosYOperacionesStatic.DiccionarioPokemon)
        {
            mostrarCatalogo += $"\n-{pokemon.Value.Nombre}";
        }
        
        Assert.That(Combate.MostrarCatalogo(), Is.EqualTo(mostrarCatalogo));
    }
}