﻿using Ucu.Poo.DiscordBot.Interaccion;

namespace Ucu.Poo.DiscordBot;

public class Logica
{
    /// <summary>
    /// Logica es una clase en la cual se dividen procesos que tendria que tener jugador, con el fin de seguir el principio
    /// solid srp. Aun asi esta clase interactua con jugador cuando paso este proceso de logica y validación
    /// </summary>
    private readonly IInteraccionConUsuario interaccion;

    public Logica(IInteraccionConUsuario interaccion)
    {
        this.interaccion = interaccion;
    }
    
    
    /// <summary>
    /// Este es el bucle del menu de jugador para jugar mediante consola, es el responsable de tomar la decision del jugador
    /// y saber cuando este finaliza y consume su turno
    /// </summary>
    /// <param name="j1"></param>
    /// <param name="j2"></param>
    /// <returns></returns>
    public bool MenuDeJugador(Jugador j1, Jugador j2)
    {
        bool bandera = true;
        while (bandera)
        {
            //Si el otro jugador no gano la pelea sigue
            if (j1.pokemonEnCancha() == null)
            {
                if (!ChequeoVictoria(j1))
                {
                    SeleccionarPokemonDeCambio(j1);
                }
                else
                {
                    interaccion.ImprimirMensaje($"Felicidades, {j2.Nombre}, has derrotado todos los pokemon del {j1.Nombre} ! Has ganado la batalla.");
                    return false;
                }
            }
            else
            {
                try
                {
                    interaccion.ImprimirMensaje($"\nTurno de {j1.Nombre}.");
                    interaccion.ImprimirMensaje($"Tu pokemon en cancha es: {j1.pokemonEnCancha().Nombre}");
                    interaccion.ImprimirMensaje("¿Qué deseas hacer? Seleccione un numero porfavor.");
                    interaccion.ImprimirMensaje("1- Ver las habilidades de tu Pokémon (No consume turno)");
                    interaccion.ImprimirMensaje("2- Ver la salud de tu Pokémon (No consume turno)");
                    interaccion.ImprimirMensaje("3- Mochila (Solo usar objeto consume un turno)");
                    interaccion.ImprimirMensaje("4- Atacar (Consume un turno)");
                    interaccion.ImprimirMensaje("5- Cambiar de Pokémon (Consume un turno)");
                    int opcion = Convert.ToInt32(interaccion.LeerEntrada());
                   
                    switch (opcion)
                    {
                        
                        case 1:
                            interaccion.ImprimirMensaje(j1.verMovimientos()); // Ve los movimientos y vuelve al bucle
                            break;

                        case 2:
                            interaccion.ImprimirMensaje(j1.verSalud()); // Ve la salud y vuelve al bucle
                            break;

                        case 3:
                            if (Mochila(j1))
                            {
                                return true; // Si uso el objeto sale del bucle
                            }

                            break; // Si regresa vuelve al bucle

                        case 4:
                            if (SeleccionarAtaque(j1, j2))
                            {
                                return true; // Si ataco pero nadie perdio termino su turno
                            }

                            break; // Si se retiro vuelve al bucle

                        case 5:
                            if (SeleccionarPokemonDeCambio(j1))
                            {
                                return true; // Si cambio de pokemon termino su turno
                            }

                            break; //Si volvio para atras vuelve al bucle

                        default: // Si ingresa una opcion mala, vuelve al bucle
                            interaccion.ImprimirMensaje("Error, opcion incorrecta");
                            break;
                    }
                }
                catch (Exception)
                {
                    interaccion.ImprimirMensaje("Error inesperado");
                }
                
            }
        }
        return true;
    }
    
    
    /// <summary>
    /// Cambia un string pokemon a un objeto de tipo Pokemon mediante una cooperacion con jugador.agregarPokemon para añadir
    /// este pokemon directo al equipo
    /// </summary>
    /// <param name="jugador"></param>
    /// <param name="pokeIngresado"></param>
    /// <returns></returns>
    public static string CambiarPokeStringAPokemon(Jugador jugador, string pokeIngresado)
    {
        foreach (var pokemon in DiccionariosYOperacionesStatic.DiccionarioPokemon)
        {
            if (pokeIngresado == pokemon.Value.Nombre)
            {
                return jugador.agregarPokemon(pokemon.Value.Clonar());
            }
        }
        //Si el pokemon nunca se encontro
        return $"{pokeIngresado}, no es correcto";
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="jugador"></param>
    /// <returns></returns>
    public bool SeleccionarPokemonDeCambio(Jugador jugador)
    {
        try
        {
            string pokeIngresado;
            if (jugador.equipoPokemon[0] == null)
            {
                jugador.equipoPokemon.Remove(jugador.equipoPokemon[0]);
                interaccion.ImprimirMensaje(jugador.MostrarEquipo());
                interaccion.ImprimirMensaje("Ingrese el nombre del siguiente pokemon para que se una al combate");
                pokeIngresado = interaccion.LeerEntrada();
            }
            else
            {
                interaccion.ImprimirMensaje(jugador.MostrarEquipo());
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
                if (pokeIngresado == jugador.equipoPokemon[i].Nombre)
                {
                    jugador.cambiarPokemon(jugador.equipoPokemon[i]);
                    return true;
                }
            }
        }
        // Maneja errores inesperados
        catch (Exception)
        {
            interaccion.ImprimirMensaje("Error inesperado");
            return false;
        }

        return false;
    }
    

    /// <summary>
    /// Metodo que comprueba si el item recibido esta bien y recibe el nombre del pokemon que va a interactuar con ese objeto
    /// </summary>
    /// <param name="jugador"></param>
    /// <returns></returns>
    public bool Mochila(Jugador jugador)
    {
        try
        {
            if (jugador.Mochila.Count != 0)
            { 
                interaccion.ImprimirMensaje("\nMochila:");
                for (int i = 0; i < jugador.Mochila.Count; i++)
                {
                    interaccion.ImprimirMensaje($"- {jugador.Mochila[i].Nombre}: {jugador.Mochila[i].Descripcion}");
                }
                interaccion.ImprimirMensaje("¿Que item desea usar?");
                string item = interaccion.LeerEntrada();
            
                for (int i = 0; i < jugador.Mochila.Count; i++)
                {
                    // Usa el objeto si el nombre coincide
                    if (jugador.Mochila[i].Nombre == item)
                    {
                        interaccion.ImprimirMensaje($"Con cual pokemon desea usar el {jugador.Mochila[i].Nombre}");
                        string pokeIngresado = interaccion.LeerEntrada();
                        item = jugador.UsarMochila(jugador.Mochila[i], pokeIngresado);
                        interaccion.ImprimirMensaje(item);
                        if (item == "Se ha utilizado el objeto correctamente")
                        {
                            return true;
                        }
                        return false;
                    }
                }
                if (item == "0")
                {
                    interaccion.ImprimirMensaje("Usted regreso hacia atras");
                    return false;
                }

                interaccion.ImprimirMensaje("Item ingresado no encontrado");
                return false;
            }
            else
            {
                interaccion.ImprimirMensaje("Su mochila se encuentra vacia");
                return false;
            }
        }
        catch (Exception)
        {
            interaccion.ImprimirMensaje("Error inesperado");
            return false;
        }
    }
    
    
    /// <summary>
    /// Metodo que confirma la eleccion del movimiento
    /// </summary>
    /// <param name="jugador"></param>
    /// <param name="jugadorEnemigo"></param>
    /// <returns></returns>
    public bool SeleccionarAtaque(Jugador jugador, Jugador jugadorEnemigo)
    {
        try
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
        }
        catch (Exception)
        {
            interaccion.ImprimirMensaje("Error inesperado");
            return false;
        }
        return false;
    }
    
    /// <summary>
    /// Calcula el ataque
    /// </summary>
    /// <param name="jugador"></param>
    /// <param name="jugadorEnemigo"></param>
    /// <param name="movimiento"></param>
    public void CalculoAtaque(Jugador jugador, Jugador jugadorEnemigo, Movimiento movimiento)
    {
        if (jugador.pokemonEnCancha().puedeAtacar(interaccion) && !movimiento.EsEspecial)
        {
            jugador.atacar(jugadorEnemigo, movimiento, interaccion);
            jugadorEnemigo.pokemonEnCancha().aplicarDañoRecurrente(interaccion);
        }

        // Aplica ataques especiales si corresponde
        if (movimiento.EsEspecial && jugadorEnemigo.pokemonEnCancha().Estado == "Normal")
        {
            movimiento.AplicarAtaquesEspeciales(jugadorEnemigo.pokemonEnCancha(), interaccion);
            jugadorEnemigo.pokemonEnCancha().aplicarDañoRecurrente(interaccion);
        }

        if (jugadorEnemigo.pokemonEnCancha().VidaActual <= 0)
        {
            interaccion.ImprimirMensaje($"{jugadorEnemigo.Nombre}, tu {jugadorEnemigo.pokemonEnCancha().Nombre} fue derrotado");
            jugadorEnemigo.equipoPokemonDerrotados.Add(jugadorEnemigo.pokemonEnCancha());
            jugadorEnemigo.equipoPokemon[0] = null;
        }
        else
        {
            interaccion.ImprimirMensaje(jugadorEnemigo.verSalud());
        }
    }

    /// <summary>
    /// Si el jugador rival tiene solo 1 pokemon y es null este retorna true y por ende confirma que la pelea termina
    /// </summary>
    /// <param name="jugadorEnemigo"></param>
    /// <returns></returns>
    public bool ChequeoVictoria(Jugador jugadorEnemigo)
    {
        if (jugadorEnemigo.equipoPokemon.Count == 1 && jugadorEnemigo.equipoPokemon[0] == null)
        {
            return true;
        }
        return false;
    }
}
