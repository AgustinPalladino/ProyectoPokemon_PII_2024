using System.Linq.Expressions;
using System.Reflection.Metadata;

namespace Library;

public class Logica
{
    public List<Pokemon> listaPokemon = new List<Pokemon>();
    
    public Logica()
    {
        CreadorDePokemonYMovimiento creadorDePokemonYMovimiento = new CreadorDePokemonYMovimiento();
        listaPokemon = creadorDePokemonYMovimiento.listaPokemon;
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

                foreach (Pokemon pokemon in this.listaPokemon)
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


    
    public bool chequeoVictoria(Jugador jEnSuTurno, Jugador jEsperando)
    {
        if (jEsperando.equipoPokemon.Count() == 0)
        {
            Console.WriteLine($"\n El {jEnSuTurno.Nombre} es el ganador");
            return true;
        }

        return false;
    }
}