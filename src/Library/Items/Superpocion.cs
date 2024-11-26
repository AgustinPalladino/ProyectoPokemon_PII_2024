using Ucu.Poo.DiscordBot.Interaccion;

namespace Ucu.Poo.DiscordBot.Items;

public class SuperPocion : Item
{
    public override string Nombre => "SuperPocion";

    public override string Usar(Jugador jugador, string pokeIngresado)
    {
        for (int i = 0; i < jugador.equipoPokemon.Count; i++)
        {
            if (pokeIngresado == jugador.equipoPokemon[i].Nombre)
            {
                if (jugador.equipoPokemon[i].VidaActual >= jugador.equipoPokemon[i].VidaMax)
                {
                    return $"{jugador.equipoPokemon[i].Nombre} No puedes restaurar mas vida ya que ya esta al maximo.";
                }
                else
                {
                    return CurarPokemon(jugador.equipoPokemon[i]);
                }
            }
        }
        if (pokeIngresado == "0")
        {
            return "Usted volvio hacia atras";
        }
        return "Pokemon incorrecto, seleccione de nuevo";
    }

    public string CurarPokemon(Pokemon pokemon)
    {
        pokemon.VidaActual += 70;
        if (pokemon.VidaActual > pokemon.VidaMax)
        {
            pokemon.VidaActual = pokemon.VidaMax;
        }
        return "Su pokemon se ha restaurado 70 puntos de vida.";
    }
}