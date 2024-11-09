using System;
using Library;
using Library.Moves;
using NUnit.Framework;

namespace LibraryTests
{
    [TestFixture]
    public class LogicaTests
    {
        private Logica logica;
        private Jugador jugador;
        private Jugador enemigo;

        [SetUp]
        public void Setup()
        {
            logica = new Logica();
            jugador = new Jugador("Jugador1");
            enemigo = new Jugador("Jugador2");
        }

        [Test]
        public void MostrarCatalogo_DeberiaMostrarListaDePokemon()
        {
            var catalogo = logica.listaPokemon;

            foreach (var pokemon in catalogo)
            {
                // Aquí verificamos que el nombre del pokemon esté siendo impreso
                Assert.IsNotEmpty(pokemon.Nombre);
            }
        }

        [Test]
        public void LogicaEscogerEquipo_DeberiaAgregarPokemonAlEquipo()
        {
            var pokemonSeleccionado = logica.listaPokemon[0];
            
            logica.EscogerEquipo(jugador);

            Assert.Contains(pokemonSeleccionado, jugador.equipoPokemon);
        }

        [Test]
        public void LogicaCambiarPokemon_DeberiaCambiarPokemonEnCancha()
        {
            var pokemon1 = new Pokemon("Blastoise", "Agua", 100, 100, 80);  
            var pokemon2 = new Pokemon("Charizard", "Fuego", 100, 100, 85);

            jugador.agregarPokemon(pokemon1);
            jugador.agregarPokemon(pokemon2);

            logica.CambiarPokemon(jugador);

            Assert.AreEqual("Charizard", jugador.pokemonEnCancha().Nombre);
        }

        [Test]
        public void LogicaAtacar_DeberiaAplicarDanioCorrectamente()
        {
            var pokemonAliado = new Pokemon("Blastoise", "Agua", 100, 100, 80);  
            var pokemonEnemigo = new Pokemon("Charizard", "Fuego", 100, 100, 85);
            var movimiento = new Movimiento("Lanzallama", 14,"Fuego",false);

            jugador.agregarPokemon(pokemonAliado);
            enemigo.agregarPokemon(pokemonEnemigo);
            pokemonAliado.listaMovimientos.Add(movimiento);

            logica.Ataque(jugador, enemigo);

            Assert.Less(pokemonEnemigo.VidaActual, pokemonEnemigo.VidaMax);
        }

        [Test]
        public void ChequeoVictoria_DeberiaDevolverTrueSiNoQuedanPokemon()
        {
            
            enemigo.equipoPokemon.Clear();

            var resultado = logica.ChequeoVictoria(jugador,enemigo);

            Assert.IsTrue(resultado);
        }

        [Test]
        public void ChequeoVictoria_DeberiaDevolverFalseSiQuedanPokemon()
        {
            enemigo.agregarPokemon(new Pokemon("Charizard", "Fuego", 100, 100, 85));  

            var resultado = logica.ChequeoVictoria(jugador,enemigo);

            Assert.IsFalse(resultado);
        }
    }
}



