using NUnit.Framework;
using Library.Moves;

namespace Tests
{
    public class LluevehojasTests
    {
        private Lluevehojas _lluevehojas;

        [SetUp]
        public void Setup()
        {
            _lluevehojas = new Lluevehojas();
        }

        [Test]
        public void TestNombre()
        {
            Assert.AreEqual("Lluevehojas", _lluevehojas.Nombre);
        }

        [Test]
        public void TestAtaque()
        {
            Assert.AreEqual(20, _lluevehojas.Ataque);
        }

        [Test]
        public void TestTipo()
        {
            Assert.AreEqual("Planta", _lluevehojas.Tipo);
        }
    }
}
