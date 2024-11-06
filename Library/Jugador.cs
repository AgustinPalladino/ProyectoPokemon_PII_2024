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

    public Pokemon cambiarPokemon()
    {
        bool pokemonValido = false;
        while (!pokemonValido)
        {
            Console.WriteLine("Escoge un Pokémon:");
            string pokeIngresado = Console.ReadLine();

            foreach (Pokemon pokemon in this.equipoPokemon)
            {
                if (pokeIngresado == pokemon.Nombre)
                {
                    int posicionPokemon = equipoPokemon.IndexOf(pokemon);
                    (equipoPokemon[0], equipoPokemon[posicionPokemon]) = (equipoPokemon[posicionPokemon], equipoPokemon[0]);
                    break;
                }
            }
            if (!pokemonValido)
            {
                Console.WriteLine("Pokémon no encontrado, elija nuevamente.");
            }
        }
        return pokemonEnCancha();
    }
    
    public void atacar(Jugador jEnemigo)
    {
        Logica logica = new Logica();
        Movimiento movimiento = logica.logicaEscogerMovimiento(this);
        int danio = (2 * this.pokemonEnCancha().Ataque) * movimiento.Ataque / (jEnemigo.pokemonEnCancha().Defensa) + 2;
        jEnemigo.pokemonEnCancha().VidaActual -= (int)(danio * OperacionesStatic.bonificacionTipos(movimiento.Tipo, jEnemigo.pokemonEnCancha().Tipo));
    }
}