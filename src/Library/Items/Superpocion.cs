using Ucu.Poo.DiscordBot.Interaccion;

namespace Ucu.Poo.DiscordBot.Items;

public class SuperPocion : Item
{
    public override string Nombre => "SuperPocion";

    public override void Usar(Jugador jugador, IInteraccionConUsuario interaccion)
    {
        bool bandera = true;
        while (bandera)
        {
            for (int i = 0; i < jugador.equipoPokemon.Count; i++)
            {
                interaccion.ImprimirMensaje($"-{jugador.equipoPokemon[i].Nombre}");
            }

            interaccion.ImprimirMensaje(
                "Ingrese el nombre del pokemon que desea curar 70 puntos de vida o 0 para salir");
            string pokeIngresado = interaccion.LeerEntrada();

            for (int i = 0; i < jugador.equipoPokemon.Count; i++)
            {
                if (pokeIngresado == jugador.equipoPokemon[i].Nombre)
                {
                    if (jugador.equipoPokemon[i].VidaActual == jugador.equipoPokemon[i].VidaMax)
                    {
                        interaccion.ImprimirMensaje(
                            $"{jugador.equipoPokemon[i].Nombre} No puedes restaurar mas vida ya que ya esta al maximo.");
                    }
                    else
                    {
                        CurarPokemon(jugador, jugador.equipoPokemon[i], interaccion);
                        bandera = false;
                    }
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

    public void CurarPokemon(Jugador jugador, Pokemon pokemon, IInteraccionConUsuario interaccion)
    {
        pokemon.VidaActual += 70;
                
        if (pokemon.VidaActual > pokemon.VidaMax)
        {
            pokemon.VidaActual = pokemon.VidaMax;
            interaccion.ImprimirMensaje($"{pokemon.Nombre} se ha restaurado 70 puntos de vida.");
            interaccion.ImprimirMensaje($"{pokemon.Nombre} tiene {pokemon.VidaActual}/{pokemon.VidaMax} puntos de vida");
        }
    }
}