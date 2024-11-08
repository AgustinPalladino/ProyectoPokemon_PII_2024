using NUnit.Framework;
using Library.Moves;

namespace Tests
{
    public class HidrocañonTests
    {
        private Hidrocañon _hidrocañon;

        [SetUp]
        public void Setup()
        {
            _Hidrocañon = new Hidrocañon();
        }

        [Test]
        public void TestNombre()
        {
            Assert.AreEqual("Hidrocañon", _hidrocañon.Nombre);
        }

        [Test]
        public void TestAtaque()
        {
            Assert.AreEqual(20, _hidrocañon.Ataque);
        }

        [Test]
        public void TestTipo()
        {
            Assert.AreEqual("Agua", _hidrocañon.Tipo);
        }
    }
}
