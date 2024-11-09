using System;
using Library;
using Library.Moves;
using NUnit.Framework;

namespace LibraryTests
{
    [TestFixture]
    public class MovimientoTests
    {
        private Pokemon pokemonEnemigo;

        [SetUp]
        public void Setup()
        {
            // Modificar para incluir todos los parámetros del constructor
            pokemonEnemigo = new Pokemon("Charizard", "Fuego", 100, 100, 80);  // Asegúrate de pasar todos los parámetros
        }

        [Test]
        public void AplicarAtaquesEspeciales_DeberiaAplicarDormirCorrectamente()
        {
            var movimientoDormir = new Movimiento("Dormir", 0, "Psíquico", true);
            
            movimientoDormir.AplicarAtaquesEspeciales(pokemonEnemigo);

            Assert.AreEqual("Dormido", pokemonEnemigo.Estado);
            Assert.Greater(pokemonEnemigo.TurnosDormido, 0);
        }

        [Test]
        public void AplicarAtaquesEspeciales_DeberiaAplicarQuemarCorrectamente()
        {
            var movimientoQuemar = new Movimiento("Quemar", 0, "Fuego", true);
            
            movimientoQuemar.AplicarAtaquesEspeciales(pokemonEnemigo);

            Assert.AreEqual("Quemado", pokemonEnemigo.Estado);
        }

        [Test]
        public void AplicarAtaquesEspeciales_DeberiaAplicarParalizarCorrectamente()
        {
            var movimientoParalizar = new Movimiento("Paralizar", 0, "Eléctrico", true);
            
            movimientoParalizar.AplicarAtaquesEspeciales(pokemonEnemigo);

            Assert.AreEqual("Paralizado", pokemonEnemigo.Estado);
        }

        [Test]
        public void AplicarAtaquesEspeciales_DeberiaAplicarEnvenenarCorrectamente()
        {
            var movimientoEnvenenar = new Movimiento("Envenenar", 0, "Veneno", true);
            
            movimientoEnvenenar.AplicarAtaquesEspeciales(pokemonEnemigo);

            Assert.AreEqual("Envenenado", pokemonEnemigo.Estado);
        }

        [Test]
        public void AplicarAtaquesEspeciales_DeberiaNoAplicarEfectoSiNoEsEspecial()
        {
            var movimientoNormal = new Movimiento("Lanzallamas", 20, "Fuego", false);
            
            movimientoNormal.AplicarAtaquesEspeciales(pokemonEnemigo);

            Assert.IsNull(pokemonEnemigo.Estado);
        }

        [Test]
        public void AplicarAtaquesEspeciales_DeberiaNoAplicarEfectoSiEstadoYaEstaAplicado()
        {
            var movimientoQuemar = new Movimiento("Quemar", 0, "Fuego", true);
            pokemonEnemigo.Estado = "Quemado";
            
            movimientoQuemar.AplicarAtaquesEspeciales(pokemonEnemigo);

            Assert.AreEqual("Quemado", pokemonEnemigo.Estado); // El estado no debe cambiar
        }
    }
}
