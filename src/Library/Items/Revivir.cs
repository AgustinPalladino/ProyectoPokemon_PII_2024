using Ucu.Poo.DiscordBot.Interaccion;

namespace Ucu.Poo.DiscordBot.Items;

/// <summary>
/// Esta clase como las demas, estaran heredando mi interfaz de Iitems, con su metodo con diferente funcionalidad
/// </summary>
public class Revivir : Item
{
    public override string Nombre => "Revivir";

    public override string Usar(Jugador jugador, string pokeIngresado)
    {
        if (jugador.equipoPokemonDerrotados.Count() == 0)
        {
            return "No tiene ningun pokemon derrotado";
        }
        else
        {
            for (int i = 0; i < jugador.equipoPokemonDerrotados.Count; i++)
            {
                if (pokeIngresado == jugador.equipoPokemonDerrotados[i].Nombre)
                {
                    return RevivirPokemon(jugador, jugador.equipoPokemonDerrotados[i]);
                }
            }

            if (pokeIngresado == "0")
            {
                return "Usted volvio hacia atras";
            }
            
            return "Pokemon incorrecto, seleccione de nuevo";
        }
    }
    
    private string RevivirPokemon(Jugador jugador, Pokemon pokemon)
    {
        pokemon.VidaActual = pokemon.VidaMax / 2; // Revive con el 50% de su vida máxima
        pokemon.Estado = "Normal";

        jugador.equipoPokemon.Add(pokemon);
        jugador.equipoPokemonDerrotados.Remove(pokemon);

        return "Su pokemon ha sido revivido correctamente";
    }
}