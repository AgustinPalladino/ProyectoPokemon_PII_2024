using System.Linq.Expressions;
using System.Reflection.Metadata;
using Library.Moves;

namespace Library;

public class Logica
{
    public List<Pokemon> listaPokemon = new ();
    
    
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
                            j.agregarPokemon(pokemon.Clonar());
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

    
    public void CambiarPokemon(Jugador j)
    {
        bool pokemonValido = true;
        while (pokemonValido)
        {
            Console.WriteLine("Escoge el pokemon a cambiar:");
            string pokeIngresado = Console.ReadLine();

            for (int i = 0; i < j.equipoPokemon.Count; i++)
            {
                if (pokeIngresado == j.equipoPokemon[i].Nombre)
                {
                    j.cambiarPokemon(j.equipoPokemon[i]);
                    pokemonValido = false;
                }
            }
            if (pokemonValido)
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
    
    
    public int Ataque(Jugador jugador, Jugador jEnemigo)
    {
        Movimiento movimiento = EscogerMovimiento(jugador);
        jugador.atacar(jEnemigo, movimiento);
        if (jugador.pokemonEnCancha().puedeAtacar())
        {
            jugador.atacar(jEnemigo, movimiento);
            jEnemigo.pokemonEnCancha().aplicarDañoRecurrente();
        }

        if (movimiento.EsEspecial && jEnemigo.pokemonEnCancha().Estado == "Normal")
        {
            movimiento.AplicarAtaquesEspeciales(jEnemigo.pokemonEnCancha());
            Console.WriteLine($"{jEnemigo.pokemonEnCancha().Nombre} ahora está bajo efecto del ataque {movimiento.Nombre}");
            jEnemigo.pokemonEnCancha().aplicarDañoRecurrente();
        }
        
        if (jEnemigo.pokemonEnCancha().VidaActual <= 0)
        {
            Console.WriteLine($"{jEnemigo.Nombre}, tu {jEnemigo.pokemonEnCancha().Nombre} fue derrotado");
            jEnemigo.equipoPokemon.Remove(jEnemigo.pokemonEnCancha());
            if (ChequeoVictoria(jugador, jEnemigo) == false)
            {
                CambiarPokemon(jEnemigo);
            }
        }
        else
        {
            Console.WriteLine($"La vida del {jEnemigo.pokemonEnCancha().Nombre} es: {jEnemigo.pokemonEnCancha().VidaActual}");
        }
        return 0;
    }

    
    public bool ChequeoVictoria(Jugador jugador, Jugador jEnemigo)
    {
        if (jEnemigo.equipoPokemon.Count() == 0)
        {
            return true;
        }
        return false;
    }
}