using Library.Moves;

namespace Library;

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
                Console.WriteLine($"\n🔹 {j.Nombre}, ingrese el nombre del pokemon que desea elegir o 0 para ir hacia atrás:");
                Console.ResetColor();

                string pokeIngresado = Console.ReadLine();
                if (pokeIngresado == "0") return; // Opción para regresar

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
            Console.WriteLine("\n🔄 Escoge el pokemon a cambiar o 0 para ir hacia atrás:");
            Console.ResetColor();
            string pokeIngresado = Console.ReadLine();
            
            if (pokeIngresado == "0") return; // Opción para regresar

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
            Console.WriteLine($"\n🔹 {j.Nombre}, elige el movimiento que deseas usar (a, b, c...) o 0 para ir hacia atrás:");
            Console.ResetColor();
            

            string seleccion = Console.ReadLine()?.ToLower();

            if (seleccion == "0") return null; // Opción para regresar

            Movimiento ataqueSeleccionado = SeleccionarAtaquePorLetra(j, seleccion);
            
            if (ataqueSeleccionado != null)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"✔️ Movimiento {ataqueSeleccionado.Nombre} seleccionado.");
                Console.ResetColor();
                return ataqueSeleccionado;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("❌ Selección inválida, intente nuevamente.");
                Console.ResetColor();
            }
        }
        return null;
    }
    

    public bool Mochila(Jugador j)
    {
        bool bandera = true;
        while (bandera)
        {
            if (j.Mochila.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("⚠️ Tu mochila esta vacia");
                Console.ResetColor();
                return false;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\n📦 Mochila:");
                Console.ResetColor();
                for (int i = 0; i < j.Mochila.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {j.Mochila[i].Nombre}");
                }
                
                Console.WriteLine("Seleccione el nombre del item para usarlo");
                string opcion = Console.ReadLine();
                for (int i = 0; i < j.Mochila.Count; i++)
                {
                    if (j.Mochila[i].Nombre == opcion)
                    {
                        j.UsarMochila(j.Mochila[i]);
                        return true;
                    }
                }
            }
        }
        return false;
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

