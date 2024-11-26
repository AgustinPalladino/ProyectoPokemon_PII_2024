using Ucu.Poo.DiscordBot.Interaccion;

namespace Ucu.Poo.DiscordBot;

public class Logica
{
    private readonly IInteraccionConUsuario interaccion;

    public Logica(IInteraccionConUsuario interaccion)
    {
        this.interaccion = interaccion;
    }
    
    /// <summary>
    /// Este metodo despliega el menu de opciones de cada jugador, decidimos ponerlo aqui, por uno de los patrones GRASP
    /// llamado bajo acomplamiento, con la intencion de que logica interactue con jugador de una manera mas cercana que combate
    /// </summary>
    public bool MenuDeJugador(Jugador j1, Jugador j2)
    {
        bool bandera = true;
        while (bandera)
        {
            interaccion.ImprimirMensaje($"\nTurno de {j1.Nombre}. ¿Qué deseas hacer? Seleccione un numero porfavor.");
            interaccion.ImprimirMensaje("1- Ver las habilidades de tu Pokémon (No consume turno)");
            interaccion.ImprimirMensaje("2- Ver la salud de tu Pokémon (No consume turno)");
            interaccion.ImprimirMensaje("3- Mochila (Solo usar objeto consume un turno)");
            interaccion.ImprimirMensaje("4- Atacar (Consume un turno)");
            interaccion.ImprimirMensaje("5- Cambiar de Pokémon (Consume un turno)");
            int opcion = Convert.ToInt32(interaccion.LeerEntrada());
            switch (opcion)
            {
                case 1:
                    j1.verMovimientos(interaccion); // Ve los movimientos y vuelve al bucle
                    break;
                
                case 2:
                    j1.verSalud(interaccion); // Ve la salud y vuelve al bucle
                    break;
                
                case 3:
                    if (Mochila(j1))
                    {
                        return true; // Si uso el objeto sale del bucle
                    }
                    break; // Si regresa vuelve al bucle
                    
                case 4:
                    if (SeleccionarAtaque(j1,j2))
                    {
                        if (ChequeoVictoria(j2))
                        {
                            return false; // Retorna falso porque la pelea termino
                        }
                        return true; // Si ataco pero nadie perdio termino su turno
                    }
                    break; // Si se retiro vuelve al bucle

                case 5:
                    if (CambiarPokemon(j1))
                    {
                        return true; // Si cambio de pokemon termino su turno
                    }
                    break; //Si volvio para atras vuelve al bucle
                    
                default: // Si ingresa una opcion mala, vuelve al bucle
                    interaccion.ImprimirMensaje("Error, opcion incorrecta");
                    break;
            }
        }
        return true;
    }
    
    
    public static string EscogerEquipo(Jugador jugador, string pokemonIngresado)
    {
        //interaccion.ImprimirMensaje($"{jugador.Nombre}, seleccione su siguiente pokemon");
        foreach (var pokemon in DiccionariosYOperacionesStatic.DiccionarioPokemon)
        {
            if (pokemonIngresado == pokemon.Key)
            {
                if (!jugador.nombreCheck.Contains(pokemonIngresado))
                {
                    jugador.nombreCheck.Add(pokemonIngresado);
                    jugador.agregarPokemon(pokemon.Value.Clonar());
                    return $"{pokemonIngresado} se agrego a tu equipo";
                }
                else
                {
                    return $"{pokemonIngresado} ya se encuentra en el equipo";
                }
            }
        }
        //Si el pokemon nunca se encontro, vuelve a pedirlo
        return $"{pokemonIngresado}, no es correcto";
    }
    
    
    public bool CambiarPokemon(Jugador jugador)
    {
        bool bandera = true;
        string pokeIngresado;
        while (bandera)
        {
            try
            {
                if (jugador.equipoPokemon[0] == null)
                {
                    jugador.equipoPokemon.Remove(jugador.equipoPokemon[0]);
                    jugador.MostrarEquipo(interaccion);
                    interaccion.ImprimirMensaje("Ingrese el nombre del siguiente pokemon para que se una al combate");
                    pokeIngresado = interaccion.LeerEntrada();
                }
                else
                {
                    jugador.MostrarEquipo(interaccion);
                    interaccion.ImprimirMensaje($"{jugador.Nombre}, ingrese el nombre del pokemon que desea elegir o 0 para ir hacia atras");
                    pokeIngresado = interaccion.LeerEntrada();

                    if (pokeIngresado == "0")
                    {
                        interaccion.ImprimirMensaje("Usted regreso hacia atras");
                        return false;
                    }
                }
                
                // Cambia al pokemon si el nombre de este coincide
                for (int i = 0; i < jugador.equipoPokemon.Count; i++)
                {
                    if (pokeIngresado == jugador.equipoPokemon[i].Nombre) // Usar '?' para evitar NullReferenceException
                    {
                        jugador.cambiarPokemon(jugador.equipoPokemon[i]);
                        return true;
                    }
                }
            }
            // Maneja errores inesperados
            catch (Exception)
            {
                interaccion.ImprimirMensaje("");
                return false;
            }
        }
        return false;
    }
    

    //Metodo que comprueba si el item recibido esta bien
    public bool Mochila(Jugador jugador)
    {
        bool bandera = true;
        while (bandera)
        {
            if (jugador.Mochila.Count != 0)
            { 
                interaccion.ImprimirMensaje("\nMochila:");
                for (int i = 0; i < jugador.Mochila.Count; i++)
                {
                    interaccion.ImprimirMensaje($"- {jugador.Mochila[i].Nombre}");
                }
                interaccion.ImprimirMensaje("¿Que item desea usar?");
                string item = interaccion.LeerEntrada();
                
                for (int i = 0; i < jugador.Mochila.Count; i++)
                {
                    // Usa el objeto si el nombre coincide
                    if (jugador.Mochila[i].Nombre == item)
                    {
                        jugador.UsarMochila(jugador.Mochila[i], interaccion);
                        return true;
                    }
                }
                if (item == "0")
                {
                    interaccion.ImprimirMensaje("Usted regreso hacia atras");
                    return false;
                }

                interaccion.ImprimirMensaje("Item ingresado no encontrado");
            }
            else
            {
                interaccion.ImprimirMensaje("Su mochila se encuentra vacia");
                return false;
            }
        }
        return false;
    }
    
    
    // Metodo para seleccionar un ataque
    public bool SeleccionarAtaque(Jugador jugador, Jugador jugadorEnemigo)
    {
        bool bandera = true;
        while (bandera)
        {
            interaccion.ImprimirMensaje($"{jugador.Nombre}, ingrese el nombre del movimiento desee usar o 0 para salir");
            string movimiento = interaccion.LeerEntrada();
            foreach (Movimiento mov in jugador.pokemonEnCancha().listaMovimientos)
            {
                if (movimiento == mov.Nombre)
                {
                    CalculoAtaque(jugador, jugadorEnemigo, mov);
                    return true;
                }
            }
            if (movimiento == "0")
            {
                interaccion.ImprimirMensaje("Usted regreso hacia atras");
                return false;
            }
            interaccion.ImprimirMensaje("Error, movimiento no encontrado");
        }
        return false;
    }
    
    
    public void CalculoAtaque(Jugador jugador, Jugador jugadorEnemigo, Movimiento movimiento)
    {
        if (movimiento != null)
        {
            
            if (jugador.pokemonEnCancha().puedeAtacar(interaccion) && !movimiento.EsEspecial)
            {
                jugador.atacar(jugadorEnemigo, movimiento, interaccion);
                jugadorEnemigo.pokemonEnCancha().aplicarDañoRecurrente(interaccion);
                jugadorEnemigo.verSalud(interaccion);
            }

            // Aplica ataques especiales si corresponde
            if (movimiento.EsEspecial && jugadorEnemigo.pokemonEnCancha().Estado == "Normal")
            {
                movimiento.AplicarAtaquesEspeciales(jugadorEnemigo.pokemonEnCancha(), interaccion);
                jugadorEnemigo.pokemonEnCancha().aplicarDañoRecurrente(interaccion);
                jugadorEnemigo.verSalud(interaccion);
            }

            if (jugadorEnemigo.pokemonEnCancha().VidaActual <= 0)
            {
                interaccion.ImprimirMensaje($"{jugadorEnemigo.Nombre}, tu {jugadorEnemigo.pokemonEnCancha().Nombre} fue derrotado");
                jugadorEnemigo.equipoPokemonDerrotados.Add(jugadorEnemigo.pokemonEnCancha());
                jugadorEnemigo.equipoPokemon[0] = null;
                if (!ChequeoVictoria(jugadorEnemigo))
                {
                    CambiarPokemon(jugadorEnemigo);
                }
            }
            else
            {
                jugadorEnemigo.verSalud(interaccion);
            }
        }
    }

    
    public bool ChequeoVictoria(Jugador jugadorEnemigo)
    {
        if (jugadorEnemigo.equipoPokemon.Count == 1 && jugadorEnemigo.equipoPokemon[0].VidaActual <= 0)
        {
            interaccion.ImprimirMensaje($"Felicidades, a {jugadorEnemigo.Nombre} no le quedan mas pokemones! Has ganado la batalla.");
            return true;
        }
        return false;
    }
}
