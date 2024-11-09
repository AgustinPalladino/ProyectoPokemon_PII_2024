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
                Console.WriteLine($"\n{j.Nombre}, ingrese el nombre del pokemon que desea elegir o 0 para ir hacia atrás:");

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
                            Console.WriteLine($"{pokemon.Nombre} ha sido agregado a tu equipo.");
                            bandera = false;
                        }
                        else
                        {
                            Console.WriteLine("El pokemon ya está en el equipo, elija otro pokemon.");
                        }
                        break;
                    }
                }

                if (!pokemonEncontrado)
                {
                    Console.WriteLine("Pokémon no encontrado, intente nuevamente.");
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrió un error inesperado: " + ex.Message);
            }
        }
    }

    public void CambiarPokemon(Jugador j)
    {
        bool pokemonValido = true;
        while (pokemonValido)
        {
            Console.WriteLine("\nEscoge el pokemon a cambiar o 0 para ir hacia atrás:");
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
                Console.WriteLine("Pokemon no encontrado, elija nuevamente.");
            }
        }
    }

    public Movimiento EscogerMovimiento(Jugador j)
    {
        bool bandera = true;
        while (bandera)
        {
            Console.WriteLine($"\n{j.Nombre}, elige el movimiento que deseas usar (a, b, c...) o 0 para ir hacia atrás:");
            Console.ResetColor();

            // Mostrar los movimientos disponibles con letras
            MostrarAtaquesDisponibles(j);

            string seleccion = Console.ReadLine().ToLower();

            if (seleccion == "0") return null; // Opción para regresar

            Movimiento ataqueSeleccionado = SeleccionarAtaquePorLetra(j, seleccion);
            
            if (ataqueSeleccionado != null)
            {
                Console.WriteLine($"Movimiento {ataqueSeleccionado.Nombre} seleccionado.");
                return ataqueSeleccionado;
            }
            else
            {
                Console.WriteLine("Selección inválida, intente nuevamente.");
            }
        }
        return null;
    }

    private void MostrarAtaquesDisponibles(Jugador j)
    {
        var pokemon = j.pokemonEnCancha();  // Obtener el Pokémon en cancha
        var movimientos = pokemon.listaMovimientos;

        // Mostrar los ataques con letras
        for (int i = 0; i < movimientos.Count; i++)
        {
            char letra = (char)('a' + i); // Asignar letras a los movimientos
            Console.WriteLine($"{letra}. {movimientos[i].Nombre}");
        }
    }

    private Movimiento SeleccionarAtaquePorLetra(Jugador j, string seleccion)
    {
        var pokemon = j.pokemonEnCancha();  
        var movimientos = pokemon.listaMovimientos;

        //Valido la letra seleccionada y ejecuto mi ataque seleccionado
        if (seleccion.Length == 1 && char.IsLetter(seleccion[0]))
        {
            char letra = char.ToLower(seleccion[0]);
            int indice = letra - 'a'; //convierto las letras en indices

            if (indice >= 0 && indice < movimientos.Count)
            {
                return movimientos[indice]; //retorno mi ataque
            }
        }

        return null; // Si la selección es inválida, retornar null
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
                Console.WriteLine($"{jEnemigo.pokemonEnCancha().Nombre} ahora está bajo efecto del ataque {movimiento.Nombre}.");
                jEnemigo.pokemonEnCancha().aplicarDañoRecurrente();
            }

            if (jEnemigo.pokemonEnCancha().VidaActual <= 0)
            {
                Console.WriteLine($"{jEnemigo.Nombre}, tu {jEnemigo.pokemonEnCancha().Nombre} fue derrotado.");
                jEnemigo.equipoPokemon.Remove(jEnemigo.pokemonEnCancha());
                if (!ChequeoVictoria(jugador, jEnemigo))
                {
                    CambiarPokemon(jEnemigo);
                }
            }
            else
            {
                Console.WriteLine($"La vida del {jEnemigo.pokemonEnCancha().Nombre} es: {jEnemigo.pokemonEnCancha().VidaActual}");
            }
        }
        return 0;
    }

    public bool ChequeoVictoria(Jugador jugador, Jugador jEnemigo)
    {
        if (jEnemigo.equipoPokemon.Count == 0)
        {
            Console.WriteLine($" ¡Felicidades {jugador.Nombre}! Has ganado la batalla.");
            return true;
        }
        return false;
    }
}

