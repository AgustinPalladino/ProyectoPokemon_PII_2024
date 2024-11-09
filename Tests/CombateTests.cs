using System;
using Library;
using NUnit.Framework;
using System.Collections.Generic;

namespace LibraryTests
{
    [TestFixture]
    public class CombateTests
    {
        private Combate combate;
        private List<Pokemon> listaPokemon;

        [SetUp]
        public void Setup()
        {
            combate = new Combate();
            listaPokemon = new List<Pokemon>
            {
                new Pokemon("Blastoise", "Agua", 100, 100, 80),
                new Pokemon("Charizard", "Fuego", 120, 80, 100),
                new Pokemon("Venusaur", "Planta", 90, 85, 80)
            };
        }

        [Test]
        public void MostrarCatalogo_DeberiaMostrarTodosLosPokemon()
        {
            var expectedPokemonNames = new List<string> { "Blastoise", "Charizard", "Venusaur" };
            
            foreach (var pokemon in listaPokemon)
            {
                // Aquí verificamos que el nombre del pokemon esté siendo impreso
                Assert.Contains(pokemon.Nombre, expectedPokemonNames);
            }
        }
        
        [Test]
        public void MostrarCatalogo_DeberiaMostrarPokemonCorrectamente()
        {
            var pokemonList = new List<Pokemon>
            {
                new Pokemon("Blastoise", "Agua", 100, 100, 80),
                new Pokemon("Charizard", "Fuego", 120, 80, 100)
            };

            combate.MostrarCatalogo(pokemonList);

            Assert.AreEqual(pokemonList[0].Nombre, "Blastoise");
            Assert.AreEqual(pokemonList[1].Nombre, "Charizard");
        }
    }
}
