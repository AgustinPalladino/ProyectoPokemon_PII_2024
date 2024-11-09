using System;
using System.Collections.Generic;
using Library.Moves;

namespace Library
{
    public class Logica
    {
        public List<Pokemon> listaPokemon = new();

        public Logica()
        {
            CreadorDePokemonYMovimiento creadorDePokemonYMovimiento = new CreadorDePokemonYMovimiento();
            listaPokemon = creadorDePokemonYMovimiento.listaPokemon;
        }

        public void EscogerEquipo(Jugador j)
        {
            bool bandera = true;

            while (bandera)
            {
                bool pokemonEncontrado = false;
                try
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"\n🔹 {j.Nombre}, ingrese el nombre del pokemon que desea elegir:");
                    Console.ResetColor();

                    string pokeIngresado = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(pokeIngresado))
                    {
                        throw new ArgumentException("⚠️ Entrada errónea, por favor intente nuevamente.");
                    }

                    foreach (Pokemon pokemon in listaPokemon)
                    {
                        if (pokeIngresado == pokemon.Nombre)
                        {
                            pokemonEncontrado = true;
                            if (!j.equipoPokemon.Contains(pokemon))
                            {
                                j.agregarPokemon(pokemon.Clonar());
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine($"✔️ {pokemon.Nombre} ha sido agregado a tu equipo.");
                                Console.ResetColor();
                                bandera = false;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("⚠️ El pokemon ya está en el equipo, elija otro pokemon.");
                                Console.ResetColor();
                            }
                            break;
                        }
                    }

                    if (!pokemonEncontrado)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("❌ Pokémon no encontrado, intente nuevamente.");
                        Console.ResetColor();
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                    Console.ResetColor();
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("⚠️ Ocurrió un error inesperado: " + ex.Message);
                    Console.ResetColor();
                }
            }
        }

        public void CambiarPokemon(Jugador j)
        {
            bool pokemonValido = true;
            while (pokemonValido)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\n🔄 Escoge el pokemon a cambiar:");
                Console.ResetColor();
                string pokeIngresado = Console.ReadLine();

                bool encontrado = false;
                for (int i = 0; i < j.equipoPokemon.Count; i++)
                {
                    if (pokeIngresado == j.equipoPokemon[i].Nombre)
                    {
                        j.cambiarPokemon(j.equipoPokemon[i]);
                        pokemonValido = false;
                        encontrado = true;
                        break;
                    }
                }
                if (!encontrado)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("❌ Pokemon no encontrado, elija nuevamente.");
                    Console.ResetColor();
                }
            }
        }

        public Movimiento EscogerMovimiento(Jugador j)
        {
            bool bandera = true;
            while (bandera)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"\n🔹 {j.Nombre}, ingrese el nombre del movimiento que desea usar:");
                Console.ResetColor();

                string movimiento = Console.ReadLine();
                foreach (Movimiento mov in j.pokemonEnCancha().listaMovimientos)
                {
                    if (movimiento == mov.Nombre)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"✔️ Movimiento {mov.Nombre} seleccionado.");
                        Console.ResetColor();
                        return mov;
                    }
                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("❌ Movimiento no encontrado, intente nuevamente.");
                Console.ResetColor();
            }
            return null;
        }

        public int Ataque(Jugador jugador, Jugador jEnemigo)
        {
            Movimiento movimiento = EscogerMovimiento(jugador);

            if (movimiento != null)
            {
                jugador.atacar(jEnemigo, movimiento);

                if (jugador.pokemonEnCancha().puedeAtacar())
                {
                    jugador.atacar(jEnemigo, movimiento);
                    jEnemigo.pokemonEnCancha().aplicarDañoRecurrente();
                }

                if (movimiento.EsEspecial && jEnemigo.pokemonEnCancha().Estado == "Normal")
                {
                    movimiento.AplicarAtaquesEspeciales(jEnemigo.pokemonEnCancha());
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine($"🌟 {jEnemigo.pokemonEnCancha().Nombre} ahora está bajo efecto del ataque {movimiento.Nombre}.");
                    Console.ResetColor();
                    jEnemigo.pokemonEnCancha().aplicarDañoRecurrente();
                }

                if (jEnemigo.pokemonEnCancha().VidaActual <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"💀 {jEnemigo.Nombre}, tu {jEnemigo.pokemonEnCancha().Nombre} fue derrotado.");
                    Console.ResetColor();
                    jEnemigo.equipoPokemon.Remove(jEnemigo.pokemonEnCancha());
                    if (!ChequeoVictoria(jugador, jEnemigo))
                    {
                        CambiarPokemon(jEnemigo);
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"🩸 La vida del {jEnemigo.pokemonEnCancha().Nombre} es: {jEnemigo.pokemonEnCancha().VidaActual}");
                    Console.ResetColor();
                }
            }
            return 0;
        }

        public bool ChequeoVictoria(Jugador jugador, Jugador jEnemigo)
        {
            if (jEnemigo.equipoPokemon.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"🎉 ¡Felicidades {jugador.Nombre}! Has ganado la batalla.");
                Console.ResetColor();
                return true;
            }
            return false;
        }
    }
}
