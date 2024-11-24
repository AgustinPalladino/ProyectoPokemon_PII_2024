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
    public override void Usar(Jugador jugador, IInteraccionConUsuario interaccion)
    {
        bool bandera = true;
        while (bandera)
        {
            for (int i = 0; i < jugador.equipoPokemon.Count; i++)
            {
                interaccion.ImprimirMensaje($"-{jugador.equipoPokemon[i].Nombre}");
            }
            interaccion.ImprimirMensaje("Ingrese el nombre del pokemon que desea curar el estado o 0 para salir");
            string pokeIngresado = interaccion.LeerEntrada();

            for (int i = 0; i < jugador.equipoPokemonDerrotados.Count; i++)
            {
                if (pokeIngresado == jugador.equipoPokemonDerrotados[i].Nombre)
                {
                    if (jugador.equipoPokemon[i].Estado == "Normal")
                    {
                        interaccion.ImprimirMensaje("No puedes usar el ítem ya que el Pokémon está en estado normal.");
                    }
                    if (jugador.equipoPokemon[i].Estado != "Normal")
                    {
                        SacarEstadoPokemon(jugador, jugador.equipoPokemon[i], interaccion);
                    }
                }
                if (pokeIngresado == "0")
                {
                    bandera = false;
                }
            }
            if (bandera)
            {
                interaccion.ImprimirMensaje("Pokemon incorrecto, seleccione de nuevo");
            }
        }
    }
    
    private void SacarEstadoPokemon(Jugador jugador, Pokemon pokemon, IInteraccionConUsuario interaccion)
    {
        pokemon.Estado = "Normal";
        interaccion.ImprimirMensaje($"{pokemon.Nombre} se ha curado de todos sus estados.");
    }
}