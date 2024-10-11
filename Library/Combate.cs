using System.Reflection.Metadata;
using Library.Pokemon;

namespace Library;

public class Combate
{
    public List<IPokemon> listaPokemon = new List<IPokemon>();

    public void mostrarCatalogo()
    {
        this.listaPokemon.Add(new Venusaur());
        this.listaPokemon.Add(new Charizard());
        this.listaPokemon.Add(new Blastoise());
        foreach (IPokemon pokemon in this.listaPokemon)
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
            foreach (IPokemon pokemon in this.listaPokemon)
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
    
    public void ChequeoVictoria(Jugador jEnSuTurno, Jugador jEsperando, bool bandera)
    {
        if (jEsperando.equipoPokemon.Count() == 0)
        {
            bandera = true;
            Console.WriteLine($"\n El {jEnSuTurno.Nombre} es el ganador");
        }
    }
}