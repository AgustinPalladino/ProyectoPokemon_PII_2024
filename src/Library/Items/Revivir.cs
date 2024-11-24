using Ucu.Poo.DiscordBot.Interaccion;

namespace Ucu.Poo.DiscordBot.Items;

/// <summary>
/// Esta clase como las demas, estaran heredando mi interfaz de Iitems, con su metodo con diferente funcionalidad
/// </summary>
public class Revivir : Item
{
    public override string Nombre => "Revivir";

    public override void Usar(Jugador jugador, IInteraccionConUsuario interaccion)
    {
        bool bandera = true;
        while (bandera)
        {
            if (jugador.equipoPokemonDerrotados.Count() == 0)
            {
                interaccion.ImprimirMensaje("No tiene ningun pokemon derrotado");
                bandera = false;
            }
            else
            {
                // Muestra los nombres de los pokemon derrotados
                for (int i = 0; i < jugador.equipoPokemonDerrotados.Count; i++)
                {
                    interaccion.ImprimirMensaje($"-{jugador.equipoPokemonDerrotados[i].Nombre}");
                }
                
                interaccion.ImprimirMensaje("Ingrese el nombre del pokemon que desea revivir o 0 para salir");
                string pokeIngresado = interaccion.LeerEntrada();

                for (int i = 0; i < jugador.equipoPokemonDerrotados.Count; i++)
                {
                    if (pokeIngresado == jugador.equipoPokemonDerrotados[i].Nombre)
                    {
                        RevivirPokemon(jugador, jugador.equipoPokemonDerrotados[i], interaccion);
                        bandera = false;
                    }
                }

                if (pokeIngresado == "0")
                {
                    interaccion.ImprimirMensaje("Usted volvio hacia atras");
                    bandera = false;
                }
                
                if (bandera)
                {
                    interaccion.ImprimirMensaje("Pokemon incorrecto, seleccione de nuevo");
                }
            }
        }
    }
    
    private void RevivirPokemon(Jugador jugador, Pokemon pokemon, IInteraccionConUsuario interaccion)
    {
        pokemon.VidaActual = pokemon.VidaMax / 2; // Revive con el 50% de su vida máxima
        pokemon.Estado = "Normal";
        interaccion.ImprimirMensaje($"{pokemon.Nombre} ha sido revivido con {pokemon.VidaActual} puntos de vida.");

        jugador.equipoPokemon.Add(pokemon);
        jugador.equipoPokemonDerrotados.Remove(pokemon);
    }
}