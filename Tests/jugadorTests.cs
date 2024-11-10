using System;
using Library;
using Library.Moves;
using NUnit.Framework;

namespace LibraryTests
{
    [TestFixture]
    public class JugadorTests
    {
        [Test]
        public void AgregarPokemon_DeberiaAgregarPokemonAlEquipo()
        {
            var jugador = new Jugador("Jugador1");
            var pokemon = new Pokemon("Blastoise", "Agua", 100, 100, 80);  // Se pasa el tipo y las estadísticas

            jugador.agregarPokemon(pokemon);

            Assert.AreEqual(1, jugador.equipoPokemon.Count); 
            Assert.AreEqual("Blastoise", jugador.equipoPokemon[0].Nombre); 
        }

        [Test]
        public void MostrarEquipo_DeberiaMostrarCorrectamenteElEquipo()
        {
            var jugador = new Jugador("Jugador1");
            var pokemon1 = new Pokemon("Blastoise", "Agua", 100, 100, 80); // Se pasa el tipo y las estadísticas
            var pokemon2 = new Pokemon("Charizard", "Fuego", 120, 80, 100); // Se pasa el tipo y las estadísticas
            jugador.agregarPokemon(pokemon1);
            jugador.agregarPokemon(pokemon2);

            jugador.mostrarEquipo(); 

            Assert.AreEqual(2, jugador.equipoPokemon.Count); 
        }

        [Test]
        public void VerMovimientos_DeberiaMostrarMovimientosDelPokemonEnCancha()
        {
            var jugador = new Jugador("Jugador1");
            var pokemon = new Pokemon("Blastoise", "Agua", 100, 100, 80); // Se pasa el tipo y las estadísticas
            var movimiento = new Movimiento("Hidrocañon",5,1,"Agua",false);
            pokemon.listaMovimientos.Add(movimiento);
            jugador.agregarPokemon(pokemon);

            jugador.verMovimientos();

            Assert.AreEqual(1, jugador.pokemonEnCancha().listaMovimientos.Count); 
        }

        [Test]
        public void VerSalud_DeberiaMostrarSaludCorrecta()
        {
            var jugador = new Jugador("Jugador1");
            var pokemon = new Pokemon("Blastoise", "Agua", 100, 100, 80); // Se pasa el tipo y las estadísticas
            pokemon.VidaActual = 50;
            pokemon.VidaMax = 100;
            jugador.agregarPokemon(pokemon);

            jugador.verSalud(); 

            Assert.AreEqual(50, pokemon.VidaActual);
            Assert.AreEqual(100, pokemon.VidaMax); 
        }

        [Test]
        public void CambiarPokemon_DeberiaCambiarPokemonEnCancha()
        {
            var jugador = new Jugador("Jugador1");
            var pokemon1 = new Pokemon("Blastoise", "Agua", 100, 100, 80); // Se pasa el tipo y las estadísticas
            var pokemon2 = new Pokemon("Charizard", "Fuego", 120, 80, 100); // Se pasa el tipo y las estadísticas
            jugador.agregarPokemon(pokemon1);
            jugador.agregarPokemon(pokemon2);

            var pokemonEnCanchaAntes = jugador.pokemonEnCancha();
            jugador.cambiarPokemon(pokemon2);

            Assert.AreNotEqual(pokemonEnCanchaAntes.Nombre, jugador.pokemonEnCancha().Nombre); 
            Assert.AreEqual("Charizard", jugador.pokemonEnCancha().Nombre); 
        }

        [Test]
        public void Atacar_DeberiaAplicarDanioCorrectamente()
        {
            var jugador1 = new Jugador("Jugador1");
            var jugador2 = new Jugador("Jugador2");
            var pokemon1 = new Pokemon("Blastoise", "Agua", 100, 100, 80); // Se pasa el tipo y las estadísticas
            var pokemon2 = new Pokemon("Charizard", "Fuego", 120, 80, 100); // Se pasa el tipo y las estadísticas
            var movimiento = new Movimiento("Hidrocañon", 5, 1,"Acuatico",false);

            jugador1.agregarPokemon(pokemon1);
            jugador2.agregarPokemon(pokemon2);
            pokemon1.listaMovimientos.Add(movimiento);

            jugador1.atacar(jugador2, movimiento);

            Assert.Less(pokemon2.VidaActual, pokemon2.VidaMax); 
        }
    }
}
