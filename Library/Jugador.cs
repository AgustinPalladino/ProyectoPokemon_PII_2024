using System.ComponentModel;
using Library.Pokemon;

namespace Library;

public class Jugador
{
    public string nombre;
    public List<IPokemon> equipoPokemon = new List<IPokemon>();
    private Combate combate = new Combate();
    public IPokemon pokemonActivo;

    public Jugador(string Nombre)
    {
        this.nombre = Nombre;
    }
    
    public void agregarPokemon(IPokemon pokemon)
    {
        this.equipoPokemon.Add(pokemon);
    }

    public void mostrarEquipo()
    {
        int i = 1;
        Console.WriteLine($"El equipo del {this.nombre} equipo es: ");
        foreach (IPokemon pokemon in this.equipoPokemon)
        {
            Console.WriteLine(i + "-" + pokemon.Nombre);
            i++;
        }
    }

    public IPokemon pokemonEnCancha(string pokeIngresado)
    {
        foreach (IPokemon pokemon in this.equipoPokemon)
        {
            if (pokeIngresado == pokemon.Nombre)
            {
                return pokemon;
            }
        }
        return null;
    }

    public void atacar(Jugador enemigo)
    {
        IPokemon pokemonAtacante = this.pokemonEnCancha("pokemonAtacante");
        IPokemon pokemonDefensor = enemigo.pokemonEnCancha("pokemonDefensor");
    }
}