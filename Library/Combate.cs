namespace Library;

public class Combate
{
    public void MostrarCatalogo()
    {
        Console.WriteLine("\n Catálogo de Pokémon disponibles:");

        foreach (var pokemon in OperacionesStatic.DiccionarioPokemon)
        {
            Console.WriteLine($"- {pokemon.Value.Nombre}");
        }
    }

    
    public void BuclePrincipal(Jugador j1, Jugador j2)
    {
        Logica logica = new Logica();
        MostrarCatalogo(); // Le pasa por parametro la lista de todos los pokemon agregados
        
        Console.WriteLine("\nSu primer pokemon elejido sera con el que empieze la batalla");
        
        for (int i = 0; i < 6; i++) // Los jugadores escogen sus 6 pokemon
        {
            logica.EscogerEquipo(j1);
            logica.EscogerEquipo(j2);
        }
        
        Console.WriteLine("\n Equipos seleccionados:");
        j1.mostrarEquipo();
        j2.mostrarEquipo();
        
        bool banderaGlobal = true;
        int numeroRandom = OperacionesStatic.numeroAleatorio(1, 2);
        while (banderaGlobal)
        {
            //Si el numero random es 1 empieza el jugador uno
            if (numeroRandom == 1)
            {
                // Turno del jugador 1
                banderaGlobal = logica.MenuDeJugador(j1, j2); 
                // Si la bandera global toma el valor de falso, significa que termino el combate

                if (banderaGlobal)
                {
                    // Turno del jugador 2
                    banderaGlobal = logica.MenuDeJugador(j2, j1);
                }
            }
            //Si el numero random es el 2 empieza el jugador dos
            else
            {
                // Turno del jugador 2
                banderaGlobal = logica.MenuDeJugador(j2, j1); 
                // Si la bandera global toma el valor de falso, significa que termino el combate

                if (banderaGlobal)
                {
                    // Turno del jugador 1
                    banderaGlobal = logica.MenuDeJugador(j1, j2);
                }
            }
        }
    }
}