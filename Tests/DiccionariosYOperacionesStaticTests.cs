using NUnit.Framework;
using Library;
using System;

namespace LibraryTests
{
    [TestFixture]
    public class DiccionariosYOperacionesStaticTests
    {
        [Test]
        public void BonificacionTipos_ExistenBonificaciones_DeberiaRetornarMultiplicador()
        {
            double resultado = DiccionariosYOperacionesStatic.bonificacionTipos("Agua", "Fuego");
            Assert.AreEqual(0.5, resultado);

            resultado = DiccionariosYOperacionesStatic.bonificacionTipos("Fuego", "Planta");
            Assert.AreEqual(0.5, resultado);

            resultado = DiccionariosYOperacionesStatic.bonificacionTipos("Veneno", "Psíquico");
            Assert.AreEqual(2, resultado);
        }

        [Test]
        public void BonificacionTipos_NoExistenBonificaciones_DeberiaRetornar1()
        {
            
            double resultado = DiccionariosYOperacionesStatic.bonificacionTipos("Hielo", "Fuego");
            Assert.AreEqual(1, resultado);

            
            resultado = DiccionariosYOperacionesStatic.bonificacionTipos("Lucha", "Eléctrico");
            Assert.AreEqual(1, resultado);
        }
        

        [Test]
        public void CalcularCritico_GolpeCritico_DeberiaRetornar1_0()
        {
            bool esNormal = false;

            for (int i = 0; i < 100; i++)
            {
                double resultado = DiccionariosYOperacionesStatic.CalcularCritico(100);
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
