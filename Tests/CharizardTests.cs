using NUnit.Framework;
using Library.Moves;
using Library.Pokemon;
using System.Linq;

namespace Tests
{
    public class CharizardTests
    {
        private Charizard _charizard;

        [SetUp]
        public void Setup()
        {
            _charizard = new Charizard();
        }

        [Test]
        public void TestNombre()
        {
            Assert.AreEqual("Charizard", _charizard.Nombre);
        }

        [Test]
        public void TestTipo()
        {
            Assert.AreEqual("Fuego", _charizard.Tipo);
        }

        [Test]
        public void TestEstado()
        {
            Assert.AreEqual("Neutral", _charizard.Estado);
            _charizard.Estado = "Envenenado";
            Assert.AreEqual("Envenenado", _charizard.Estado);
        }

        [Test]
        public void TestVida()
        {
            Assert.AreEqual(140, _charizard.Vida);
        }

        [Test]
        public void TestVidaActual()
        {
            _charizard.VidaActual = 100;
            Assert.AreEqual(100, _charizard.VidaActual);
        }

        [Test]
        public void TestListaMovimientos()
        {
            Assert.IsTrue(_charizard.listaMovimientos.Any());
            Assert.AreEqual("Arañazo", _charizard.listaMovimientos.First().Nombre);
        }

        [Test]
        public void TestAtaque()
        {
            Assert.AreEqual(70, _charizard.Ataque);
        }

        [Test]
        public void TestDefensa()
        {
            Assert.AreEqual(50, _charizard.Defensa);
        }
    }
}
