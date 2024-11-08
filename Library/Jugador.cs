using Library.Moves;

namespace Library;

public class Jugador
{
    public string Nombre;
    public List<Pokemon> equipoPokemon = new List<Pokemon>();
    
    
    public Jugador(string Nombre)
    {
        this.Nombre = Nombre;
        
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

    
    public Pokemon cambiarPokemon(Pokemon pokemon)
    {
        int posicionPokemon = equipoPokemon.IndexOf(pokemon);
        (equipoPokemon[0], equipoPokemon[posicionPokemon]) = (equipoPokemon[posicionPokemon], equipoPokemon[0]);
        return pokemonEnCancha();
    }
    
    
    public void atacar(Jugador jEnemigo, Movimiento movimiento)
    {
        int danio = (2 * this.pokemonEnCancha().Ataque) * movimiento.Ataque / (jEnemigo.pokemonEnCancha().Defensa) + 2;
        jEnemigo.pokemonEnCancha().VidaActual -= (int)(danio * OperacionesStatic.bonificacionTipos(movimiento.Tipo, jEnemigo.pokemonEnCancha().Tipo));
    }
}