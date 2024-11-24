using Library;
using Library.Interaccion;
using NSubstitute;

namespace TestProject;

public class HisotriaUsuario1Test
{
    private Jugador jugador1;
    private Jugador jugador2;
    private IInteraccionConUsuario mockInteraccion;
    private Logica logica;
    
    [Test]
    public void SeleccionarEquipo_AgregaSeisPokemons_Correctamente()
    {
        mockInteraccion = Substitute.For<IInteraccionConUsuario>();
        jugador1 = new Jugador("Ash");
        jugador2 = new Jugador("Misty");
        DiccionariosYOperacionesStatic.DiccionarioPokemon = new Dictionary<string, Pokemon>
        {
            { "Pikachu", new Pokemon("Pikachu", "Eléctrico", 100, 50, 40) },
            { "Charmander", new Pokemon("Charmander", "Fuego", 90, 60, 35) },
            { "Squirtle", new Pokemon("Squirtle", "Agua", 95, 45, 50) },
            { "Bulbasaur", new Pokemon("Bulbasaur", "Planta", 100, 50, 40) },
            { "Jigglypuff", new Pokemon("Jigglypuff", "Normal", 80, 40, 30) },
            { "Meowth", new Pokemon("Meowth", "Normal", 85, 50, 35) }
        };

        
        // Simula entradas para seleccionar 6 Pokémons.
        
        mockInteraccion.LeerEntrada().Returns("Pikachu", "Charmander", "Squirtle", "Bulbasaur", "Jigglypuff", "Meowth");
        logica.EscogerEquipo(jugador1);
        // Verifica que se hayan agregado exactamente 6 Pokémons.
        Assert.That(jugador1.equipoPokemon.Count, Is.EqualTo(6) );

        // Verifica que los nombres sean correctos.
      //  Assert.That(jugador1.equipoPokemon, Has.Some.Matches<Pokemon>(p => p.Nombre == "Charizard"));
        //Assert.That(jugador1.equipoPokemon, Has.Some.Matches<Pokemon>(p => p.Nombre == "Pikachu"));
    }

}