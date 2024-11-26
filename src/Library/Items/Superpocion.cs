using Ucu.Poo.DiscordBot.Interaccion;

namespace Ucu.Poo.DiscordBot.Items;

public class SuperPocion : Item
{
    public override string Nombre => "SuperPocion";

    public override string Descripcion => "Recupera 70 puntos de vida";
    
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
                    CurarPokemon(jugador.equipoPokemon[i]);
                    return "Se ha utilizado el objeto correctamente";
                }
            }
        }
        if (pokeIngresado == "0")
        {
            return "Usted volvio hacia atras";
        }
        return "Pokemon incorrecto";
    }

    public void CurarPokemon(Pokemon pokemon)
    {
        pokemon.VidaActual += 70;
        if (pokemon.VidaActual > pokemon.VidaMax)
        {
            pokemon.VidaActual = pokemon.VidaMax;
        }
    }
}