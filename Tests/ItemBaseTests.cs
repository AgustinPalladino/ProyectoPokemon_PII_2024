using NUnit.Framework;
using Library;

namespace LibraryTests
{
    [TestFixture]
    public class ItemTests
    {
        [Test]
        public void Usar_DeberiaUsarElItemCorrectamente()
        {
            var jugador = new Jugador("Jugador1");
            var charizard = new Pokemon("Charizard", "Fuego", 100, 60, 40);
            jugador.agregarPokemon(charizard);

            var curaTotal = new CuraTotal();
            charizard.Estado = "Quemado";  // Se establece un estado al Pokémon.

            curaTotal.Usar(jugador);  // Usamos el item.

            Assert.AreEqual("Normal", charizard.Estado);  // Verificamos que el estado del Pokémon se haya restablecido.
        }
    }
}
