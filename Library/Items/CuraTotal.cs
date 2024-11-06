using System;

namespace Library
{
    public class CuraTotal : Item
    {
        public override void Usar(Jugador j)
        {
            //VariableLocal
            var pokemon = j.pokemonEnCancha();

            if (pokemon.VidaActual > 0)
            {
                // Restablecer el estado del Pokémon a "Normal"
                pokemon.Estado = "Normal";

                // Mensaje de confirmación
                Console.WriteLine($"{pokemon.Nombre} se ha curado de todos sus estados.");
            }
            else
            {
                Console.WriteLine($"{pokemon.Nombre} no tiene puntos de salud y no puede ser curado.");
            }
        }
    }
}
