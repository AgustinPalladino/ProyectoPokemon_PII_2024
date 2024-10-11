using Library.Moves;
using Library.Pokemon;

namespace Library;

public class Jugador
{
    //Atributos
    public string Nombre;
    public List<IPokemon> equipoPokemon = new List<IPokemon>();
    private Combate combate = new Combate();

    public Jugador(string Nombre)
    {
        this.Nombre = Nombre;
    }
    
    public void agregarPokemon(IPokemon pokemon)
    {
        this.equipoPokemon.Add(pokemon); //Se agregan Pokemones al equipo
    }

    public void mostrarEquipo()
    {
        Console.WriteLine($"El equipo del {this.Nombre} equipo es: ");
        foreach (IPokemon pokemon in this.equipoPokemon)
        {
            Console.WriteLine($"-{pokemon.Nombre}"); //Imprime el equipo
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
                    Console.WriteLine($"-{movimiento.Nombre}"); //Muestra los Movimientos del pokemon
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
                Console.WriteLine($"{pokemon.Vida}/100"); // Imprime la vida del pokemon
            }
        }
    }
    
    public IPokemon pokemonEnCancha(string pokeIngresado)
    {
        foreach (IPokemon pokemon in this.equipoPokemon)
        {
            if (pokeIngresado == pokemon.Nombre)
            {
                return pokemon; //devuelve el pokemon que se seleccionó
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
        
        foreach (IPokemon pokemon in this.equipoPokemon) //recorre el equipo del jugador que llama al metodo
        {
            if (pokeAliado == pokemon.Nombre)
            {
                pokemonAliado = pokemon;  // setea pokemonAliado
            }
        }
        foreach (IPokemon pokemon in jEnemigo.equipoPokemon) //recorre el equipo del jugador rival
        {
            if (pokeEnemigo == pokemon.Nombre)
            {
                pokemonEnemigo = pokemon; // setea pokemon que se defiende pokemonEnemigo
            }
        }
        
        if (pokemonAliado == null)
        {
            Console.WriteLine($"{this.Nombre}, tu pokemon no tiene vida. Debes cambiar de Pokémon"); //Si no encuentra el pokemon devuelve esto
        }
        else
        {
            foreach (IMovimiento mov in pokemonAliado.listaMovimientos)
            {
                if (movimiento == mov.Nombre)
                {
                    danioBase = (2 * pokemonAliado.Ataque) * mov.Ataque / (pokemonEnemigo.Defensa) + 2; // Valor de daño
                    pokemonEnemigo.Vida -= (int)(danioBase * combate.bonificacionTipos(mov.Tipo, pokemonEnemigo.Tipo)); // ecuación para actuar sobre la vida del pokemon rival
                }
            }
            
            if (pokemonEnemigo.Vida <= 0)
            {
                Console.WriteLine($"{jEnemigo.Nombre}, tu {pokemonEnemigo.Nombre} fue derrotado");
                jEnemigo.equipoPokemon.Remove(pokemonEnemigo); //Elimina pokemon del equipo
            }
            else
            {
                Console.WriteLine($"La vida del {pokemonEnemigo.Nombre} es: {pokemonEnemigo.Vida}"); // Imprime la vida que le queda al pokemon Enemigo
            }
        }
    }
}