﻿using Ucu.Poo.DiscordBot.Interaccion;

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
                    interaccion.ImprimirMensaje(j1.verMovimientos()); // Ve los movimientos y vuelve al bucle
                    break;
                
                case 2:
                    interaccion.ImprimirMensaje(j1.verSalud()); // Ve la salud y vuelve al bucle
                    break;
                
                case 3:
                    if (Mochila(j1) == "Usted uso correctamente el item")
                    {
                        return true; // Si uso el objeto sale del bucle
                    }
                    break; // Si regresa vuelve al bucle
                    
                case 4:
                    interaccion.ImprimirMensaje(SeleccionarAtaque(j1,j2));
                    if (SeleccionarAtaque(j1,j2) == j2.verSalud())
                    {
                        if (ChequeoVictoria(j2))
                        {
                            return false; // Retorna falso porque la pelea termino
                        }
                        return true; // Si ataco pero nadie perdio termino su turno
                    }
                    break; // Si se retiro vuelve al bucle

                case 5:
                    interaccion.ImprimirMensaje(CambiarPokemon(j1));
                    if (CambiarPokemon(j1) == "El pokemon cambio correctamente")
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
    
    
    public string EscogerEquipo(Jugador jugador)
    {
        interaccion.ImprimirMensaje($"{jugador.Nombre}, seleccione su siguiente pokemon");
        string pokeIngresado = interaccion.LeerEntrada();
        foreach (var pokemon in DiccionariosYOperacionesStatic.DiccionarioPokemon)
        {
            if (pokeIngresado == pokemon.Key)
            {
                if (!jugador.nombreCheck.Contains(pokeIngresado))
                {
                    jugador.nombreCheck.Add(pokeIngresado);
                    jugador.agregarPokemon(pokemon.Value.Clonar());
                    return $"{pokeIngresado} se agrego a tu equipo";
                }
                else
                {
                    return $"{pokeIngresado} ya se encuentra en el equipo";
                }
            }
        }
        //Si el pokemon nunca se encontro
        return $"{pokeIngresado}, no es correcto";
    }
    
    
    public string CambiarPokemon(Jugador jugador)
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
                    return "Usted regreso hacia atras";
                }
            }
            
            // Cambia al pokemon si el nombre de este coincide
            for (int i = 0; i < jugador.equipoPokemon.Count; i++)
            {
                if (pokeIngresado == jugador.equipoPokemon[i].Nombre) // Usar '?' para evitar NullReferenceException
                {
                    jugador.cambiarPokemon(jugador.equipoPokemon[i]);
                    return "El pokemon cambio correctamente";
                }
            }
        }
        // Maneja errores inesperados
        catch (Exception)
        {
            return "Error";
        }

        return "";
    }
    

    //Metodo que comprueba si el item recibido esta bien
    public string Mochila(Jugador jugador)
    {
        try
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
                        return "Usted uso correctamente el item";
                    }
                }
                if (item == "0")
                {
                    return "Usted regreso hacia atras";
                }

                return "Item ingresado no encontrado";
            }
            else
            {
                return "Su mochila se encuentra vacia";
            }
        }
        catch (Exception)
        {
            return "Error";
        }
    }
    
    
    // Metodo para seleccionar un ataque
    public string SeleccionarAtaque(Jugador jugador, Jugador jugadorEnemigo)
    {
        try
        {
            interaccion.ImprimirMensaje($"{jugador.Nombre}, ingrese el nombre del movimiento desee usar o 0 para salir");
            string movimiento = interaccion.LeerEntrada();
            foreach (Movimiento mov in jugador.pokemonEnCancha().listaMovimientos)
            {
                if (movimiento == mov.Nombre)
                {
                    return CalculoAtaque(jugador, jugadorEnemigo, mov);
                    
                }
            }
            if (movimiento == "0")
            {
                return "Usted regreso hacia atras";
            }
        }
        catch (Exception)
        {
            return "Error";
        }
        return "";
    }
    
    
    public string CalculoAtaque(Jugador jugador, Jugador jugadorEnemigo, Movimiento movimiento)
    {
        if (movimiento != null)
        {
            
            if (jugador.pokemonEnCancha().puedeAtacar(interaccion) && !movimiento.EsEspecial)
            {
                jugador.atacar(jugadorEnemigo, movimiento, interaccion);
                jugadorEnemigo.pokemonEnCancha().aplicarDañoRecurrente(interaccion);
                return jugadorEnemigo.verSalud();
            }

            // Aplica ataques especiales si corresponde
            if (movimiento.EsEspecial && jugadorEnemigo.pokemonEnCancha().Estado == "Normal")
            {
                movimiento.AplicarAtaquesEspeciales(jugadorEnemigo.pokemonEnCancha(), interaccion);
                jugadorEnemigo.pokemonEnCancha().aplicarDañoRecurrente(interaccion);
                return jugadorEnemigo.verSalud();
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
                jugadorEnemigo.verSalud();
            }
        }

        return "";
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
