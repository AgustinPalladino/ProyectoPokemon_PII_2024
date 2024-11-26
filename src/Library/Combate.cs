using Ucu.Poo.DiscordBot.Interaccion;

namespace Ucu.Poo.DiscordBot;

/// <summary>
/// constructor de clase Combate
/// Esta clase se ocupa de ejecutar y mantener el combate pokemon hasta llegar a un final
/// </summary>
public class Combate
{
    private readonly IInteraccionConUsuario interaccion;
    
    public Jugador JugadorActual { get; private set; }
    public int numActual { get; private set; }

    public Combate(IInteraccionConUsuario interaccion)
    {
        this.interaccion = interaccion;
    }
    
    
    public static string MostrarCatalogo()
    {
        string mostrarCatalogo = "\n Catálogo de Pokémon disponibles:";
        foreach (var pokemon in DiccionariosYOperacionesStatic.DiccionarioPokemon)
        {
            mostrarCatalogo += $"\n-{pokemon.Value.Nombre}";
        }

        return mostrarCatalogo;
    }
    
    
    public void BuclePrincipal(Jugador j1, Jugador j2)
    {
        Logica logica = new Logica(interaccion);
        MostrarCatalogo(); 
        
        for (int i = 0; i < 2; i++) // Los jugadores escogen sus 6 pokemon
        {
           // logica.EscogerEquipo(j1);
           // logica.EscogerEquipo(j2);
        }
        
        j1.MostrarEquipo(interaccion);
        j2.MostrarEquipo(interaccion);
        
        bool banderaGlobal = true;
        int numeroRandom = DiccionariosYOperacionesStatic.numeroAleatorio(1, 2);
        while (banderaGlobal)
        {
            //Si el numero random es 1 empieza el jugador uno
            if (numeroRandom == 1)
            {
                numActual = numeroRandom;
                // Turno del jugador 1
                JugadorActual = j1;
                banderaGlobal = logica.MenuDeJugador(j1, j2); 
                // Si la bandera global toma el valor de falso, significa que termino el combate

                if (banderaGlobal)
                {
                    numActual = numeroRandom;
                    // Turno del jugador 2
                    JugadorActual = j2;
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