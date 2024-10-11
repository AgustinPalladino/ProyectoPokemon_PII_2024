using System.Reflection.Metadata;
using Library.Pokemon;

namespace Library;

public class Combate
{
    public List<IPokemon> listaPokemon = new List<IPokemon>();

    public void mostrarCatalogo()
    {
        int i = 1;
        this.listaPokemon.Add(new Venusaur());
        this.listaPokemon.Add(new Charizard());
        this.listaPokemon.Add(new Blastoise());
        foreach (IPokemon pokemon in this.listaPokemon)
        {
            Console.WriteLine(i + "-" + pokemon.Nombre);
            i++;
        }
    }

    public void logicaEscogerEquipo(Jugador j)
    {
        for (int i = 1; i <= 2; i++)
        {
            int bandera = 0;
            Console.WriteLine($"{j.nombre} elija su pokemon numero {i}");
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
    

    public void turno(Jugador j1, Jugador j2)
    {
        bool bandera = false;
        Console.WriteLine($"{j1.nombre} que decide hacer?");
        while (bandera == false)
        {
            Console.WriteLine($"1-Ver las habilidades de su pokemon(No consume turno) \n 2-Ver la salud de su pokemon(No consume turno) \n 3-Ataque normal(Consume un turno) \n 4-Ataque especial(Consume un turno)");
            int opcion = Convert.ToInt32(Console.ReadLine());
            if (opcion == 1)
            {
                //Va a mostrar el nombre y daño de sus ataques
            }
            else if (opcion == 2)
            {
                //Va a mostrar su cantidad de vida
            }
            else if (opcion == 3)
            {
              
            }
        }

        
    }
}