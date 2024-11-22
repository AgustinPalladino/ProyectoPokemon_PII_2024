using Library.Interaccion;

namespace Library
{
    public class SuperPocion : Item
    {
        public override string Nombre => "SuperPocion";

        public override void Usar(Jugador jugador, IInteraccionConUsuario interaccion)
        {
            Pokemon pokemon = jugador.pokemonEnCancha();
            
            if (pokemon.VidaActual > 0)
            {
                pokemon.VidaActual += 70;
                
                if (pokemon.VidaActual > pokemon.VidaMax)
                {
                    pokemon.VidaActual = pokemon.VidaMax;
                }
                
                interaccion.ImprimirMensaje($"{pokemon.Nombre} se ha restaurado 70 puntos de vida.");
            }
            if(pokemon.VidaActual==100)
            {
                interaccion.ImprimirMensaje($"{pokemon.Nombre} No puedes restaurar mas vida ya que ya esta al maximo.");
            }
        }
    }
}
