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
            Console.WriteLine(i + "-" + pokemon.Name);
            i++;
        }
    }

    public IPokemon pokemonEnCancha(string pokeIngresado)
    {
        foreach (IPokemon pokemon in this.equipoPokemon)
        {
            if (pokeIngresado == pokemon.Name)
            {
                return pokemon;
            }
        }
        return null;
    }
    
    public void cambiarPokemonEnCancha(int indice)
    {
        if (indice < 1 || indice > equipoPokemon.Count)
        {
            Console.WriteLine("Índice no válido.");
            return;
        }

        // Desactivar el Pokémon que está en cancha actualmente
        if (pokemonActivo != null)
        {
            pokemonActivo.EstaActivo = false;
        }

        // Activar el nuevo Pokémon seleccionado
        pokemonActivo = equipoPokemon[indice - 1]; // Restar 1 ya que la lista empieza en 0
        pokemonActivo.EstaActivo = true;

        Console.WriteLine($"{pokemonActivo.Name} ha sido enviado al campo de batalla.");
    }
}