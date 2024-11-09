using System;

namespace Library
{
    /// <summary>
    /// Esta clase como las demas, estaran heredando mi interfaz de Iitems, con su metodo con diferente funcionalidad
    /// </summary>
    public class Revivir : Iitem
    {
        public  void Usar(Jugador j)
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
