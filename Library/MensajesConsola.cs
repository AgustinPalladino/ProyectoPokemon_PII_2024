namespace Library;

public static class MensajesConsola
{
    public static void ImprimirSalud(Jugador j)
    {
        Console.WriteLine($"La vida del {j.pokemonEnCancha().Nombre} es: {j.pokemonEnCancha().VidaActual}/{j.pokemonEnCancha().VidaMax}");
    }

    public static void ImprimirMovimientos(Movimiento movimiento)
    {
        Console.WriteLine($"-{movimiento.Nombre}");
    }
    
    
    public static void Error()
    {
        Console.WriteLine("Error");
    }
    
    
    public static void VolverAtras()
    {
        Console.WriteLine("Usted regreso hacia atras");
    }

    public static void NoEncontrado()
    {
        Console.WriteLine("No se encontro intente nuevamente");
    }

    public static void Ganador(Jugador j)
    {
        Console.WriteLine($"Felicidades {j.Nombre}! Has ganado la batalla.");
    }

    public static void BienSeleccionado(Pokemon pokemon)
    {
        Console.WriteLine($"{pokemon.Nombre} ha sido agregado a tu equipo.");
    }

    public static void PokemonDerrotado(Jugador jEnemigo)
    {
        Console.WriteLine($"{jEnemigo.Nombre}, tu {jEnemigo.pokemonEnCancha().Nombre} fue derrotado.");
    }

    public static void MostrarEquipo(Jugador j)
    {
        Console.WriteLine($"El equipo del {j.Nombre} equipo es: ");
        if (j.equipoPokemon[0] != null)
        {
            for (int i = 0; i < j.equipoPokemon.Count; i++)
            {
                Console.WriteLine($"-{j.equipoPokemon[i].Nombre}");
            }
        }
        else
        {
            for (int i = 1; i < j.equipoPokemon.Count; i++)
            {
                Console.WriteLine($"-{j.equipoPokemon[i].Nombre}");
            }
        }
    }
    
    public static void MostrarCatalogo()
    {
        Console.WriteLine("\n Catálogo de Pokémon disponibles:");

        foreach (var pokemon in DiccionariosYOperacionesStatic.DiccionarioPokemon)
        {
            Console.WriteLine($"- {pokemon.Value.Nombre}");
        }
    }
    
    public static void MostrarMochila(Jugador j)
    {
        Console.WriteLine("\nMochila:");
        for (int i = 0; i < j.Mochila.Count; i++)
        {
            Console.WriteLine($"- {j.Mochila[i].Nombre}");
        }
    }
    
    public static void MochilaVacia()
    {
        Console.WriteLine("Mochila vacia");
    }

    

}