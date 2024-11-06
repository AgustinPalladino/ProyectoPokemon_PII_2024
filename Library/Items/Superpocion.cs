using System.Formats.Asn1;
using System.Reflection.Metadata;
using Library.Pokemon;
namespace Library;
public class SuperPocion : Item
{
    public override void Usar(Jugador j)
    {
         if (pokemon.vidaActual>0)
        {
            pokemon.vidaActual+=70;
            if( pokemon.vidaActual>pokemon.vidaMax)
            {
                 pokemon.vidaActual = pokemon.vidaMax;
            }
             Console.WriteLine($"{pokemon.Nombre} se ha restaurado 70 puntos de vida.");
        }
        else
        {
        Console.WriteLine($"{pokemon.Nombre} no puede ser restaurado porque está incapacitado.");
        }
    }
}