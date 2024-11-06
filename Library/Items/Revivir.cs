using System;

namespace Library
{
    public class Revivir : Item
    {
        public override void Usar(Jugador j)
        {
            var pokemon = j.pokemonEnCancha();
            
            if (pokemon.VidaActual <= 0)
            {
                pokemon.VidaActual = pokemon.VidaMax / 2; // Revive con el 50% de su vida máxima
                pokemon.Estado = "Normal";
                Console.WriteLine($"{pokemon.Nombre} ha sido revivido con {pokemon.VidaActual} puntos de vida.");
            }
            else
            {
                Console.WriteLine($"{pokemon.Nombre} ya está vivo.");
            }
        }
    }
}
