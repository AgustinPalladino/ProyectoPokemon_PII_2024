using System;
using System.Collections.Generic;
using NUnit.Framework;
using Library;
using Library.Moves;

namespace Tests
{
    [TestFixture]
    public class HDeUsuario1test
    {
        private CreadorDePokemonYMovimiento creador;
        private Jugador jugador;

        [SetUp]
        public void SetUp()
        {
            creador = new CreadorDePokemonYMovimiento();
            jugador = new Jugador("1");
        }

        [Test]
        public void Jugador_DeberiaPoderSeleccionar6Pokemon()
        {
            var catalogo = creador.listaPokemon;
            
            Assert.GreaterOrEqual(catalogo.Count, 6, "El catálogo debería tener al menos 6 Pokémon disponibles");

            jugador.agregarPokemon(catalogo[0]);
            jugador.agregarPokemon(catalogo[1]);
            jugador.agregarPokemon(catalogo[2]);
            jugador.agregarPokemon(catalogo[3]);
            jugador.agregarPokemon(catalogo[4]);
            jugador.agregarPokemon(catalogo[5]);

            Assert.That(jugador.equipoPokemon.Count, Is.EqualTo(6), "El equipo del jugador debe tener exactamente 6 Pokémon");

            Assert.That(jugador.equipoPokemon[0].Nombre, Is.EqualTo(catalogo[0].Nombre));
            Assert.That(jugador.equipoPokemon[1].Nombre, Is.EqualTo(catalogo[1].Nombre));
            Assert.That(jugador.equipoPokemon[2].Nombre, Is.EqualTo(catalogo[2].Nombre));
            Assert.That(jugador.equipoPokemon[3].Nombre, Is.EqualTo(catalogo[3].Nombre));
            Assert.That(jugador.equipoPokemon[4].Nombre, Is.EqualTo(catalogo[4].Nombre));
            Assert.That(jugador.equipoPokemon[5].Nombre, Is.EqualTo(catalogo[5].Nombre));
        }

        [Test]
        public void Jugador_NoDebePoderAgregarMasDe6Pokemon()
        {
            var catalogo = creador.listaPokemon;
            
            Assert.GreaterOrEqual(catalogo.Count, 7, "El catálogo debería tener al menos 7 Pokémon disponibles");

            jugador.agregarPokemon(catalogo[0]);
            jugador.agregarPokemon(catalogo[1]);
            jugador.agregarPokemon(catalogo[2]);
            jugador.agregarPokemon(catalogo[3]);
            jugador.agregarPokemon(catalogo[4]);
            jugador.agregarPokemon(catalogo[5]);

            jugador.agregarPokemon(catalogo[6]);

            Assert.That(jugador.equipoPokemon.Count, Is.EqualTo(6), "El equipo del jugador no debe tener más de 6 Pokémon");
        }

        [Test]
        public void Jugador_DebePoderOrdenarPokemonEnEquipo()
        {
            var catalogo = creador.listaPokemon;
            
            jugador.agregarPokemon(catalogo[0]);
            jugador.agregarPokemon(catalogo[1]);
            jugador.agregarPokemon(catalogo[2]);

            jugador.cambiarPokemon(catalogo[1]);

            Assert.That(jugador.pokemonEnCancha().Nombre, Is.EqualTo(catalogo[1].Nombre), "El Pokémon en cancha debería ser el que se movió a la primera posición");
        }
    }
}
