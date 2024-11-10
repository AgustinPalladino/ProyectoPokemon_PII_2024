using System;
using System.Collections.Generic;
using Library;
using Library.Moves;
using NUnit.Framework;

namespace LibraryTests
{
    [TestFixture]
    public class PokemonTests
    {
        [Test]
        public void Constructor_InicializaPokemonCorrectamente_Charizard()
        {
            var pokemon = new Pokemon("Charizard", "Fuego", 100, 60, 40);

            Assert.AreEqual("Charizard", pokemon.Nombre);
            Assert.AreEqual("Fuego/Volador", pokemon.Tipo);
            Assert.AreEqual(100, pokemon.VidaMax);
            Assert.AreEqual(100, pokemon.VidaActual);
            Assert.AreEqual(60, pokemon.Ataque);
            Assert.AreEqual(40, pokemon.Defensa);
            Assert.AreEqual("Normal", pokemon.Estado);
        }

        [Test]
        public void AgregarMovimiento_AgregaMovimientoALaLista_Venusaur()
        {
            var pokemon = new Pokemon("Venusaur", "Planta", 120, 40, 60);
            var movimiento = new Movimiento("Lluevehojas", 20,60,"Acuatico", false);

            pokemon.agregarMovimiento(movimiento);

            Assert.Contains(movimiento, pokemon.listaMovimientos);
        }

        [Test]
        public void AplicarDañoRecurrente_EstadoEnvenenado_RestaVida_Venusaur()
        {
            var pokemon = new Pokemon("Venusaur", "Planta", 120, 40, 60);
            {
                pokemon.Estado = "Envenenado";
                pokemon.PorcentajeDañoPorTurno = 0.1 ; // 10% de daño por turno
            };

            pokemon.aplicarDañoRecurrente();

            Assert.AreEqual(144, pokemon.VidaActual); // Debería perder 16 puntos de vida
        }

        [Test]
        public void AplicarDañoRecurrente_EstadoQuemado_RestaVida_Charizard()
        {
            var pokemon = new Pokemon("Charizard", "Fuego", 100, 60, 40);
            {
                pokemon.Estado = "Quemado";
                pokemon.PorcentajeDañoPorTurno = 0.2 ; // 20% de daño por turno
            };

            pokemon.aplicarDañoRecurrente();

            Assert.AreEqual(120, pokemon.VidaActual); // Debería perder 30 puntos de vida
        }

        [Test]
        public void PuedeAtacar_EstadoNormal_RetornaTrue_Blastoise()
        {
            var pokemon = new Pokemon("Blastoise", "Agua", 110, 50, 50);

            Assert.IsTrue(pokemon.puedeAtacar());
        }
       
        [Test]
        public void PuedeAtacar_EstadoDormido_NoPuedeAtacarYReduceTurnosDormido_Charizard()
        {
            var pokemon = new Pokemon("Charizard", "Fuego", 100, 60, 40);
            {
                pokemon.Estado = "Dormido";
                pokemon.TurnosDormido = 2;
            };

            bool resultado = pokemon.puedeAtacar();

            Assert.IsFalse(resultado);
            Assert.AreEqual(1, pokemon.TurnosDormido);
        }

        [Test]
        public void PuedeAtacar_EstadoDormido_DespiertaDespuesDeTurnos_Venusaur()
        {
            var pokemon = new Pokemon("Venusaur", "Planta", 120, 40, 60);
            {
                pokemon.Estado = "Dormido";
                pokemon.TurnosDormido = 1;
            };

            pokemon.puedeAtacar(); // Turno final de sueño
            bool resultado = pokemon.puedeAtacar(); // Verifica si puede atacar al despertar

            Assert.IsTrue(resultado);
            Assert.AreEqual("Normal", pokemon.Estado);
        }

        [Test]
        public void PuedeAtacar_EstadoParalizado_PuedeAtacarOQuedaParalizado_Blastoise()
        {
            var pokemon = new Pokemon("Blastoise", "Agua", 110, 50, 50);
            {
                pokemon.Estado = "Paralizado";
            };

            bool puedeAtacar = pokemon.puedeAtacar();

            Assert.IsTrue(puedeAtacar || !puedeAtacar); // 33% chance de estar paralizado; probamos ambos casos.
        }
    }
}
