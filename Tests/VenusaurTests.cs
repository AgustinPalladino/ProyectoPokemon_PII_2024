using NUnit.Framework;
using Library.Moves;
using Library.Pokemon;
using System.Linq;

namespace Tests
{
    public class VenusaurTests
    {
        private Venusaur _venusaur;

        [SetUp]
        public void Setup()
        {
            _venusaur = new Venusaur();
        }

        [Test]
        public void TestNombre()
        {
            Assert.AreEqual("Venusaur", _venusaur.Nombre);
        }

        [Test]
        public void TestTipo()
        {
            Assert.AreEqual("Planta", _venusaur.Tipo);
        }

        [Test]
        public void TestEstado()
        {
            Assert.AreEqual("Neutral", _venusaur.Estado);
            _venusaur.Estado = "Paralizado";
            Assert.AreEqual("Paralizado", _venusaur.Estado);
        }

        [Test]
        public void TestVida()
        {
            Assert.AreEqual(150, _venusaur.Vida);
        }

        [Test]
        public void TestVidaActual()
        {
            _venusaur.VidaActual = 120;
            Assert.AreEqual(120, _venusaur.VidaActual);
        }

        [Test]
        public void TestListaMovimientos()
        {
            Assert.IsTrue(_venusaur.listaMovimientos.Any());
            Assert.AreEqual("Lluevehojas", _venusaur.listaMovimientos.First().Nombre);
        }

        [Test]
        public void TestAtaque()
        {
            Assert.AreEqual(45, _venusaur.Ataque);
        }

        [Test]
        public void TestDefensa()
        {
            Assert.AreEqual(45, _venusaur.Defensa);
        }
    }
}
