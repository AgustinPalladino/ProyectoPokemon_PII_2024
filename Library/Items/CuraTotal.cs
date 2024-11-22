using Library.Interaccion;

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
        public override void Usar(Jugador j, IInteraccionConUsuario interaccion)
        {
            // Obtener el pokemon en cancha
            Pokemon pokemon = j.pokemonEnCancha();

            // Verificar si el pokemon ya está en estado "Normal"
            if (pokemon.Estado == "Normal")
            {
                interaccion.ImprimirMensaje("No puedes usar el ítem ya que el Pokémon está en estado normal.");
                return;
            }

            // Verificar si el Pokémon tiene vida actual
            if (pokemon.VidaActual > 0)
            {
                // Restablecer el estado del Pokémon
                pokemon.Estado = "Normal";

                // Mensaje de confirmación
                interaccion.ImprimirMensaje($"{pokemon.Nombre} se ha curado de todos sus estados.");
            }
            else
            {
                // Mensaje si el Pokémon está debilitado
                interaccion.ImprimirMensaje($"{pokemon.Nombre} no tiene puntos de salud y no puede ser curado.");
            }
        }
    }
}
