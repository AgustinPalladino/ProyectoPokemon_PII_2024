using NUnit.Framework;
using Library;

namespace LibraryTests
{
    [TestFixture]
    public class CuraTotalTests
    {
        [Test]
        public void Usar_DeberiaCurarPokemonDeCualquierEstado()
        {
            var jugador = new Jugador("Jugador1");
            var charizard = new Pokemon("Charizard", "Fuego", 100, 60, 40);
            jugador.agregarPokemon(charizard);
            var curaTotal = new CuraTotal();

            charizard.Estado = "Quemado";
            curaTotal.Usar(jugador);

            Assert.AreEqual("Normal", charizard.Estado);
        }

        [Test]
        public void Usar_DeberiaNoCurarPokemonSiEstaIncapacitado()
        {
            var jugador = new Jugador("Jugador1");
            var blastoise = new Pokemon("Blastoise", "Agua", 110, 50, 50);
            jugador.agregarPokemon(blastoise);
            var curaTotal = new CuraTotal();

            blastoise.VidaActual = 0;
            curaTotal.Usar(jugador);

            Assert.AreEqual(0, blastoise.VidaActual);
            Assert.AreEqual("Normal", blastoise.Estado);
        }
    }
}
