using Ucu.Poo.DiscordBot.Interaccion;

namespace Ucu.Poo.DiscordBot.Domain.Tests;

public class DiccionariosyOpStaticTest
{
    [Test]
    public void BonificacionTipos_ExistenBonificaciones_DeberiaRetornarMultiplicador()
    {
        double resultado = DiccionariosYOperacionesStatic.bonificacionTipos("Agua", "Fuego", new InteraccionPorConsola());
        Assert.That(2.0, Is.EqualTo(resultado));

    }

    [Test]
    public void BonificacionTipos_NoExistenBonificaciones_DeberiaRetornar1()
    {
        
        double resultado = DiccionariosYOperacionesStatic.bonificacionTipos("Hielo", "Fuego", new InteraccionPorConsola());
        Assert.AreEqual(1, resultado);

        
        resultado = DiccionariosYOperacionesStatic.bonificacionTipos("Lucha", "Eléctrico", new InteraccionPorConsola());
        Assert.AreEqual(1, resultado);
    }
    

    [Test]
    public void CalcularCritico_GolpeCritico_DeberiaRetornar1_0()
    {
        bool esNormal = false;

        for (int i = 0; i < 100; i++)
        {
            double resultado = DiccionariosYOperacionesStatic.CalcularCritico(100, new InteraccionPorConsola());
            if (resultado == 1.0)
            {
                esNormal = true;
                break;
            }
        }

        Assert.IsTrue(esNormal, "Por probabilidad, 1 critcio en 100 intentos");
    }

    [Test]
    public void PrecisionTest()
    {
        bool esNormal = false;
        var ataque = new Movimiento("Lanzallamas", 20, 1, "fuego", false);
        for (int i = 0; i < 100; i++)
        {
            double resultado = DiccionariosYOperacionesStatic.Precision(ataque.Precision, ataque.Ataque, new InteraccionPorConsola());
            if (resultado == 20.0)
            {
                esNormal = true;
                break;
            }
        }

        Assert.IsTrue(esNormal, "Por probabilidad, 1 critcio en 100 intentos");
    }
}