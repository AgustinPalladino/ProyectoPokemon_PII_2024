using System.Formats.Asn1;
using System.Reflection.Metadata;
using Library.Pokemon;

namespace Library;

public class Revivir : Item
{
    public override void Usar(Jugador j)
    {
        if (pokemon.vidaActual <= 0)
        {
                        
            int vida = pokemon.vidaMax; 
            pokemon.Vida = vida / 2; // Revive con el 50% de su vida máxima
            Console.WriteLine($"{pokemon.Nombre} ha sido revivido con {pokemon.vidaActual} puntos de vida.");
        }
        else
        {
            Console.WriteLine($"{pokemon.Nombre} ya está vivo.");
        }
         Console.WriteLine($"{pokemon.Nombre} se ha restaurado 70 puntos de vida.");
    }
    
}