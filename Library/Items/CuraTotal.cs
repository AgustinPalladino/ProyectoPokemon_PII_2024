using System;

namespace Library
{
    /// <summary>
    /// Representa el ítem "CuraTotal", que elimina estados alterados del Pokémon en batalla.
    /// </summary>
    public class CuraTotal : Item
    {
        // Implementación de la propiedad abstracta Nombre
        public override string Nombre => "CuraTotal";

        // Implementación del método abstracto Usar
        public override void Usar(Jugador j)
        {
            // Obtener el Pokémon en cancha
            var pokemon = j.pokemonEnCancha();

            // Verificar si el Pokémon ya está en estado "Normal"
            if (pokemon.Estado == "Normal")
            {
                Console.WriteLine("No puedes usar el ítem ya que el Pokémon está en estado normal.");
                return;
            }

            // Verificar si el Pokémon tiene vida actual
            if (pokemon.VidaActual > 0)
            {
                // Restablecer el estado del Pokémon
                pokemon.Estado = "Normal";

                // Mensaje de confirmación
                Console.WriteLine($"{pokemon.Nombre} se ha curado de todos sus estados.");
            }
            else
            {
                // Mensaje si el Pokémon está debilitado
                Console.WriteLine($"{pokemon.Nombre} no tiene puntos de salud y no puede ser curado.");
            }
        }
    }
}
