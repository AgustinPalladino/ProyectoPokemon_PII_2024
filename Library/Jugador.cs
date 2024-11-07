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
        foreach (Movimiento movimiento in this.pokemonEnCancha().listaMovimientos)
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

    public Pokemon cambiarPokemon(Pokemon pokemon)
    {
        int posicionPokemon = equipoPokemon.IndexOf(pokemon);
        (equipoPokemon[0], equipoPokemon[posicionPokemon]) = (equipoPokemon[posicionPokemon], equipoPokemon[0]);
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
            if (pokemonAliado.puedeAtacar())
            {
                
            
                foreach (Movimiento mov in pokemonAliado.listaMovimientos)
                {
                    if (movimiento == mov.Nombre)
                    {
                        danioBase = (2 * pokemonAliado.Ataque) * mov.Ataque / (pokemonEnemigo.Defensa) + 2;
                        pokemonEnemigo.VidaActual -= (int)(danioBase * OperacionesStatic.bonificacionTipos(mov.Tipo, pokemonEnemigo.Tipo));
                        pokemonEnemigo.aplicarDañoRecurrente();
                    }

                    if (mov.EsEspecial && pokemonEnemigo.Estado == "Normal")
                    {
                        mov.AplicarAtaquesEspeciales(pokemonEnemigo);
                        Console.WriteLine($"{pokemonEnemigo.Nombre} ahora está bajo efecto del ataque {mov.Nombre}");
                        pokemonEnemigo.aplicarDañoRecurrente();
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
            else
            {
                Console.WriteLine("Pokemon bajo efecto especial, no puede atacar.");
            }
        }
    }
}