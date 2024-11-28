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

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="Nombre"></param>
    public Jugador(string Nombre)
    {
        this.Nombre = Nombre;
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
/// comparacion numero a numero basado en la cantidad base de PokemonsMaximos en batalla (para convertir cada cantidad en un numero que se sumara luego al porcentaje final en otro metodo)
/// </summary>
/// <param name="jugador"></param>
/// <returns></returns>
    public int PokeWinrate(Jugador jugador)
    {
        if (jugador.equipoPokemonDerrotados.Count() == 0)
        {
            return 60;

        }

        if (jugador.equipoPokemonDerrotados.Count() == 6)
        {
            return 0;
        }

        if (jugador.equipoPokemonDerrotados.Count() == 5)
        {
            return 10;
        }

        if (jugador.equipoPokemonDerrotados.Count() == 4)
        {
            return 20;
        }

        if (jugador.equipoPokemonDerrotados.Count() == 3)
        {
            return 30;
        }

        if (jugador.equipoPokemonDerrotados.Count() == 2)
        {
            return 40;
        }

        else 
        {
            return 50;
        }
    }

    /// <summary>
    /// comparacion numero a numero basado en la cantidad base de objetos (en el codigo original eran 7 pero para que quede mas practico deje 5 objetos)
    /// </summary>
    /// <param name="jugador"></param>
    /// <returns></returns>
    public int BackpackWinrate(Jugador jugador)
    {
        if (jugador.Mochila.Count == 5)
        {
            return 30;
        }

        if (jugador.Mochila.Count == 4)
        {
            return 24;
        }

        if (jugador.Mochila.Count == 3)
        {
            return 18;
        }

        if (jugador.Mochila.Count == 2)
        {
            return 12;
        }

        if (jugador.Mochila.Count == 1)
        {
            return 6;
        }

        else 
        {
            return 0;
        }
    }
    /// <summary>
    /// Estado booleano asi que si hay uno el numero/"porcentage de victoria" es automáticamente 0
    /// </summary>
    /// <param name="pokemon"></param>
    /// <param name="jugador"></param>
    /// <returns></returns>
    private int EstadoWinrate(Pokemon pokemon, Jugador jugador)
    {
        if (pokemon.Estado == "Normal")
        {
            return 10;
        }
        else
        {
            return 0;
        }
    }
    /// <summary>
    /// Metodo para calcular el porcentaje total de victoria sumando los tres metodos anteriores (esto en teoria por lo menos)
    /// </summary>
    /// <param name="jugador"></param>
    /// <param name="pokemon"></param>
    /// <returns></returns>

    public string WinrateTotal(Jugador jugador, Pokemon pokemon)
    {
        return $"Probabilidad de ganar De {jugador} es: {(EstadoWinrate(pokemon, jugador) + BackpackWinrate(jugador) + PokeWinrate(jugador))} de 100";
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
}