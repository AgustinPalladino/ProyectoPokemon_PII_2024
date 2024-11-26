using Ucu.Poo.DiscordBot.Interaccion;

namespace Ucu.Poo.DiscordBot.Items;

/// <summary>
/// Representa el ítem "CuraTotal", que elimina estados alterados del Pokémon en batalla.
/// </summary>
public class CuraTotal : Item
{
    // Implementación de la propiedad abstracta Nombre
    public override string Nombre => "CuraTotal";
    
    public override string Descripcion => "Cura cualquier estado";

    // Implementación del método abstracto Usar
    public override string Usar(Jugador jugador, string pokeIngresado)
    {
        for (int i = 0; i < jugador.equipoPokemon.Count; i++)
        {
            if (pokeIngresado == jugador.equipoPokemon[i].Nombre)
            {
                if (jugador.equipoPokemon[i].Estado == "Normal")
                {
                    return "No puedes usar el ítem ya que el Pokémon está en estado normal.";
                }

                if (jugador.equipoPokemon[i].Estado != "Normal")
                {
                    SacarEstadoPokemon(jugador.equipoPokemon[i]);
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

    public void SacarEstadoPokemon(Pokemon pokemon)
    {
        pokemon.Estado = "Normal";
    }
}