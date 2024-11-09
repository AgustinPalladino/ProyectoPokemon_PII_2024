using NUnit.Framework;
using Library;
using System;

namespace LibraryTests
{
    [TestFixture]
    public class OperacionesStaticTests
    {
        [Test]
        public void BonificacionTipos_ExistenBonificaciones_DeberiaRetornarMultiplicador()
        {
            double resultado = OperacionesStatic.bonificacionTipos("Agua", "Fuego");
            Assert.AreEqual(0.5, resultado);

            resultado = OperacionesStatic.bonificacionTipos("Fuego", "Planta");
            Assert.AreEqual(0.5, resultado);

            resultado = OperacionesStatic.bonificacionTipos("Veneno", "Psíquico");
            Assert.AreEqual(2, resultado);
        }

        [Test]
        public void BonificacionTipos_NoExistenBonificaciones_DeberiaRetornar1()
        {
            
            double resultado = OperacionesStatic.bonificacionTipos("Hielo", "Fuego");
            Assert.AreEqual(1, resultado);

            
            resultado = OperacionesStatic.bonificacionTipos("Lucha", "Eléctrico");
            Assert.AreEqual(1, resultado);
        }

        [Test]
        public void CalcularCritico_GolpeCritico_DeberiaRetornar1_2()
        {
            double resultado = OperacionesStatic.CalcularCritico(100);
            Assert.AreEqual(1.2, resultado, 0.1); 
        }

        [Test]
        public void CalcularCritico_SinGolpeCritico_DeberiaRetornar1_0()
        {
            double resultado = OperacionesStatic.CalcularCritico(60);
            Assert.AreEqual(1.0, resultado);
        }
    }
}
