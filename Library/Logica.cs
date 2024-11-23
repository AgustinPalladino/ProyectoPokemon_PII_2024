namespace Library;

public class Logica
{
    
    /// <summary>
    /// Este metodo despliega el menu de opciones de cada jugador, decidimos ponerlo aqui, por uno de los patrones GRASP
    /// llamado bajo acomplamiento, con la intencion de que logica interactue con jugador de una manera mas cercana que combate
    /// </summary>
    public bool MenuDeJugador(Jugador j1, Jugador j2)
    {
        bool bandera = true;
        while (bandera)
        {
            int opcion = InteraccionConUsuario.EscogerOpcion(j1);
            switch (opcion)
            {
                case 1:
                    j1.verMovimientos(); // Ve los movimientos y vuelve al bucle
                    break;
                
                case 2:
                    j1.verSalud(); // Ve la salud y vuelve al bucle
                    break;
                
                case 3:
                    if (Mochila(j1, InteraccionConUsuario.ElegirItem(j1)))
                    {
                        return true; // Si uso el objeto sale del bucle
                    }
                    break; // Si regresa vuelve al bucle
                    
                case 4:
                    if (SeleccionarAtaque(j1,j2))
                    {
                        if (ChequeoVictoria(j2))
                        {
                            MensajesConsola.Ganador(j1);
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
                    MensajesConsola.Error();
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
            string pokeIngresado = InteraccionConUsuario.SeleccionarPokemon(j);
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
                        MensajesConsola.BienSeleccionado(pokemon.Value);
                        bandera = false;
                    }
                    else
                    {
                        MensajesConsola.Error();
                    }
                    break;
                }
            }
            //Si el pokemon nunca se encontro, vuelve a pedirlo
            if (!pokemonEncontrado)
            {
                MensajesConsola.NoEncontrado();
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
                    MensajesConsola.MostrarEquipo(j);
                    pokeIngresado = InteraccionConUsuario.CambiarPokemon(j);
                }
                else
                {
                    MensajesConsola.MostrarEquipo(j);
                    pokeIngresado = InteraccionConUsuario.CambiarPokemon(j);

                    if (pokeIngresado == "0")
                    {
                        MensajesConsola.VolverAtras();
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
                MensajesConsola.ImprimirMovimientos("Error");
                return false;
            }
        }
        return false;
    }
    

    //Metodo que comprueba si el item recibido esta bien
    public bool Mochila(Jugador j, string item)
    {
        bool bandera = true;
        while (bandera)
        {
            if (j.Mochila.Count != 0)
            {
                MensajesConsola.MostrarMochila(j);
                
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
                    MensajesConsola.VolverAtras();
                    return false;
                }

                MensajesConsola.NoEncontrado();
            }
            else
            {
                MensajesConsola.MochilaVacia();
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
            string movimiento = InteraccionConUsuario.ElegirMovimiento(j);
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
                MensajesConsola.VolverAtras();
                return false;
            }
            MensajesConsola.Error();
        }
        return false;
    }
    
    
    public int CalculoAtaque(Jugador jugador, Jugador jEnemigo, Movimiento movimiento)
    {
        if (movimiento != null)
        {
            
            if (jugador.pokemonEnCancha().puedeAtacar())
            {
                jugador.atacar(jEnemigo, movimiento);
                jEnemigo.pokemonEnCancha().aplicarDañoRecurrente();
            }

            // Aplica ataques especiales si corresponde
            if (movimiento.EsEspecial && jEnemigo.pokemonEnCancha().Estado == "Normal")
            {
                movimiento.AplicarAtaquesEspeciales(jEnemigo.pokemonEnCancha());
                InteraccionConUsuario.AtaqueEfecto(jEnemigo, movimiento);
                jEnemigo.pokemonEnCancha().aplicarDañoRecurrente();
            }

            if (jEnemigo.pokemonEnCancha().VidaActual <= 0)
            {
                MensajesConsola.PokemonDerrotado(jEnemigo);
                jEnemigo.equipoPokemonDerrotados.Add(jEnemigo.pokemonEnCancha());
                jEnemigo.equipoPokemon[0] = null;
                if (!ChequeoVictoria(jEnemigo))
                {
                    CambiarPokemon(jEnemigo);
                }
            }
            else
            {
                MensajesConsola.ImprimirSalud(jEnemigo);
            }
        }
        return 0;
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
