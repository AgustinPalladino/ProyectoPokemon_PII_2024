using System;
using System.Collections.Generic;
using Library.Moves;

namespace Library
{
    public class CreadorDePokemonYMovimiento
    {
        public List<Pokemon> listaPokemon = new();

        public CreadorDePokemonYMovimiento()
        {
            AgregarPokemon();
        }

        public void AgregarPokemon()
        {
            // Creación de pokemons y movimientos (como en tu código)
            Pokemon venusaur = new Pokemon("Venusaur", "Planta", 120, 40, 60);
            Pokemon charizard = new Pokemon("Charizard", "Fuego", 100, 60, 40);
            Pokemon blastoise = new Pokemon("Blastoise", "Agua", 110, 50, 50);
            
            Movimiento Arañazo = new Movimiento("Arañazo", 5, "Fuego", false);
            Movimiento Lanzallamas = new Movimiento("Lanzallamas", 20, "Fuego", false);
            Movimiento Lluevehojas = new Movimiento("Lluevehojas", 20, "Planta", false);
            Movimiento Hidrocañon = new Movimiento("Hidrocañon", 20, "Agua", false);
            
            // Agregar movimientos a los pokemons
            venusaur.agregarMovimiento(Arañazo);
            venusaur.agregarMovimiento(Lluevehojas);
            charizard.agregarMovimiento(Arañazo);
            charizard.agregarMovimiento(Lanzallamas);
            blastoise.agregarMovimiento(Arañazo);
            blastoise.agregarMovimiento(Hidrocañon);

            // Agregar los pokemons a la lista
            listaPokemon.Add(venusaur);
            listaPokemon.Add(charizard);
            listaPokemon.Add(blastoise);
        }

        public void VerMochila(Jugador jugador)
        {
            if (jugador.Mochila.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("⚠️ Tu mochila está vacía.");
                Console.ResetColor();
                return;
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n📦 Mochila:");
            Console.ResetColor();

            for (int i = 0; i < jugador.Mochila.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {jugador.Mochila[i].GetType().Name}");
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Seleccione el número del ítem para usarlo, o '0' para salir.");
            Console.ResetColor();

            if (int.TryParse(Console.ReadLine(), out int seleccion) && seleccion > 0 && seleccion <= jugador.Mochila.Count)
            {
                Iitem itemSeleccionado = jugador.Mochila[seleccion - 1];
                itemSeleccionado.Usar(jugador);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"✔️ {itemSeleccionado.GetType().Name} usado correctamente.");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine("❌ Selección inválida. Saliendo de la mochila.");
            }
        }
    }
}
