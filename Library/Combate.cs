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
        this.listaPokemon.Add(new Jolteon());
        foreach (IPokemon pokemon in this.listaPokemon)
        {
            Console.WriteLine(i + "-" + pokemon.Name);
            i++;
        }
    }
    
    
    public void Logica(Jugador j1, Jugador j2)
    {
        mostrarCatalogo();
        bool bandera = false;
        for (int i = 1; i <= 2; i++)
        {
            Console.WriteLine($"Jugador uno elija su pokemon numero {i}");
            string pokeIngresado = Console.ReadLine();
            foreach (IPokemon pokemon in this.listaPokemon)
            {
                if (pokeIngresado == pokemon.Name)
                {
                    bandera = true;
                    j1.agregarPokemon(pokemon);
                }
            }
            if (bandera == false)
            {
                Console.WriteLine("Pokemon no encontrado seleccione nuevamente");
                i--;
            }
            bandera = false;
        }
        j1.mostrarEquipo();
    }
}