namespace Library;

public class Jugador
{
    public string Nombre;
    public List<Pokemon> equipoPokemon = new();
    public List<Pokemon> equipoPokemonDerrotados = new();
    public List<string> nombreCheck = new();
    public List<Item> Mochila = new();
    
    
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
    /// Método para ver ataques que tiene el pokemon
    /// </summary>
    
    public void verMovimientos()
    {
        foreach (Movimiento movimiento in this.pokemonEnCancha().listaMovimientos)
        {
            MensajesConsola.ImprimirMovimientos(movimiento);
        }
    }

    /// <summary>
    /// Metodo para ver la salud del pokemon
    /// </summary>
    public void verSalud()
    {
        MensajesConsola.ImprimirSalud(this);
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
        double ataqueFinal = DiccionariosYOperacionesStatic.Precision(movimiento.Precision, movimiento.Ataque);
        double danio = (this.pokemonEnCancha().Ataque)*ataqueFinal * movimiento.Ataque / (jEnemigo.pokemonEnCancha().Defensa);
        jEnemigo.pokemonEnCancha().VidaActual -= (int)(danio * DiccionariosYOperacionesStatic.bonificacionTipos(movimiento.Tipo, jEnemigo.pokemonEnCancha().Tipo) * DiccionariosYOperacionesStatic.CalcularCritico(movimiento.Precision));
    }

    /// <summary>
    /// Método usar Mochila
    /// </summary>
    /// <returns></returns>
    public void UsarMochila(Item item)
    {
        item.Usar(this);
        Mochila.Remove(item);
    }
}