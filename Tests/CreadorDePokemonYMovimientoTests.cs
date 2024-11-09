using NUnit.Framework;
using Library;

namespace Library.Tests
{
    [TestFixture]
    public class CreadorDePokemonYMovimientoTests
    {
        [Test]
        public void AgregarPokemon_DeberiaAgregarPokemonsALaLista()
        {
            var creador = new CreadorDePokemonYMovimiento();
            var listaPokemon = creador.listaPokemon;

            Assert.AreEqual(3, listaPokemon.Count);
            Assert.AreEqual("Venusaur", listaPokemon[0].Nombre);
            Assert.AreEqual("Charizard", listaPokemon[1].Nombre);
            Assert.AreEqual("Blastoise", listaPokemon[2].Nombre);
        }

        [Test]
        public void AgregarMovimiento_DeberiaTenerMovimientosCorrectos()
        {
            var creador = new CreadorDePokemonYMovimiento();
            var listaPokemon = creador.listaPokemon;

            // Verificando los movimientos de Venusaur
            Assert.IsTrue(EsMovimientoPresente(listaPokemon[0], "Arañazo"));
            Assert.IsTrue(EsMovimientoPresente(listaPokemon[0], "Lanzallamas"));

            // Verificando los movimientos de Charizard
            Assert.IsTrue(EsMovimientoPresente(listaPokemon[1], "Lluevehojas"));
            Assert.IsTrue(EsMovimientoPresente(listaPokemon[1], "Hidrocañon"));

            // Verificando los movimientos de Blastoise
            Assert.IsTrue(EsMovimientoPresente(listaPokemon[2], "Dormir"));
            Assert.IsTrue(EsMovimientoPresente(listaPokemon[2], "Envenenar"));
        }

        private bool EsMovimientoPresente(Pokemon pokemon, string movimiento)
        {
            foreach (var mov in pokemon.listaMovimientos)
            {
                if (mov.Nombre == movimiento)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
