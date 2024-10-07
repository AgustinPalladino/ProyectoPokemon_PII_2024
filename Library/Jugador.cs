using System.ComponentModel;
using Library.Pokemon;

namespace Library;

public class Jugador
{
    private List<IPokemon> equipoPokemon = new List<IPokemon>();
    private Combate combate = new Combate();
    
    public void agregarPokemon(IPokemon pokemon)
    {
        this.equipoPokemon.Add(pokemon);
    }

    public void mostrarEquipo()
    {
        int i = 1;
        foreach (IPokemon pokemon in this.equipoPokemon)
        {
            Console.WriteLine(i + "-" + pokemon.Name);
            i++;
        }
    }
}