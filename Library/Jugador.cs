using Library.Moves;

namespace Library;

public class Jugador
{
    public string Nombre;
    public List<Pokemon> equipoPokemon = new List<Pokemon>();
    public List<IItem> Mochila = new List<IItem>();
    
    
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="Nombre"></param>
    public Jugador(string Nombre)
    {
        this.Nombre = Nombre;
        Mochila.Add(new SuperPocion());
        Mochila.Add(new SuperPocion());
        Mochila.Add(new SuperPocion());
        Mochila.Add(new SuperPocion());
        Mochila.Add(new Revivir());
        Mochila.Add(new CuraTotal()); 
        Mochila.Add(new CuraTotal()); 
    }

    /// <summary>
    /// Metodo para mostrar pokemones en el equipo
    /// </summary>
    public void mostrarEquipo()
    {
        Console.WriteLine($"El equipo del {this.Nombre} equipo es: ");
        foreach (Pokemon pokemon in this.equipoPokemon)
        {
            Console.WriteLine($"-{pokemon.Nombre}");
        }
    }
    
    /// <summary>
    /// Método para ver ataques que tiene el pokemon
    /// </summary>
    
    public void verMovimientos()
    {
        foreach (Movimiento movimiento in this.pokemonEnCancha().listaMovimientos)
        {
            Console.WriteLine($"-{movimiento.Nombre}");
        }
    }

    /// <summary>
    /// Metodo para ver la salud del pokemon
    /// </summary>
    public void verSalud()
    {
        Console.WriteLine($"{this.pokemonEnCancha().VidaActual}/{this.pokemonEnCancha().VidaMax}");
    }
    
    /// <summary>
    /// Método para agregar pokemon
    /// </summary>
    /// <param name="pokemon"></param>
    public void agregarPokemon(Pokemon pokemon)
    {
        this.equipoPokemon.Add(pokemon);
    }
    /// <summary>
    /// Método que devuelvo el pokemon en cancha
    /// </summary>
    /// <returns></returns>
    
    public Pokemon pokemonEnCancha()
    {
        return equipoPokemon[0];
    }

    /// <summary>
    /// Método para cambiar de pokemon
    /// </summary>
    /// <param name="pokemon"></param>
    public void cambiarPokemon(Pokemon pokemon)
    {
        int posicionPokemon = equipoPokemon.IndexOf(pokemon);
        (equipoPokemon[0], equipoPokemon[posicionPokemon]) = (equipoPokemon[posicionPokemon], equipoPokemon[0]);
    }
    
    /// <summary>
    /// Método para atacar al enemigo
    /// </summary>
    /// <param name="jEnemigo"></param>
    /// <param name="movimiento"></param>
    
    public void atacar(Jugador jEnemigo, Movimiento movimiento)
    {
        int danio = (2 * this.pokemonEnCancha().Ataque) * movimiento.Ataque / (jEnemigo.pokemonEnCancha().Defensa) + 2;
        jEnemigo.pokemonEnCancha().VidaActual -= (int)(danio * OperacionesStatic.bonificacionTipos(movimiento.Tipo, jEnemigo.pokemonEnCancha().Tipo));
    }
    
    /// <summary>
    /// Método usar Mochila
    /// </summary>
    /// <returns></returns>
    public bool UsarMochila()
    {
        if (this.Mochila.Count == 0)
        {
            Console.WriteLine(" Tu mochila esta vacia");
            return false;
        }
        
        Console.WriteLine("\n Mochila:");
        Console.WriteLine("Seleccione el nombre del item para usarlo, o '0' para salir");
        for (int i = 0; i < this.Mochila.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {this.Mochila[i].Nombre}");
        }
        string opcion = Console.ReadLine();
        for (int i = 0; i < this.Mochila.Count; i++)
        {
            if (Mochila[i].Nombre == opcion)
            {
                Mochila[i].Usar(this);
                Mochila.Remove(Mochila[i]);
                return true;
            }
        }
        return false;
    }
}