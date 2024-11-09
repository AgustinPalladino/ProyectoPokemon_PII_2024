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
        MostrarCatalogo(creadorDePokemonYMovimiento.listaPokemon);

        for (int i = 0; i < 2; i++)
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

            if (banderaGlobal)
            {
                // Turno del jugador 2
                banderaGlobal = logica.switchCase(j2, j1);
            }
        }
    }
}

