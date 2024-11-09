using NUnit.Framework;
using Library;
using Library.Moves;

namespace LibraryTests
{
    [TestFixture]
    public class SuperPocionTests
    {
        [Test]
        public void Usar_DeberiaRestaurarVidaCorrectamente()
        {
            var jugador = new Jugador("Jugador1");
            var blastoise = new Pokemon("Blastoise", "Agua", 110, 50, 50);
            jugador.agregarPokemon(blastoise);
            var superPocion = new SuperPocion();
            
            blastoise.VidaActual = 40;
            superPocion.Usar(jugador);
            
            Assert.AreEqual(110, blastoise.VidaActual);
        }

        [Test]
        public void Usar_DeberiaNoRestaurarVidaSiPokemonEstaIncapacitado()
        {
            var jugador = new Jugador("Jugador1");
            var charizard = new Pokemon("Charizard", "Fuego", 100, 60, 40);
            jugador.agregarPokemon(charizard);
            var superPocion = new SuperPocion();
            
            charizard.VidaActual = 0;
            superPocion.Usar(jugador);
            
            Assert.AreEqual(0, charizard.VidaActual);
        }
    }
}
