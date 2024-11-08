using NUnit.Framework;
using Library;

namespace LibraryTests
{
    [TestFixture]
    public class RevivirTests
    {
        [Test]
        public void Usar_DeberiaRevivirPokemonIncapacitado()
        {
            var jugador = new Jugador("Jugador1");
            var blastoise = new Pokemon("Blastoise", "Agua", 110, 50, 50);
            jugador.agregarPokemon(blastoise);
            var revivir = new Revivir();

            blastoise.VidaActual = 0;
            revivir.Usar(jugador);

            Assert.AreEqual(blastoise.VidaMax / 2, blastoise.VidaActual);
            Assert.AreEqual("Normal", blastoise.Estado);
        }

        [Test]
        public void Usar_DeberiaNoRevivirSiPokemonEstaVivo()
        {
            var jugador = new Jugador("Jugador1");
            var venusaur = new Pokemon("Venusaur", "Planta", 120, 40, 60);
            jugador.agregarPokemon(venusaur);
            var revivir = new Revivir();

            venusaur.VidaActual = 50;
            revivir.Usar(jugador);

            Assert.AreEqual(50, venusaur.VidaActual);
        }
    }
}
