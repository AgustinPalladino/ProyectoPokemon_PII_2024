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
        public void CalcularCritico_GolpeCritico_DeberiaRetornar1_0()
        {
            bool esNormal = false;

            for (int i = 0; i < 100; i++)
            {
                double resultado = OperacionesStatic.CalcularCritico(100);
                if (resultado == 1.0)
                {
                    esNormal = true;
                    break;
                }
            }

            Assert.IsTrue(esNormal, "Por probabilidad, 1 critcio en 100 intentos");
        }
    }
}
