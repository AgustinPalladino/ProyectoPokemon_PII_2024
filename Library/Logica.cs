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
        for (int i = 1; i <= 2; i++)
        {
            int bandera = 0;
            Console.WriteLine($"{j.Nombre} ingrese el nombre de su pokemon numero {i}");
            string pokeIngresado = Console.ReadLine();
            foreach (Pokemon pokemon in this.listaPokemon)
            {
                if (pokeIngresado == pokemon.Nombre)
                {
                    bandera = 1;
                    if (!j.equipoPokemon.Contains(pokemon))
                    {
                        bandera = 2;
                        j.agregarPokemon(pokemon);
                    }
                }
            }
            if (bandera == 0)
            {
                Console.WriteLine("Pokemon no encontrado seleccione nuevamente");
                i--;
            }
            else if (bandera == 1)
            {
                Console.WriteLine("El pokemon ya esta seleccionado");
                i--;
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