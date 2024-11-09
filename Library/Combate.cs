namespace Library;

public class Combate
{
    public void MostrarCatalogo(List<Pokemon> listaPokemon)
    {
        Console.WriteLine("\nCatálogo de Pokémon disponibles:");

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
        
        Console.WriteLine("\nEquipos seleccionados:");
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

            bandera = true;
        }
    }
}

