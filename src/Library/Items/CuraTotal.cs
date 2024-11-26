using Ucu.Poo.DiscordBot.Interaccion;

namespace Ucu.Poo.DiscordBot.Items;

/// <summary>
/// Representa el ítem "CuraTotal", que elimina estados alterados del Pokémon en batalla.
/// </summary>
public class CuraTotal : Item
{
    // Implementación de la propiedad abstracta Nombre
    public override string Nombre => "CuraTotal";

    // Implementación del método abstracto Usar
    public override string Usar(Jugador jugador, string pokeIngresado)
    {
        for (int i = 0; i < jugador.equipoPokemonDerrotados.Count; i++)
        {
            if (pokeIngresado == jugador.equipoPokemonDerrotados[i].Nombre)
            {
                if (jugador.equipoPokemon[i].Estado == "Normal")
                {
                    return "No puedes usar el ítem ya que el Pokémon está en estado normal.";
                }

                if (jugador.equipoPokemon[i].Estado != "Normal")
                {
                    return SacarEstadoPokemon(jugador.equipoPokemon[i]);
                }
            }
        }
        if (pokeIngresado == "0")
        {
            return "Usted volvio hacia atras";
        }
        
        return "Pokemon incorrecto, seleccione de nuevo";
    }
    
    private string SacarEstadoPokemon(Pokemon pokemon)
    {
        pokemon.Estado = "Normal";
        return "Su pokemon se ha curado de todos sus estados";
    }
}