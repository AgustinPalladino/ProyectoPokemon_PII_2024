using System;

namespace Library
{
    /// <summary>
    /// Esta clase como las demas, estaran heredando mi interfaz de Iitems, con su metodo con diferente funcionalidad
    /// </summary>
    public class CuraTotal : Iitem
    {
        public void Usar(Jugador j)
        {
            //Utilizo mi variable local
            var pokemon = j.pokemonEnCancha();
            if(pokemon.Estado=="Normal") {
                Console.WriteLine("No puedes usar el item ya que el pokemon esta en estado normal");
            }

            if (pokemon.VidaActual > 0)
            {
                /// Restablecer el estado del Pokémon a "Normal"
                pokemon.Estado = "Normal";

                /// Mensaje de confirmación
                Console.WriteLine($"{pokemon.Nombre} se ha curado de todos sus estados.");
            }
            else
            {
                Console.WriteLine($"{pokemon.Nombre} no tiene puntos de salud y no puede ser curado.");
            }
        }
    }
}
