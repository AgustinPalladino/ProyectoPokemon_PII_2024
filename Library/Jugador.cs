using System.ComponentModel;
using Library.Pokemon;

namespace Library;

public class Jugador
{
    private string nombre;
    public List<IPokemon> equipoPokemon = new List<IPokemon>();
    private Combate combate = new Combate();

    public Jugador(string Nombre)
    {
        this.nombre = Nombre;
    }

    public string Nombre
    {
        get { return this.nombre; }
        set { this.nombre = value; }
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
}