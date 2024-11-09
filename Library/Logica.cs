using Library.Moves;

namespace Library;

public class Logica
{
    public List<Pokemon> listaPokemon = new();

    public Logica()
    {
        CreadorDePokemonYMovimiento creadorDePokemonYMovimiento = new CreadorDePokemonYMovimiento();
        listaPokemon = creadorDePokemonYMovimiento.listaPokemon;
        //Al instanciarse logica se copian la lista de pokemon en su propia lista
    }
    
    /// <summary>
    /// Este metodo despliega el menu de opciones de cada jugador, decidimos ponerlo aqui, por uno de los patrones GRASP
    /// llamado bajo acomplamiento, con la intencion de que logica interactue con jugador de una manera mas cercana que combate
    /// </summary>
    public bool switchCase(Jugador j1, Jugador j2)
    {
        bool bandera = true;
        while (bandera)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\nTurno de {j1.Nombre}. ¿Qué deseas hacer?");
            Console.WriteLine($"Su pokemon en el combate es: {j1.pokemonEnCancha().Nombre}");
            Console.ResetColor();

            Console.WriteLine("1- Ver las habilidades de tu Pokémon (No consume turno)");
            Console.WriteLine("2- Ver la salud de tu Pokémon (No consume turno)");
            Console.WriteLine("3- Mochila (Solo usar objeto consume un turno)");
            Console.WriteLine("4- Atacar (Consume un turno)");
            Console.WriteLine("5- Cambiar de Pokémon (Consume un turno)");
            int opcion = Convert.ToInt32(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    j1.verMovimientos(); // Ve los movimientos y vuelve al bucle
                    break;
                
                case 2:
                    j1.verSalud(); // Ve la salud y vuelve al bucle
                    break;
                
                case 3:
                    if (Mochila(j1))
                    {
                        return true; // Si uso el objeto sale del bucle
                    }
                    break; // Si regresa vuelve al bucle
                    
                case 4:
                    if (Ataque(j1, j2))
                    {
                        if (ChequeoVictoria(j1, j2))
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"Felicidades {j1.Nombre}! Has ganado la batalla.");
                            Console.ResetColor();
                            return false; // Retorna falso porque la pelea termino
                        }
                        return true; // Si ataco pero nadie perdio termino su turno
                    }
                    break; // Si se retiro vuelve al bucle

                case 5:
                    if (CambiarPokemon(j1))
                    {
                        return true; // Si cambio de pokemon termino su turno
                    }
                    break; //Si volvio para atras vuelve al bucle
                    
                default: // Si ingresa una opcion mala, vuelve al bucle
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Opcion erronea, intenta de nuevo");
                    Console.ResetColor();
                    break;
            }
        }
        return true;
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
                Console.WriteLine($"{j.Nombre}, ingrese el nombre del pokemon que desea elegir");
                Console.ResetColor();
                string pokeIngresado = Console.ReadLine();

                foreach (Pokemon pokemon in listaPokemon)
                {
                    if (pokeIngresado == pokemon.Nombre)
                    {
                        pokemonEncontrado = true;
                        if (!j.equipoPokemon.Contains(pokemon)) // Añade al pokemon si no estaba en el equipo
                        {
                            j.agregarPokemon(pokemon.Clonar());
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"{pokemon.Nombre} ha sido agregado a tu equipo.");
                            Console.ResetColor();
                            bandera = false;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("El pokemon ya está en el equipo, elija otro pokemon.");
                            Console.ResetColor();
                        }
                        break;
                    }
                }
                //Si el pokemon nunca se encontro, vuelve a pedirlo
                if (!pokemonEncontrado)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Pokemon no encontrado, intente nuevamente.");
                    Console.ResetColor();
                }
            }
            // Captura cualquier tipo de error extra y muestra un mensaje
            catch (Exception ex)
            {
                // Captura cualquier excepción y muestra un mensaje
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ocurrio un error inesperado: " + ex.Message);
                Console.ResetColor();
            }
        }
    }

    public bool CambiarPokemon(Jugador j)
    {
        bool bandera = true;
        string pokeIngresado;
        while (bandera)
        {
            
            try
            {
                if (j.equipoPokemon[0] == null)
                {
                    j.equipoPokemon.Remove(j.equipoPokemon[0]);
                    j.mostrarEquipo();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("\nEscoge el siguiente pokemon para pelear");
                    Console.ResetColor();
                    pokeIngresado = Console.ReadLine();
                }
                else
                {
                    j.mostrarEquipo();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("\nEscoge el pokemon a cambiar o 0 para ir hacia atrás:");
                    Console.ResetColor();
                    pokeIngresado = Console.ReadLine();

                    if (pokeIngresado == "0")
                    {
                        Console.WriteLine("Usted regreso hacia atras");
                        return false;
                    }
                }
                
                // Cambia al pokemon si el nombre de este coincide
                for (int i = 0; i < j.equipoPokemon.Count; i++)
                {
                    if (pokeIngresado == j.equipoPokemon[i]?.Nombre) // Usar '?' para evitar NullReferenceException
                    {
                        j.cambiarPokemon(j.equipoPokemon[i]);
                    }
                    return true;
                }
            }
            // Maneja errores inesperados
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error");
                Console.ResetColor();
                return false;
            }
        }
        return false;
    }
    

    //Metodo que comprueba si el item recibido esta bien
    public bool Mochila(Jugador j)
    {
        bool bandera = true;
        while (bandera)
        {
            if (j.Mochila.Count != 0)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\nMochila:");
                Console.ResetColor();
                for (int i = 0; i < j.Mochila.Count; i++)
                {
                    Console.WriteLine($"- {j.Mochila[i].Nombre}");
                }
                Console.WriteLine("Seleccione el nombre del item para usarlo o 0 para salir");
                string item = Console.ReadLine();
                for (int i = 0; i < j.Mochila.Count; i++)
                {
                    // Usa el objeto si el nombre coincide
                    if (j.Mochila[i].Nombre == item)
                    {
                        j.UsarMochila(j.Mochila[i]);
                        return true;
                    }
                }
                if (item == "0")
                {
                    Console.WriteLine("Usted regreso hacia atras \n");
                    return false;
                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Tu mochila esta vacia");
                Console.ResetColor();
                return false;
            }
        }
        return false;
    }
    
    
    // Metodo para seleccionar un ataque
    public bool Ataque(Jugador j, Jugador jEnemigo)
    {
        bool bandera = true;
        while (bandera)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"\n{j.Nombre}. ingrese el nombre del movimiento desee usar o 0 para salir");
            Console.ResetColor();
            string movimiento = Console.ReadLine();
            foreach (Movimiento mov in j.pokemonEnCancha().listaMovimientos)
            {
                if (movimiento == mov.Nombre)
                {
                    CalculoAtaque(j,jEnemigo, mov);
                    return true;
                }
            }
            if (movimiento == "0")
            {
                Console.WriteLine("Usted regreso hacia atras");
                return false;
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Error");
            Console.ResetColor();
        }
        return false;
    }
    
    
    public int CalculoAtaque(Jugador jugador, Jugador jEnemigo, Movimiento movimiento)
    {
        if (movimiento != null)
        {
            if (jugador.pokemonEnCancha().puedeAtacar())
            {
                jugador.atacar(jEnemigo, movimiento);
                jEnemigo.pokemonEnCancha().aplicarDañoRecurrente();
            }

            // Aplica ataques especiales si corresponde
            if (movimiento.EsEspecial && jEnemigo.pokemonEnCancha().Estado == "Normal")
            {
                movimiento.AplicarAtaquesEspeciales(jEnemigo.pokemonEnCancha());
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($"{jEnemigo.pokemonEnCancha().Nombre} ahora está bajo efecto del ataque {movimiento.Nombre}.");
                Console.ResetColor();
                jEnemigo.pokemonEnCancha().aplicarDañoRecurrente();
            }

            if (jEnemigo.pokemonEnCancha().VidaActual <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{jEnemigo.Nombre}, tu {jEnemigo.pokemonEnCancha().Nombre} fue derrotado.");
                Console.ResetColor();
                jEnemigo.equipoPokemonDerrotados.Add(jEnemigo.pokemonEnCancha());
                jEnemigo.equipoPokemon[0] = null;
                if (!ChequeoVictoria(jugador, jEnemigo))
                {
                    CambiarPokemon(jEnemigo);
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"La vida del {jEnemigo.pokemonEnCancha().Nombre} es: {jEnemigo.pokemonEnCancha().VidaActual}");
                Console.ResetColor();
            }
        }
        return 0;
    }

    
    public bool ChequeoVictoria(Jugador jugador, Jugador jEnemigo)
    {
        if (jEnemigo.equipoPokemon.Count == 1 && jEnemigo.equipoPokemon[0] == null)
        {
            return true;
        }
        return false;
    }
}

