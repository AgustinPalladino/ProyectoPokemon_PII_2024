using System.Linq.Expressions;
using System.Reflection.Metadata;
using Library.Moves;

namespace Library;

public class Logica
{
    public List<Pokemon> listaPokemon = new List<Pokemon>();
    public List<Movimiento> listaMovimiento = new List<Movimiento>();
    
    public Logica()
    {
        CreadorDePokemonYMovimiento creadorDePokemonYMovimiento = new CreadorDePokemonYMovimiento();
        listaPokemon = creadorDePokemonYMovimiento.listaPokemon;
        listaMovimiento = creadorDePokemonYMovimiento.listaMovimiento;
    }


    public void mostrarCatalogo()
    {
        foreach (Pokemon pokemon in this.listaPokemon)
        {
            Console.WriteLine($"-{pokemon.Nombre}");
        }
    }

    public void logicaEscogerEquipo(Jugador j)
    {
        bool bandera = true;
    
        while (bandera)
        {
            bool pokemonEncontrado = false; // Variable para verificar si el pokemon fue encontrado
            try
            {
                Console.WriteLine($"{j.Nombre}, ingrese el nombre del pokemon que desea elegir:");
                string pokeIngresado = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(pokeIngresado))
                {
                    throw new ArgumentException("Entrada erronea, hagalo nuevamente");
                }

                foreach (Pokemon pokemon in listaPokemon)
                {
                    if (pokeIngresado == pokemon.Nombre)
                    {
                        pokemonEncontrado = true; // Marcamos que el pokemon fue encontrado

                        if (!j.equipoPokemon.Contains(pokemon))
                        {
                            j.agregarPokemon(pokemon);
                            Console.WriteLine($"{pokemon.Nombre} ha sido agregado a tu equipo");
                            bandera = false; // Salimos del bucle después de agregar el Pokémon
                        }
                        else
                        {
                            Console.WriteLine("El pokemon ya esta en el equipo, elija otro pokemon");
                        }
                        break; // Salimos del foreach ya que encontramos el pokemon
                    }
                }

                if (!pokemonEncontrado)
                {
                    Console.WriteLine("Pokemon no encontrado, hagalo nuevamente");
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrio un error inesperado: " + ex.Message);
            }
        }
    }

    
    public void logicaCambiarPokemon(Jugador j)
    {
        bool pokemonValido = true;
        while (pokemonValido)
        {
            Console.WriteLine("Escoge un pokemon:");
            string pokeIngresado = Console.ReadLine();

            foreach (Pokemon pokemon in j.equipoPokemon)
            {
                if (pokeIngresado == pokemon.Nombre)
                {
                    j.cambiarPokemon(pokemon);
                    pokemonValido = false;
                }
            }
            if (pokemonValido)
            {
                Console.WriteLine("Pokemon no encontrado, elija nuevamente.");
            }
        }
    }
    
    
    public Movimiento logicaEscogerMovimiento(Jugador j)
    {
        bool bandera = true;
        while (bandera)
        {
            Console.WriteLine($"{j.Nombre}. ingrese el nombre del movimiento desee usar");
            string movimiento = Console.ReadLine();
            foreach (Movimiento mov in j.pokemonEnCancha().listaMovimientos)
            {
                if (movimiento == mov.Nombre)
                {
                    return mov;
                }
            }
            Console.WriteLine("Error");
        }
        return null;
    }
    
    
    public int logicaAtacar(Jugador jAliado, Jugador jEnemigo)
    {
        Pokemon pokemonAliado = jAliado.pokemonEnCancha();
        Pokemon pokemonEnemigo = jEnemigo.pokemonEnCancha();
        Movimiento movimiento = logicaEscogerMovimiento(jAliado);
        jAliado.atacar(jEnemigo, movimiento);
        if (pokemonAliado.puedeAtacar())
        {
            jAliado.atacar(jEnemigo, movimiento);
            pokemonEnemigo.aplicarDañoRecurrente();
        }

        if (movimiento.EsEspecial && pokemonEnemigo.Estado == "Normal")
        {
            movimiento.AplicarAtaquesEspeciales(pokemonEnemigo);
            Console.WriteLine($"{pokemonEnemigo.Nombre} ahora está bajo efecto del ataque {movimiento.Nombre}");
            pokemonEnemigo.aplicarDañoRecurrente();
        }
        
        if (pokemonEnemigo.VidaActual <= 0)
        {
            Console.WriteLine($"{jEnemigo.Nombre}, tu {pokemonEnemigo.Nombre} fue derrotado");
            jEnemigo.equipoPokemon.Remove(pokemonEnemigo);
            if (chequeoVictoria(jEnemigo) == true)
            {
                Console.WriteLine($"\n El {jAliado.Nombre} es el ganador");
            }
            else
            {
                logicaCambiarPokemon(jEnemigo);
            }
            
        }
        else
        {
            Console.WriteLine($"La vida del {pokemonEnemigo.Nombre} es: {pokemonEnemigo.VidaActual}");
        }
        return 0;
    }

    
    public bool chequeoVictoria(Jugador jEnemigo)
    {
        if (jEnemigo.equipoPokemon.Count() == 0)
        {
            return true;
        }

        return false;
    }
}