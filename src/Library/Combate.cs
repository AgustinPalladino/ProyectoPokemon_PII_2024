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

    public int turno;
    
    public Combate(IInteraccionConUsuario interaccion)
    {
        this.interaccion = interaccion;
    }
    
    /// <summary>
    /// Mostrar catalogo se ocupa de devolver un string en base de todos los pokemon del diccionario
    /// </summary>
    /// <returns></returns>
    public static string MostrarCatalogo()
    {
        string mostrarCatalogo = "\n Catálogo de Pokémon disponibles:";
        foreach (var pokemon in DiccionariosYOperacionesStatic.DiccionarioPokemon)
        {
            mostrarCatalogo += $"\n-{pokemon.Value.Nombre}";
        }

        return mostrarCatalogo;
    }
    
    
    /// <summary>
    /// Aqui se ejecuta el bucle principal del juego por consola, este maneja el flujo de toda la partida y cuando esta termina
    /// </summary>
    /// <param name="j1"></param>
    /// <param name="j2"></param>
    public void BuclePrincipal(Jugador j1, Jugador j2)
    {
        Logica logica = new Logica(interaccion);
        
        interaccion.ImprimirMensaje(MostrarCatalogo());
        string pokeIngresado;
        while(j1.equipoPokemon.Count < 6) // Los jugadores escogen sus 6 pokemon
        {
            interaccion.ImprimirMensaje($"{j1.Nombre}, seleccione su siguiente pokemon");
            pokeIngresado = interaccion.LeerEntrada();
            interaccion.ImprimirMensaje(Logica.CambiarPokeStringAPokemon(j1, pokeIngresado));
        }

        while (j2.equipoPokemon.Count < 6)
        {
            interaccion.ImprimirMensaje($"{j2.Nombre}, seleccione su siguiente pokemon");
            pokeIngresado = interaccion.LeerEntrada();
            interaccion.ImprimirMensaje(Logica.CambiarPokeStringAPokemon(j2, pokeIngresado));
        }
        
        interaccion.ImprimirMensaje(j1.MostrarEquipo());
        interaccion.ImprimirMensaje(j2.MostrarEquipo());
        
        bool banderaGlobal = true;
        int numeroRandom = DiccionariosYOperacionesStatic.numeroAleatorio(1, 2);
        turno = 0;
        while (banderaGlobal)
        {
            //Si el numero random es 1 empieza el jugador uno
            if (numeroRandom == 1)
            {
                turno += 1;
                numActual = numeroRandom;
                // Turno del jugador 1
                JugadorActual = j1;
                interaccion.ImprimirMensaje($"{turno}");
                banderaGlobal = logica.MenuDeJugador(j1, j2); 
                // Si la bandera global toma el valor de falso, significa que termino el combate

                if (banderaGlobal)
                {
                    numActual = numeroRandom;
                    // Turno del jugador 2
                    JugadorActual = j2;
                    turno += 1;
                    interaccion.ImprimirMensaje($"{turno}");
                    banderaGlobal = logica.MenuDeJugador(j2, j1);
                }
            }
            //Si el numero random es el 2 empieza el jugador dos
            else
            {
                // Turno del jugador 2
                turno += 1;
                interaccion.ImprimirMensaje($"{turno}");
                banderaGlobal = logica.MenuDeJugador(j2, j1); 
                // Si la bandera global toma el valor de falso, significa que termino el combate

                if (banderaGlobal)
                {
                    // Turno del jugador 1
                    turno += 1;
                    interaccion.ImprimirMensaje($"{turno}");
                    banderaGlobal = logica.MenuDeJugador(j1, j2);
                }
            }
        }
    }
}