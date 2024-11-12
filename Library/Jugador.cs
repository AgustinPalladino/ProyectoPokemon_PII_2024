using Library.Moves;

namespace Library;

public class Jugador
{
    public string Nombre;
    public List<Pokemon> equipoPokemon = new();
    public List<Pokemon> equipoPokemonDerrotados = new();
    public List<IItem> Mochila = new();
    
    
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
        if (this.equipoPokemon[0] != null)
        {
            for (int i = 0; i < this.equipoPokemon.Count; i++)
            {
                Console.WriteLine($"-{equipoPokemon[i].Nombre}");
            }
        }
        else
        {
            for (int i = 1; i < this.equipoPokemon.Count; i++)
            {
                Console.WriteLine($"-{equipoPokemon[i].Nombre}");
            }
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
        double ataqueFinal = OperacionesStatic.Precision(movimiento.Precision, movimiento.Ataque);
        double danio = (2 * this.pokemonEnCancha().Ataque)*ataqueFinal * movimiento.Ataque / (jEnemigo.pokemonEnCancha().Defensa) + 2;
        jEnemigo.pokemonEnCancha().VidaActual -= (int)(danio * OperacionesStatic.bonificacionTipos(movimiento.Tipo, jEnemigo.pokemonEnCancha().Tipo) * OperacionesStatic.CalcularCritico(movimiento.Precision));
    }

    /// <summary>
    /// Método usar Mochila
    /// </summary>
    /// <returns></returns>
    public void UsarMochila(IItem item)
    {
        item.Usar(this);
        Mochila.Remove(item);
    }
}