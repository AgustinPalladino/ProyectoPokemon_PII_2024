using Ucu.Poo.DiscordBot.Interaccion;
using Ucu.Poo.DiscordBot.Items;

namespace Ucu.Poo.DiscordBot;

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
    
    public void MostrarEquipo(IInteraccionConUsuario interaccion)
    {
        Console.WriteLine($"El equipo del {this.Nombre} equipo es: ");
        if (this.equipoPokemon[0] != null)
        {
            for (int i = 0; i < this.equipoPokemon.Count; i++)
            {
                interaccion.ImprimirMensaje($"-{this.equipoPokemon[i].Nombre}");
            }
        }
        else
        {
            for (int i = 1; i < this.equipoPokemon.Count; i++)
            {
                interaccion.ImprimirMensaje($"-{this.equipoPokemon[i].Nombre}");
            }
        }
    }
    
    
    /// <summary>
    /// Método para ver ataques que tiene el pokemon
    /// </summary>
    
    public void verMovimientos(IInteraccionConUsuario interaccion)
    {
        foreach (Movimiento movimiento in this.pokemonEnCancha().listaMovimientos)
        {
            interaccion.ImprimirMensaje($"-{movimiento.Nombre}");
        }
    }

    /// <summary>
    /// Metodo para ver la salud del pokemon
    /// </summary>
    public void verSalud(IInteraccionConUsuario interaccion)
    {
        interaccion.ImprimirMensaje($"La vida del {this.pokemonEnCancha().Nombre} es: {this.pokemonEnCancha().VidaActual}/{this.pokemonEnCancha().VidaMax}");
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
    public void UsarMochila(Item item, IInteraccionConUsuario interaccion)
    {
        item.Usar(this, interaccion);
        Mochila.Remove(item);
    }
}