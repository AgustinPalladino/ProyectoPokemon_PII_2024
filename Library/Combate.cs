namespace Library;

public class Combate
{
    public void MostrarCatalogo(List<Pokemon> listaPokemon)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\n Catálogo de Pokémon disponibles:");
        Console.ResetColor();

        foreach (Pokemon pokemon in listaPokemon)
        {
            Console.WriteLine($"- {pokemon.Nombre}");
        }
    }

    
    public void BuclePrincipal(Jugador j1, Jugador j2)
    {
        Logica logica = new Logica();
        CreadorDePokemonYMovimiento creadorDePokemonYMovimiento = new CreadorDePokemonYMovimiento();
        MostrarCatalogo(creadorDePokemonYMovimiento.listaPokemon); // Le pasa por parametro la lista de todos los pokemon agregados

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\nSu primer pokemon elejido sera con el que empieze la batalla");
        Console.ResetColor();
        
        for (int i = 0; i < 6; i++) // Los jugadores escogen sus 6 pokemon
        {
            logica.EscogerEquipo(j1);
            logica.EscogerEquipo(j2);
        }

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\n Equipos seleccionados:");
        Console.ResetColor();
        j1.mostrarEquipo();
        j2.mostrarEquipo();

        bool bandera = true;
        bool banderaGlobal = true;

        while (banderaGlobal)
        {
            // Turno del jugador 1
            banderaGlobal = logica.switchCase(j1, j2); 
            // Si la bandera global toma el valor de falso, significa que termino el combate

            if (banderaGlobal)
            {
                // Turno del jugador 2
                banderaGlobal = logica.switchCase(j2, j1);
            }
        }
    }
}

