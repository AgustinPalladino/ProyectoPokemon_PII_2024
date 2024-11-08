using NUnit.Framework;
using Library.Moves;
using Library.Pokemon;
using System.Linq;

namespace Tests
{
    public class BlastoiseTests
    {
        private Blastoise _blastoise;

        [SetUp]
        public void Setup()
        {
            _blastoise = new Blastoise();
        }

        [Test]
        public void TestNombre()
        {
            Assert.AreEqual("Blastoise", _blastoise.Nombre);
        }

        [Test]
        public void TestTipo()
        {
            Assert.AreEqual("Agua", _blastoise.Tipo);
        }

        [Test]
        public void TestEstado()
        {
            Assert.AreEqual("Neutral", _blastoise.Estado);
            _blastoise.Estado = "Envenenado";
            Assert.AreEqual("Envenenado", _blastoise.Estado);
        }

        [Test]
        public void TestVida()
        {
            Assert.AreEqual(145, _blastoise.Vida);
        }

        [Test]
        public void TestVidaActual()
        {
            _blastoise.VidaActual = 100;
            Assert.AreEqual(100, _blastoise.VidaActual);
        }

        [Test]
        public void TestListaMovimientos()
        {
            Assert.IsTrue(_blastoise.listaMovimientos.Any());
            Assert.AreEqual("Hidrocañon", _blastoise.listaMovimientos.First().Nombre);
        }

        [Test]
        public void TestAtaque()
        {
            Assert.AreEqual(50, _blastoise.Ataque);
        }

        [Test]
        public void TestDefensa()
        {
            Assert.AreEqual(60, _blastoise.Defensa);
        }
    }
}
