using NUnit.Framework;
using Library.Moves;

namespace Tests
{
    public class LanzallamasTests
    {
        private Lanzallamas _lanzallamas;

        [SetUp]
        public void Setup()
        {
            _lanzallamas = new Lanzallamas();
        }

        [Test]
        public void TestNombre()
        {
            Assert.AreEqual("Lanzallamas", _lanzallamas.Nombre);
        }

        [Test]
        public void TestAtaque()
        {
            Assert.AreEqual(20, _lanzallamas.Ataque);
        }

        [Test]
        public void TestTipo()
        {
            Assert.AreEqual("Fuego", _lanzallamas.Tipo);
        }
    }
}
