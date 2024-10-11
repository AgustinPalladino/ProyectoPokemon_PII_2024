using Library.Moves;
using Library.Pokemon;

namespace Library;

public class Jugador
{
    public string Nombre;
    public List<IPokemon> equipoPokemon = new List<IPokemon>();
    private Combate combate = new Combate();

    public Jugador(string Nombre)
    {
        this.Nombre = Nombre;
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

    public void verMovimientos(string pokeIngresado)
    {
        foreach (IPokemon pokemon in this.equipoPokemon)
        {
            if (pokeIngresado == pokemon.Nombre)
            {
                foreach (IMovimiento movimiento in pokemon.listaMovimientos)
                {
                    Console.WriteLine($"-{movimiento.Nombre}");
                }
            }
        }
    }

    public void verSalud(string pokeIngresado)
    {
        foreach (IPokemon pokemon in this.equipoPokemon)
        {          
            if (pokeIngresado == pokemon.Nombre)
            {
                Console.WriteLine($"{pokemon.Vida}/100");
            }
        }
    }
    
    public IPokemon pokemonEnCancha(string pokeIngresado)
    {
        foreach (IPokemon pokemon in this.equipoPokemon)
        {
            if (pokeIngresado == pokemon.Nombre)
            {
                return pokemon;
            }
        }
        return null;
    }

    public void atacar(Jugador jEnemigo, string pokeAliado, string pokeEnemigo)
    {
        IPokemon pokemonAliado = null;
        IPokemon pokemonEnemigo = null;
        int danioBase;
        
        Console.WriteLine($"{this.Nombre}. ingrese el nombre del movimiento desee usar");
        string movimiento = Console.ReadLine();
        
        foreach (IPokemon pokemon in this.equipoPokemon)
        {
            if (pokeAliado == pokemon.Nombre)
            {
                pokemonAliado = pokemon;
            }
        }
        foreach (IPokemon pokemon in jEnemigo.equipoPokemon)
        {
            if (pokeEnemigo == pokemon.Nombre)
            {
                pokemonEnemigo = pokemon;
            }
        }
        
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
                    pokemonEnemigo.Vida -= (int)(danioBase * combate.bonificacionTipos(mov.Tipo, pokemonEnemigo.Tipo));
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