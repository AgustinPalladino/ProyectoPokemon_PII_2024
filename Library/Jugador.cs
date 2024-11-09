using Library.Moves;

namespace Library;

public class Jugador
{
    public string Nombre;
    public List<Pokemon> equipoPokemon = new List<Pokemon>();
    public List<IItem> Mochila = new List<IItem>();
    
    
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

    
    public void mostrarEquipo()
    {
        Console.WriteLine($"El equipo del {this.Nombre} equipo es: ");
        foreach (Pokemon pokemon in this.equipoPokemon)
        {
            Console.WriteLine($"-{pokemon.Nombre}");
        }
    }
    

    
    public void verMovimientos()
    {
        foreach (Movimiento movimiento in this.pokemonEnCancha().listaMovimientos)
        {
            Console.WriteLine($"-{movimiento.Nombre}");
        }
    }

    
    public void verSalud()
    {
        Console.WriteLine($"{this.pokemonEnCancha().VidaActual}/{this.pokemonEnCancha().VidaMax}");
    }
    
    
    public void agregarPokemon(Pokemon pokemon)
    {
        this.equipoPokemon.Add(pokemon);
    }
    
    
    public Pokemon pokemonEnCancha()
    {
        return equipoPokemon[0];
    }

    
    public void cambiarPokemon(Pokemon pokemon)
    {
        int posicionPokemon = equipoPokemon.IndexOf(pokemon);
        (equipoPokemon[0], equipoPokemon[posicionPokemon]) = (equipoPokemon[posicionPokemon], equipoPokemon[0]);
    }
    
    
    public void atacar(Jugador jEnemigo, Movimiento movimiento)
    {
        int danio = (2 * this.pokemonEnCancha().Ataque) * movimiento.Ataque / (jEnemigo.pokemonEnCancha().Defensa) + 2;
        jEnemigo.pokemonEnCancha().VidaActual -= (int)(danio * OperacionesStatic.bonificacionTipos(movimiento.Tipo, jEnemigo.pokemonEnCancha().Tipo));
    }
    
    public bool UsarMochila()
    {
        if (this.Mochila.Count == 0)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("⚠️ Tu mochila esta vacia");
            Console.ResetColor();
            return false;
        }

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\n📦 Mochila:");
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("Seleccione el nombre del item para usarlo, o '0' para salir");
        Console.ResetColor();
        for (int i = 0; i < this.Mochila.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {this.Mochila[i].Nombre}");
        }
        string opcion = Console.ReadLine();
        OperacionesStatic.ajustarPalabra(opcion);
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