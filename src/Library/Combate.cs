using Ucu.Poo.DiscordBot.Interaccion;

namespace Ucu.Poo.DiscordBot;

/// <summary>
/// constructor de clase Combate
/// Esta clase se ocupa de ejecutar y mantener el combate pokemon hasta llegar a un final
/// </summary>
public class Combate
{
    public readonly IInteraccionConUsuario interaccion;

    public Combate(IInteraccionConUsuario interaccion)
    {
        this.interaccion = interaccion;
    }
    
    
    public string MostrarCatalogo()
    {
        string mensaje = "\nCatálogo de Pokémon disponibles:";

        foreach (var pokemon in DiccionariosYOperacionesStatic.DiccionarioPokemon)
        {
            mensaje += $"\n-{pokemon.Value.Nombre}";
        }

        return mensaje;
    }
    
    
    public void BuclePrincipal(Jugador j1, Jugador j2)
    {
        Logica logica = new Logica(interaccion);
        
        interaccion.ImprimirMensaje(MostrarCatalogo()); 
        
        for (int i = 0; i < 2; i++) // Los jugadores escogen sus 6 pokemon
        {
            bool bandera = true;
            while (bandera)
            {
                if (logica.EscogerEquipo(j1))
                {
                    bandera = false;
                }
            }

            bandera = true;
            
            while (bandera)
            {
                if (logica.EscogerEquipo(j2))
                {
                    bandera = false;
                }
            }
            
        }
        interaccion.ImprimirMensaje(j1.MostrarEquipo());
        interaccion.ImprimirMensaje(j2.MostrarEquipo());
        
        bool banderaGlobal = true;
        int numeroRandom = DiccionariosYOperacionesStatic.numeroAleatorio(1, 2);
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
            //Si random es el 2 empieza el jugador dos
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