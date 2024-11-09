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
    
    public void UsarMochila(IItem item)
    {
        item.Usar(this);
        Mochila.Remove(item);
    }
}