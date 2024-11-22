using Library.Interaccion;

namespace Library;

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
                            interaccion.ImprimirMensaje($"Felicidades {j1.Nombre}! Has ganado la batalla.");
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
    
    
    public void EscogerEquipo(Jugador j)
    {
        bool bandera = true;
        while (bandera)
        {
            interaccion.ImprimirMensaje($"{j.Nombre}, seleccione su siguiente pokemon");
            string pokeIngresado = interaccion.LeerEntrada();
            bool pokemonEncontrado = false;
            foreach (var pokemon in DiccionariosYOperacionesStatic.DiccionarioPokemon)
            {
                if (pokeIngresado == pokemon.Key)
                {
                    pokemonEncontrado = true;
                    if (!j.nombreCheck.Contains(pokeIngresado))
                    {
                        j.nombreCheck.Add(pokeIngresado);
                        j.agregarPokemon(pokemon.Value.Clonar());
                        interaccion.ImprimirMensaje($"{pokeIngresado} se agrego a tu equipo");
                        bandera = false;
                    }
                    else
                    {
                        interaccion.ImprimirMensaje($"{pokeIngresado} ya se encuentra en el equipo");
                    }
                    break;
                }
            }
            //Si el pokemon nunca se encontro, vuelve a pedirlo
            if (!pokemonEncontrado)
            {
                interaccion.ImprimirMensaje($"{pokeIngresado}, no es correcto");
            }
        }
    }
    
    
    public bool CambiarPokemon(Jugador j)
    {
        bool bandera = true;
        string pokeIngresado;
        while (bandera)
        {
            try
            {
                if (j.equipoPokemon[0] == null)
                {
                    j.equipoPokemon.Remove(j.equipoPokemon[0]);
                    j.MostrarEquipo(interaccion);
                    interaccion.ImprimirMensaje("Ingrese el nombre del siguiente pokemon para que se una al combate");
                    pokeIngresado = interaccion.LeerEntrada();
                }
                else
                {
                    j.MostrarEquipo(interaccion);
                    interaccion.ImprimirMensaje($"{j.Nombre}, ingrese el nombre del pokemon que desea elegir o 0 para ir hacia atras");
                    pokeIngresado = interaccion.LeerEntrada();

                    if (pokeIngresado == "0")
                    {
                        interaccion.ImprimirMensaje("Usted regreso hacia atras");
                        return false;
                    }
                }
                
                // Cambia al pokemon si el nombre de este coincide
                for (int i = 0; i < j.equipoPokemon.Count; i++)
                {
                    if (pokeIngresado == j.equipoPokemon[i].Nombre) // Usar '?' para evitar NullReferenceException
                    {
                        j.cambiarPokemon(j.equipoPokemon[i]);
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
    public bool Mochila(Jugador j)
    {
        bool bandera = true;
        while (bandera)
        {
            if (j.Mochila.Count != 0)
            {
                interaccion.ImprimirMensaje("");
                string item = interaccion.LeerEntrada();
                
                for (int i = 0; i < j.Mochila.Count; i++)
                {
                    // Usa el objeto si el nombre coincide
                    if (j.Mochila[i].Nombre == item)
                    {
                        j.UsarMochila(j.Mochila[i]);
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
    public bool SeleccionarAtaque(Jugador j, Jugador jEnemigo)
    {
        bool bandera = true;
        while (bandera)
        {
            interaccion.ImprimirMensaje($"{j.Nombre}, ingrese el nombre del movimiento desee usar o 0 para salir");
            string movimiento = interaccion.LeerEntrada();
            foreach (Movimiento mov in j.pokemonEnCancha().listaMovimientos)
            {
                if (movimiento == mov.Nombre)
                {
                    CalculoAtaque(j,jEnemigo, mov);
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
    
    
    public void CalculoAtaque(Jugador jugador, Jugador jEnemigo, Movimiento movimiento)
    {
        if (movimiento != null)
        {
            
            if (jugador.pokemonEnCancha().puedeAtacar() && !movimiento.EsEspecial)
            {
                jugador.atacar(jEnemigo, movimiento);
                jEnemigo.pokemonEnCancha().aplicarDañoRecurrente();
            }

            // Aplica ataques especiales si corresponde
            if (movimiento.EsEspecial && jEnemigo.pokemonEnCancha().Estado == "Normal")
            {
                movimiento.AplicarAtaquesEspeciales(jEnemigo.pokemonEnCancha());
                jEnemigo.pokemonEnCancha().aplicarDañoRecurrente();
                jEnemigo.verSalud(interaccion);
            }

            if (jEnemigo.pokemonEnCancha().VidaActual <= 0)
            {
                interaccion.ImprimirMensaje($"{jEnemigo.Nombre}, tu {jEnemigo.pokemonEnCancha().Nombre} fue derrotado");
                jEnemigo.equipoPokemonDerrotados.Add(jEnemigo.pokemonEnCancha());
                jEnemigo.equipoPokemon[0] = null;
                if (!ChequeoVictoria(jEnemigo))
                {
                    CambiarPokemon(jEnemigo);
                }
            }
            else
            {
               jEnemigo.verSalud(interaccion);
            }
        }
    }

    
    public bool ChequeoVictoria(Jugador jEnemigo)
    {
        if (jEnemigo.equipoPokemon.Count == 1 && jEnemigo.equipoPokemon[0] == null)
        {
            return true;
        }
        return false;
    }
}
