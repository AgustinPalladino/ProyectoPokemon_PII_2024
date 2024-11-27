using Ucu.Poo.DiscordBot.Interaccion;
using Ucu.Poo.DiscordBot.Items;

namespace Ucu.Poo.DiscordBot;

public class Jugador
{
    public string Nombre;
    public List<Pokemon> equipoPokemon = new();
    public List<Pokemon> equipoPokemonDerrotados = new();
    public List<Item> Mochila = new();

    private const int MaxPoke = 6;
    
    //DEFENSA
    
    private int pokePuntaje = 0;

    private int inventarioPuntaje = 0;

    private int estadoPuntaje = 0;

    private int puntajeTotal = 0;

    private int contadorEstadosNormal = 0;

    
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
        Mochila.Add(new Revivir());
        Mochila.Add(new CuraTotal()); 
        Mochila.Add(new CuraTotal()); 
    }
    
    public string MostrarEquipo()
    {
        string mensaje = $"El equipo del {this.Nombre} equipo es: ";
        if (this.equipoPokemon[0] != null)
        {
            for (int i = 0; i < this.equipoPokemon.Count; i++)
            {
                mensaje += $"\n-{this.equipoPokemon[i].Nombre}";
            }
        }
        else
        {
            for (int i = 1; i < this.equipoPokemon.Count; i++)
            {
                mensaje += $"\n-{this.equipoPokemon[i].Nombre}";
            }
        }

        return mensaje;
    }
    
    
    /// <summary>
    /// Método para ver ataques que tiene el pokemon
    /// </summary>
    
    public string verMovimientos()
    {
        string mov = "";
        foreach (Movimiento movimiento in this.pokemonEnCancha().listaMovimientos)
        {
            mov += $"-{movimiento.Nombre}";
        }

        return mov;
    }

    /// <summary>
    /// Metodo para ver la salud del pokemon
    /// </summary>
    public string verSalud()
    {
        return $"La vida del {this.pokemonEnCancha().Nombre} es: {this.pokemonEnCancha().VidaActual}/{this.pokemonEnCancha().VidaMax}";
    }
    
    /// <summary>
    /// Método para agregar pokemon
    /// </summary>
    /// <param name="pokemon"></param>
    public string agregarPokemon(Pokemon pokemon)
    {
        if (equipoPokemon.Count >= MaxPoke)
        {
            return "No se puede agregar mas de 6 pokemones";
        }
        if (equipoPokemon.Any(p => p.Nombre.Equals(pokemon.Nombre, StringComparison.OrdinalIgnoreCase)))
        {
            return $"{pokemon.Nombre} ya está en tu equipo.";
        }
        
        this.equipoPokemon.Add(pokemon);

        return $"{pokemon.Nombre} agregado al equipo de {this.Nombre}.";
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
    
    public void atacar(Jugador jugadorEnemigo, Movimiento movimiento, IInteraccionConUsuario interaccion)
    {
        double ataqueFinal = DiccionariosYOperacionesStatic.Precision(movimiento.Precision, movimiento.Ataque, interaccion);
        double danio = (this.pokemonEnCancha().Ataque)*ataqueFinal * movimiento.Ataque / (jugadorEnemigo.pokemonEnCancha().Defensa);
        jugadorEnemigo.pokemonEnCancha().VidaActual -= (int)(danio * DiccionariosYOperacionesStatic.bonificacionTipos(movimiento.Tipo, jugadorEnemigo.pokemonEnCancha().Tipo, interaccion) * DiccionariosYOperacionesStatic.CalcularCritico(movimiento.Precision, interaccion));
    }

    /// <summary>
    /// Método usar Mochila
    /// </summary>
    /// <returns></returns>
    public string UsarMochila(Item item, string pokeIngresado)
    {
        string mensaje = item.Usar(this, pokeIngresado);
        Mochila.Remove(item);
        return mensaje;
    }
    
    ////////////////////////////////////////// DEFENSA PEDRO MOREIRA 27/11/24 ///////////////////////////////////////////////////////

    /// <summary>
    /// Creo metodo tipo int para que me devuelva el pountaje del jugadro por los pokemones en el equipo.
    /// </summary>
    /// 
    /// <returns></returns>
    public int PuntajePokemon()
    {
        this.pokePuntaje = 0;
        for (int i = 0; i < this.equipoPokemon.Count; i++)
        {
            this.pokePuntaje = 10 + this.pokePuntaje;
            if (this.equipoPokemon[i]==null)
            {
                this.pokePuntaje = this.pokePuntaje - 10;
            }
        }
        
        
        return pokePuntaje;
    }
    
    /// <summary>
    /// Creo metodo tipo int para que me devuelva la cantidad de puntos por los items en el inventario (Mochila).
    /// Reduje a 6 la cantidad inicial de items en la mochila, asi cada item vale 5 ptos.
    /// </summary>
    /// 
    /// <returns></returns>
    public int PuntajeInventario()
    {
        this.inventarioPuntaje = 0;
        for (int i = 0; i < this.Mochila.Count; i++)
        {
            this.inventarioPuntaje = 5 + this.inventarioPuntaje;
        }

        return this.inventarioPuntaje;
    }
    
    /// <summary>
    /// Creo metodo tipo int para que me devuelva 10 pts si tiene 
    /// </summary>
    /// 
    /// <returns></returns>
    public int PuntajeEstado()
    {
        this.estadoPuntaje = 0;
        for (int i = 0; i < this.equipoPokemon.Count; i++)
        {
            if (this.equipoPokemon[i].Estado != "Normal")
            {
                this.estadoPuntaje = 0;
            }
            else
            {
                this.contadorEstadosNormal += 1;
            }
            
        }
        if (this.contadorEstadosNormal == this.equipoPokemon.Count)
        {
            this.estadoPuntaje = 10;
        }

        return this.estadoPuntaje;
    }
    
    /// <summary>
    /// Creo metodo tipo int para que me devuelva 10 pts si tiene 
    /// </summary>
    /// <param name="j1"></param>
    /// <returns></returns>
    public int PuntajeTotal()
    {
        puntajeTotal = 0;
        puntajeTotal = this.PuntajeInventario() + this.PuntajeEstado() + this.PuntajePokemon();
        return puntajeTotal;
    }

}