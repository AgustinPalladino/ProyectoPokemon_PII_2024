using System.Formats.Asn1;
using System.Reflection.Metadata;
using Library.Pokemon;

namespace Library;

public class Revivir : Item
{
    public override void Usar(Jugador j)
    {
        if (j.pokemonEnCancha().Vida <= 0)
        {
            j.pokemonEnCancha().VidaActual =  j.pokemonEnCancha().Vida / 2; // Revive con el 50% de su vida máxima
            Console.WriteLine($"{j.pokemonEnCancha().Nombre} ha sido revivido con {j.pokemonEnCancha().Vida} puntos de vida.");
        }
        else
        {
            Console.WriteLine($"{j.pokemonEnCancha().Nombre} ya está vivo.");
        }
         Console.WriteLine($"{j.pokemonEnCancha().Nombre} se ha restaurado 70 puntos de vida.");
    }
    
}