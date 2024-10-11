using System.ComponentModel;
using Library.Moves;
using Library.Pokemon;

namespace Library;

public class Jugador
{
    public string nombre;
    public List<IPokemon> equipoPokemon = new List<IPokemon>();
    private Combate combate = new Combate();

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

    public void atacar(Jugador jEnemigo, string pokeAliado, string pokeEnemigo)
    {
        IPokemon pokemonAliado = null;
        IPokemon pokemonEnemigo = null;
        int ataqueTotal = 0;
        Console.WriteLine("¿Que movimiento deseas usar?");
        string movimiento = Console.ReadLine();
        foreach (IPokemon pokemon in this.equipoPokemon)
        {
            if (pokeAliado == pokemon.Nombre)
            {
                pokemonAliado = pokemon;
            }
        }
        foreach (IPokemon pokemon in jEnemigo.equipoPokemon)
        {
            if (pokeEnemigo == pokemon.Nombre)
            {
                pokemonEnemigo = pokemon;
            }
        }
        if (pokemonAliado != null && pokemonEnemigo != null)
        {
            foreach (IMovimiento mov in pokemonAliado.listaMovimientos)
            {
                if (movimiento == mov.Nombre)
                {
                    ataqueTotal = pokemonAliado.Ataque + mov.Ataque;
                    
                }
            }
            pokemonEnemigo.Vida -= ataqueTotal;
            Console.WriteLine(pokemonEnemigo.Vida);
        }
    }
}