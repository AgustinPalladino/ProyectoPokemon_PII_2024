using System;

namespace Library
{
    public class SuperPocion : Item
    {
        public override void Usar(Jugador j)
        {
            var pokemon = j.pokemonEnCancha();
            
            if (pokemon.VidaActual > 0)
            {
                pokemon.VidaActual += 70;
                
                if (pokemon.VidaActual > pokemon.VidaMax)
                {
                    pokemon.VidaActual = pokemon.VidaMax;
                }
                
                Console.WriteLine($"{pokemon.Nombre} se ha restaurado 70 puntos de vida.");
            }
            else
            {
                Console.WriteLine($"{pokemon.Nombre} no puede ser restaurado porque está incapacitado.");
            }
        }
    }
}
