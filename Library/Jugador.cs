using Library.Items;
using Library.Moves;
using Library.Pokemon;

namespace Library;

public class Jugador
{
    public string Nombre;
    public List<IPokemon> equipoPokemon = new List<IPokemon>();
    public List<Item> listaItem = new List<Item>();

    public Jugador(string Nombre)
    {
        this.Nombre = Nombre;
        
        listaItem.Add(new SuperPocion());
        listaItem.Add(new SuperPocion());
        listaItem.Add(new SuperPocion());
        listaItem.Add(new SuperPocion());
        listaItem.Add(new Revivir());
    }
    
    public void agregarPokemon(IPokemon pokemon)
    {
        this.equipoPokemon.Add(pokemon);
    }

    public void mostrarEquipo()
    {
        Console.WriteLine($"El equipo del {this.Nombre} equipo es: ");
        foreach (IPokemon pokemon in this.equipoPokemon)
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
        Console.WriteLine($"{this.pokemonEnCancha().VidaActual}/{this.pokemonEnCancha().Vida}");
    }
    
    public IPokemon pokemonEnCancha()
    {
        return equipoPokemon[0];
    }

    public IPokemon cambiarPokemon(string pokeIngresado)
    {
        IPokemon guardarPokemon = equipoPokemon[0];
        foreach (IPokemon pokemon in this.equipoPokemon)
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
        IPokemon pokemonAliado = this.pokemonEnCancha();
        IPokemon pokemonEnemigo = jEnemigo.pokemonEnCancha();
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
            
            if (pokemonEnemigo.Vida <= 0)
            {
                Console.WriteLine($"{jEnemigo.Nombre}, tu {pokemonEnemigo.Nombre} fue derrotado");
                jEnemigo.equipoPokemon.Remove(pokemonEnemigo);
            }
            else
            {
                Console.WriteLine($"La vida del {pokemonEnemigo.Nombre} es: {pokemonEnemigo.Vida}"); 
            }
        }
    }
}