using Library.Moves;

namespace Library;

public class Jugador
{
    public string Nombre;
    public List<Pokemon> equipoPokemon = new List<Pokemon>();
    public List<Iitem> Mochila = new List<Iitem>();

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
    
    public void agregarPokemon(Pokemon pokemon)
    {
        this.equipoPokemon.Add(pokemon);
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
        foreach (IMovimiento movimiento in this.pokemonEnCancha().listaMovimientos)
        {
            Console.WriteLine($"-{movimiento.Nombre}");
        }
    }

    public void verSalud()
    {
        Console.WriteLine($"{this.pokemonEnCancha().VidaActual}/{this.pokemonEnCancha().VidaMax}");
    }
    
    public Pokemon pokemonEnCancha()
    {
        return equipoPokemon[0];
    }

    public Pokemon cambiarPokemon(string pokeIngresado)
    {
        Pokemon guardarPokemon = equipoPokemon[0];
        foreach (Pokemon pokemon in this.equipoPokemon)
        {
            if (pokeIngresado == pokemon.Nombre)
            {
                int posicionPokemon = equipoPokemon.IndexOf(pokemon);
                equipoPokemon[0] = equipoPokemon[posicionPokemon];
                equipoPokemon[posicionPokemon] = guardarPokemon;
            }
        }
        return pokemonEnCancha();
    }
    
    public void atacar(Jugador jEnemigo)
    {
        Pokemon pokemonAliado = this.pokemonEnCancha();
        Pokemon pokemonEnemigo = jEnemigo.pokemonEnCancha();
        int danioBase;
        
        Console.WriteLine($"{this.Nombre}. ingrese el nombre del movimiento desee usar");
        string movimiento = Console.ReadLine();
        
        if (pokemonAliado == null)
        {
            Console.WriteLine($"{this.Nombre}, tu pokemon no tiene vida. Debes cambiar de Pokémon");
        }
        else
        {
            foreach (IMovimiento mov in pokemonAliado.listaMovimientos)
            {
                if (movimiento == mov.Nombre)
                {
                    danioBase = (2 * pokemonAliado.Ataque) * mov.Ataque / (pokemonEnemigo.Defensa) + 2;
                    pokemonEnemigo.VidaActual -= (int)(danioBase * OperacionesStatic.bonificacionTipos(mov.Tipo, pokemonEnemigo.Tipo));
                }
            }
            
            if (pokemonEnemigo.VidaActual <= 0)
            {
                Console.WriteLine($"{jEnemigo.Nombre}, tu {pokemonEnemigo.Nombre} fue derrotado");
                jEnemigo.equipoPokemon.Remove(pokemonEnemigo);
            }
            else
            {
                Console.WriteLine($"La vida del {pokemonEnemigo.Nombre} es: {pokemonEnemigo.VidaActual}"); 
            }
        }
    }
}